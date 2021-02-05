/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2021/1/23
 * 时间: 21:06
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Windows.Forms;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using SharpDX.IO;
using SharpDX.WIC;
using Bitmap = SharpDX.Direct2D1.Bitmap;
using D2D1AlphaMode = SharpDX.Direct2D1.AlphaMode;
using D2D1Device = SharpDX.Direct2D1.Device;
using D2D1PixelFormat = SharpDX.Direct2D1.PixelFormat;
using D3D11Device = SharpDX.Direct3D11.Device;
using D3D11Device1 = SharpDX.Direct3D11.Device;
using DeviceContext = SharpDX.Direct2D1.DeviceContext;
using DXGIDevice = SharpDX.DXGI.Device;
using DXGIFactory = SharpDX.DXGI.Factory;
using Factory = SharpDX.Direct2D1.Factory;
using PixelFormat = SharpDX.WIC.PixelFormat;
namespace doticworks.GameFx.Module.Gfx
{
	public class DeviceManager
	{
		static readonly Lazy<DeviceManager> defaultmng=new Lazy<DeviceManager>(()=>{return new DeviceManager();});
		public static DeviceManager Default{
			get{return defaultmng.Value;}
		}
		private static readonly Format Format = Format.B8G8R8A8_UNorm;
		private static readonly D2D1PixelFormat D2PixelFormat = new D2D1PixelFormat(Format, D2D1AlphaMode.Premultiplied);
		private static readonly Guid WICPixelFormat = PixelFormat.Format32bppPBGRA;
		private static Size2F Dpi;
		private static BitmapProperties1 BitmapProps1;

		#region Direct3D 
		private D3D11Device d3DDevice;
		private DXGIDevice dxgiDevice;
		private SwapChain swapChain;
		private Surface backBuffer;
		private Bitmap1 targetBitmap;
		#endregion Direct3D 
		
		#region Direct2D 
		private D2D1Device d2DDevice;
		private DeviceContext d2DContext;
		private Factory d2DFactory;
		private RenderTarget renderTarget;
		#endregion Direct2D 
		private ImagingFactory wicFactory;
		public DeviceManager()
		{
			try
			{
				this.d3DDevice = new D3D11Device(DriverType.Hardware, DeviceCreationFlags.BgraSupport);
				this.dxgiDevice = d3DDevice.QueryInterface<D3D11Device1>().QueryInterface<DXGIDevice>();
				this.d2DDevice = new D2D1Device(dxgiDevice);
				this.d2DContext = new DeviceContext(d2DDevice, DeviceContextOptions.EnableMultithreadedOptimizations);
				this.d2DFactory = this.d2DContext.Factory;
				this.wicFactory = new ImagingFactory2();
			}
			catch
			{
				this.ClearResources();
				try
				{
					this.d2DFactory = new Factory(FactoryType.SingleThreaded);
					this.wicFactory = new ImagingFactory();
				}
				catch
				{
					this.ClearResources();
				}
			}
			if (this.d2DFactory != null)
			{
				Dpi = d2DFactory.DesktopDpi;
				BitmapProps1 = new BitmapProperties1(D2PixelFormat, Dpi.Width, Dpi.Height, BitmapOptions.Target);
			}
		}
		public DeviceContext D2DContext
		{
			get { return this.d2DContext; }
		}
		public Factory D2DFactory
		{
			get { return this.d2DFactory; }
		}
		public RenderTarget RenderTarget
		{
			get { return renderTarget; }
		}
		public bool SupportD3D
		{
			get { return this.d2DContext != null; }
		}
		public bool SupportD2D
		{
			get { return this.d2DFactory != null; }
		}

		#region 渲染器
		public void CreateRenderTarget(IntPtr Hwnd)
		{
			if (SupportD3D)
			{
				SwapChainDescription swapChainDesc = new SwapChainDescription()
				{
					BufferCount = 1,
					Usage = Usage.RenderTargetOutput,
					OutputHandle =Hwnd,
					IsWindowed = true,
					ModeDescription = new ModeDescription(0, 0, new Rational(60, 1), Format),
					SampleDescription = new SampleDescription(1, 0),
					SwapEffect = SwapEffect.Discard
				};
				this.swapChain = new SwapChain(dxgiDevice.GetParent<Adapter>().GetParent<DXGIFactory>(),
					d3DDevice, swapChainDesc);
				this.backBuffer = Surface.FromSwapChain(this.swapChain, 0);
				this.targetBitmap = new Bitmap1(this.d2DContext, backBuffer);
				this.renderTarget = new DeviceContext(this.d2DDevice, DeviceContextOptions.None);
				((DeviceContext)this.renderTarget).Target = targetBitmap;
			}
			else
			{
				RenderTargetProperties renderProps = new RenderTargetProperties
				{
					PixelFormat = D2PixelFormat,
					Usage = RenderTargetUsage.None,
					Type = RenderTargetType.Default
				};
				// 渲染目标属性。
				HwndRenderTargetProperties hwndProps = new HwndRenderTargetProperties()
				{
					Hwnd = Hwnd,
//					PixelSize = new Size2(control.ClientSize.Width, control.ClientSize.Height),
					PresentOptions = PresentOptions.None
				};
				// 渲染目标。
				this.renderTarget = new WindowRenderTarget(d2DFactory, renderProps, hwndProps)
				{
					AntialiasMode = AntialiasMode.PerPrimitive
				};
			}
		}
		/// <summary>
		/// 调整渲染目标的尺寸。
		/// </summary>
		/// <param name="control">渲染的目标控件。</param>
		public void ResizeRenderTarget(Control control)
		{
			if (this.swapChain == null)
			{
				((WindowRenderTarget)this.renderTarget).Resize(
					new Size2(control.ClientSize.Width, control.ClientSize.Height));
			}
			else
			{
				((DeviceContext)this.renderTarget).Target = null;
				this.backBuffer.Dispose();
				this.targetBitmap.Dispose();
				this.swapChain.ResizeBuffers(1, 0, 0, Format, SwapChainFlags.None);
				this.backBuffer = Surface.FromSwapChain(this.swapChain, 0);
				this.targetBitmap = new Bitmap1(this.d2DContext, backBuffer);
				((DeviceContext)this.renderTarget).Target = targetBitmap;
			}
		}
		/// <summary>
		/// 开始渲染器的绘制。
		/// </summary>
		public void BeginDraw()
		{
			this.renderTarget.BeginDraw();
		}
		/// <summary>
		/// 结束渲染器的绘制。
		/// </summary>
		public void EndDraw()
		{
			this.renderTarget.EndDraw();
			if (this.swapChain != null)
			{
				this.swapChain.Present(0, PresentFlags.None);
			}
		}

