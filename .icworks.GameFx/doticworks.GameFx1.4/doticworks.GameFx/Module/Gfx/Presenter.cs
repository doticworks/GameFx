/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2021/1/16
 * 时间: 11:55
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;
using SharpDX;
using DG=SharpDX.DXGI;
using System.Collections.Generic;
using D31=SharpDX.Direct3D11;
using D3=SharpDX.Direct3D;
namespace doticworks.GameFx.Module.Gfx
{
	/// <summary>
	/// Description of Presenter.
	/// </summary>
	public class Presenter
	{
		public Presenter(IntPtr TargetHan,Game.GameObject root)
		{
			TargetHandle=TargetHan;
			DC=GraphicsDevice.Default.CreateDeviceContext(out OnDCDispose);
			GraphicsDevice.Default.CreateSwapChain(TargetHan,DC,out sc,out swapbuffer,out OnResize,out OnSCDispose);
			
		}
		public void InitRoot(Game.GameObject root){
			mainrender=new Render(DC,root);
		}
		Action<IRender> rendermaintree=null;
		IntPtr TargetHandle;
		public Bitmap1 swapbuffer;
		DG.SwapChain sc;
		public Render mainrender;
		Action OnDCDispose;
		Action OnSCDispose;
		public Func<IntPtr,int,int,Bitmap1> OnResize;
		DeviceContext DC;
		Result result;
		
		/// <summary>
		/// Call Draw,then call Present!!!
		/// </summary>
		public void Draw()
		{
			mainrender.Draw();
		}
		public void Present(){
//			doticworks.GameFx.Helper.StopTimer.CheckTer("<Y>onpresenter<W>",()=>{
			result=sc.Present(0,DG.PresentFlags.None);
			if(result.Failure){PresentCrash();}
		}
		void PresentCrash(){
			Terminal.WF("<R>Presenter Crashed with {0}\r\n GameFx Now Will Exit",result.ToString());
		}
	}
}
