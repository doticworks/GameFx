/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2021/1/25
 * 时间: 17:31
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
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
	public class GraphicsDevice:IDisposable
	{
		static readonly Lazy<GraphicsDevice> defaultmng=new Lazy<GraphicsDevice>(()=>{
		     Terminal.WF("<Y>ModuleLoad	<B>GraphicsDC  	");
		     GraphicsDevice gd= new GraphicsDevice();
		     Terminal.WF("<G>{0}<W>\r\n",gd.D3Dsupport?"<G>Success!<w>":"<R>Failed! (All Effect will not work)");
		     return gd;
		     });
		public static GraphicsDevice Default{
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
//		private SwapChain swapChain;
//		private Surface backBuffer;
//		private Bitmap1 targetBitmap;
		#endregion Direct3D 
		
		#region Direct2D 
		private D2D1Device d2DDevice;
		private DeviceContext d2DContextInternal;
		DeviceContext firstdc=null;
		private Factory d2DFactory;
		public Factory D2DFactory{get{return this.d2DFactory;}}
//		private RenderTarget renderTarget;
		#endregion Direct2D 
		private ImagingFactory wicFactory;
		
//		IntPtr outputhandle=IntPtr.Zero;
		bool D3Dsupport=false;
		bool D2Dsupport=false;
		public bool SupportD3D{get{return D3Dsupport;}}
		public bool SupportD2D{get{return D2Dsupport;}}
		
		private GraphicsDevice()
		{
			try
			{
				this.d3DDevice = new D3D11Device(DriverType.Hardware, DeviceCreationFlags.BgraSupport);
				this.dxgiDevice = d3DDevice.QueryInterface<D3D11Device1>().QueryInterface<DXGIDevice>();
				this.d2DDevice = new D2D1Device(dxgiDevice);
				this.d2DContextInternal = new DeviceContext(d2DDevice, DeviceContextOptions.None);
				this.d2DFactory = this.d2DContextInternal.Factory;
				this.wicFactory = new ImagingFactory2();
				D3Dsupport=true;
			}
			catch
			{
				this.ClearResources();
				try
				{
					this.d2DFactory = new Factory(FactoryType.SingleThreaded);
					this.wicFactory = new ImagingFactory();
					D2Dsupport=true;
				}
				catch
				{
					this.ClearResources();
					Terminal.WF("GameFx<R>Cannot Run in a D2D-no-support Device<W>\r\nGameFx<R>Now will Exit");
				}
			}
			if (this.d2DFactory != null)
			{
				Dpi = d2DFactory.DesktopDpi;
				BitmapProps1 = new BitmapProperties1(D2PixelFormat, Dpi.Width, Dpi.Height, BitmapOptions.Target);
			}
		}
		
		#region apply
		public DeviceContext CreateDeviceContext(out Action OnDispose)
		{
			DeviceContext dc=new DeviceContext(this.d2DDevice, DeviceContextOptions.EnableMultithreadedOptimizations);
			OnDispose=()=>{
				if (dc != null)
				{
					dc.Dispose();
					dc= null;
				}
			};
			if(firstdc==null){firstdc=dc;d2DFactory=dc.Factory;}
			return dc;
		}
		public void CreateSwapChain(IntPtr hwnd,DeviceContext dc,out SwapChain swapchain,out Bitmap1 swapbuffer,out Func<IntPtr,int,int,Bitmap1> OnResize,out Action OnDispose){
			SwapChainDescription swapChainDesc = new SwapChainDescription()
				{
					BufferCount = 1,
					Usage = Usage.RenderTargetOutput,
					OutputHandle =hwnd,
					IsWindowed = true,
					ModeDescription = new ModeDescription(0, 0, new Rational(60, 1), Format),
					SampleDescription = new SampleDescription(1, 0),
					SwapEffect = SwapEffect.Discard
				};
				SwapChain sc = new SwapChain(dxgiDevice.GetParent<Adapter>().GetParent<DXGIFactory>(),d3DDevice, swapChainDesc);
				Surface backbuffer=Surface.FromSwapChain(sc, 0);
				Bitmap1 bb= new Bitmap1(dc,backbuffer);
				OnDispose=()=>{
					if (sc!= null){sc.Dispose();sc = null;}
					if (backbuffer != null){backbuffer.Dispose();backbuffer = null;}
					if (bb != null){bb.Dispose();bb = null;}
				};
				OnResize=(I,w,h)=>{
					lock(sc){
					backbuffer.Dispose();
					bb.Dispose();
					
					sc.ResizeBuffers(1,w,h, Format, SwapChainFlags.None);
					backbuffer = Surface.FromSwapChain(sc, 0);
					bb = new Bitmap1(dc, backbuffer);
					return bb;
					}
				//	bb.Dispose();
				//	bb= null;
				//	backbuffer.Dispose();
				//	sc.ResizeBuffers(1, 0, 0, Format, SwapChainFlags.None);
				//	backbuffer = Surface.FromSwapChain(sc, 0);
				//	bb = new Bitmap1(dc,backbuffer);
				//	dc.Target = bb;
				};
				swapchain=sc;
				swapbuffer=bb;
		}
//		public RenderTarget CreateRendertarget(out Action OnDispose){
//			return null;
//		}
		public Bitmap1 CreateBitmap(Size2 size)
		{
			return new Bitmap1(firstdc, size, BitmapProps1);
		}
		public Bitmap LoadBitmapFromBytes(byte[] data)
		{
			using (MemoryStream stream = new MemoryStream(data))
			{
				return LoadBitmapFromStream(stream);
			}
		}
		public Bitmap LoadBitmapFromStream(Stream stream)
		{
			using (BitmapDecoder decoder = new BitmapDecoder(wicFactory, stream, DecodeOptions.CacheOnLoad))
			{
				using (FormatConverter formatConverter = new FormatConverter(wicFactory))
				{
					formatConverter.Initialize(decoder.GetFrame(0), WICPixelFormat);
					return Bitmap.FromWicBitmap(firstdc, formatConverter);
				}
			}
		}
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
		#endregion
		
		#region dispose
		public void Dispose()
		{
			ClearResources();
			GC.SuppressFinalize(this);
		}
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
//			if (this.swapChain != null)
//			{
//				this.swapChain.Dispose();
//				this.swapChain = null;
//			}
//			if (this.backBuffer != null)
//			{
//				this.backBuffer.Dispose();
//				this.backBuffer = null;
//			}
//			if (this.targetBitmap != null)
//			{
//				this.targetBitmap.Dispose();
//				this.swapChain = null;
//			}
			if (this.d2DDevice != null)
			{
				this.d2DDevice.Dispose();
				this.d2DDevice = null;
			}
			if (this.d2DContextInternal != null)
			{
				this.d2DContextInternal.Dispose();
				this.d2DContextInternal = null;
			}
			if (this.firstdc != null)
			{
				this.firstdc.Dispose();
				this.firstdc = null;
			}
			if (this.d2DFactory != null)
			{
				this.d2DFactory.Dispose();
				this.d2DFactory = null;
			}
//			if (this.renderTarget != null)
//			{
//				this.renderTarget.Dispose();
//				this.renderTarget = null;
//			}
			if (this.wicFactory != null)
			{
				this.wicFactory.Dispose();
				this.wicFactory = null;
			}
		}
		#endregion
		
	}
}
