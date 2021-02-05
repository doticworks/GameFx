/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/12/20
 * 时间: 21:35
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;
using SharpDX;
using SharpDX.DXGI;
using System.Collections.Generic;
namespace doticworks.GameFx.GFX
{
	public enum RenderMode{
		GPU=1,
		CPU=2,
		DEF=0
//		public int value;
//		public RenderMode(int rendermode){value=rendermode;}
	}
	public partial class Render:IDisposable
	{
		public Render(IntPtr Hwnd,int w,int h,RenderMode rm)
		{
			
			d2dFactory =new SharpDX.Direct2D1.Factory(FactoryType.MultiThreaded);
			dwFactory =new SharpDX.DirectWrite.Factory(SharpDX.DirectWrite.FactoryType.Shared);
			PixelFormat pixel=new PixelFormat(Format.R8G8B8A8_UNorm,SharpDX.Direct2D1.AlphaMode.Unknown);
			HwndRenderTargetProperties hrtp=new HwndRenderTargetProperties();
			hrtp.Hwnd=Hwnd;
			hrtp.PixelSize=new Size2(w,h);
			_w=w;_h=h;
			hrtp.PresentOptions=PresentOptions.Immediately;
			RenderTargetType rtt=RenderTargetType.Default;
			if(rm==RenderMode.GPU){rtt=RenderTargetType.Hardware;}if(rm==RenderMode.CPU){rtt=RenderTargetType.Software;}
			RenderTargetProperties rtp=new RenderTargetProperties(RenderTargetType.Hardware,pixel,0,0,RenderTargetUsage.None,SharpDX.Direct2D1.FeatureLevel.Level_DEFAULT);
			_rt=new WindowRenderTarget(d2dFactory,rtp,hrtp);
			
//			DeviceContextRenderTarget de=new DeviceContextRenderTarget(d2dFactory,hrtp);
//			de.
//			DeviceContext dc= dev;
//			SwapChainDescription swapChainDesc = new SwapChainDescription()
//            {
//                ModeDescription = backBufferDesc,
//                SampleDescription = new SampleDescription(1, 0),//color quality
//                Usage = Usage.RenderTargetOutput,
//                BufferCount = 1,//set"1" is doubled buffer!!
//                OutputHandle = rf.Handle,
//                IsWindowed = true
//            };
//			SwapChain sc=new SwapChain(d2dFactory,,
//			Surface sur=Surface.FromSwapChain();
//			_rt=new RenderTarget(d2dFactory,sur,hrtp);
//			DeviceContext dc=new DeviceContext(sur);
			
			
			root=new LayerNode(1.2f);
			temp_brush_solid=new SolidColorBrush(_rt,temp_color);
			temp_textfmt=new SharpDX.DirectWrite.TextFormat(dwFactory,"微软雅黑",10);
			temp_textlay=new SharpDX.DirectWrite.TextLayout(dwFactory,"",temp_textfmt,10,10);
			temp_ell=new Ellipse(temp_vec2,1,1);
			temp_polygon=new PathGeometry(d2dFactory);
		}
		SharpDX.Direct2D1.Factory d2dFactory;
		SharpDX.DirectWrite.Factory dwFactory;
		RenderTarget _rt;
		public LayerNode root;
		public void Present(){
			_rt.BeginDraw();
			temp_color.A=0.2F;
			temp_color.B=0.5F;
			temp_color.G=0.7F;
			temp_color.R=1;
			_rt.Clear(temp_color);
		/*	temp_color.G=0.2F;
			temp_brush_solid.Color=temp_color;
//			_rt.Clear(new RawColor4(0.2F,0.5F,0.7F,1));*/
			root.Draw(this);
//			_rt.FillRectangle(new RawRectangleF(50,50,100,100),temp_brush_solid);// temp_brush_solid);
			_rt.EndDraw();
		}
		public void Dispose(){
			temp_brush_solid.Dispose();
			temp_textfmt.Dispose();
			temp_textlay.Dispose();
			
			_rt.Dispose();
			d2dFactory.Dispose();
			dwFactory.Dispose();
		}
	}
}