		#endregion // 渲染器

		#region 辅助方法

		/// <summary>
		/// 创建指定尺寸的位图。
		/// </summary>
		/// <param name="size">要创建位图的尺寸。</param>
		/// <returns>创建好的位图。</returns>
		public Bitmap1 CreateBitmap(Size2 size)
		{
			return new Bitmap1(this.d2DContext, size, BitmapProps1);
		}
		/// <summary>
		/// 从给定的 Byte 数组中加载 Direct2D 位图。
		/// </summary>
		/// <param name="data">要加载位图的数据。</param>
		/// <returns>得到的 Direct2D 位图。</returns>
		public Bitmap LoadBitmapFromBytes(byte[] data)
		{
			using (MemoryStream stream = new MemoryStream(data))
			{
				return LoadBitmapFromStream(stream);
			}
		}
		/// <summary>
		/// 从给定的流中加载 Direct2D 位图。
		/// </summary>
		/// <param name="stream">要加载位图的流。</param>
		/// <returns>得到的 Direct2D 位图。</returns>
		public Bitmap LoadBitmapFromStream(Stream stream)
		{
			using (BitmapDecoder decoder = new BitmapDecoder(wicFactory, stream, DecodeOptions.CacheOnLoad))
			{
				using (FormatConverter formatConverter = new FormatConverter(wicFactory))
				{
					formatConverter.Initialize(decoder.GetFrame(0), WICPixelFormat);
					return Bitmap.FromWicBitmap(this.renderTarget, formatConverter);
				}
			}
		}
		/// <summary>
		/// 将 Direct2D 位图保存到文件中。
		/// </summary>
		/// <param name="image">要保存的位图。</param>
		/// <param name="fileName">要保存的文件名。</param>
		public void SaveBitmapToFile(Bitmap image, string fileName)
		{
			using (ImagingFactory2 factory = new ImagingFactory2())
			{
				using (WICStream stream = new WICStream(factory, fileName, NativeFileAccess.Write))
				{
					using (BitmapEncoder encoder = new PngBitmapEncoder(factory))
					{
						encoder.Initialize(stream);
						using (BitmapFrameEncode bitmapFrameEncode = new BitmapFrameEncode(encoder))
						{
							bitmapFrameEncode.Initialize();
							int width = image.PixelSize.Width;
							int height = image.PixelSize.Height;
							bitmapFrameEncode.SetSize(width, height);
							Guid wicPixelFormat = WICPixelFormat;
							bitmapFrameEncode.SetPixelFormat(ref wicPixelFormat);
							using (ImageEncoder imageEncoder = new ImageEncoder(factory, this.d2DDevice))
							{
								imageEncoder.WriteFrame(image, bitmapFrameEncode,
									new ImageParameters(D2PixelFormat, 96, 96, 0, 0, width, height));
								bitmapFrameEncode.Commit();
								encoder.Commit();
							}
						}
					}
				}
			}
		}

		#endregion // 辅助方法
		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		public void Dispose()
		{
			ClearResources();
			GC.SuppressFinalize(this);
		}
		/// <summary>
		/// 清理所有正在使用的资源，并设置为 <c>null</c>。
		/// </summary>
		private void ClearResources()
		{
			if (this.d3DDevice != null)
			{
				this.d3DDevice.Dispose();
				this.d3DDevice = null;
			}
			if (this.dxgiDevice != null)
			{
				this.dxgiDevice.Dispose();
				this.dxgiDevice = null;
			}
			if (this.swapChain != null)
			{
				this.swapChain.Dispose();
				this.swapChain = null;
			}
			if (this.backBuffer != null)
			{
				this.backBuffer.Dispose();
				this.backBuffer = null;
			}
			if (this.targetBitmap != null)
			{
				this.targetBitmap.Dispose();
				this.swapChain = null;
			}
			if (this.d2DDevice != null)
			{
				this.d2DDevice.Dispose();
				this.d2DDevice = null;
			}
			if (this.d2DContext != null)
			{
				this.d2DContext.Dispose();
				this.d2DContext = null;
			}
			if (this.d2DFactory != null)
			{
				this.d2DFactory.Dispose();
				this.d2DFactory = null;
			}
			if (this.renderTarget != null)
			{
				this.renderTarget.Dispose();
				this.renderTarget = null;
			}
			if (this.wicFactory != null)
			{
				this.wicFactory.Dispose();
				this.wicFactory = null;
			}
		}
	}
}
