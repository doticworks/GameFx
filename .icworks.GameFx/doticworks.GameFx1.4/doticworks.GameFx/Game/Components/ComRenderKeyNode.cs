/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2021/2/2
 * 时间: I love you  9:16
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using doticworks.GameFx.Module.Gfx;
using SharpDX.Direct2D1;
using SharpDX.Direct3D11;

namespace doticworks.GameFx.Game.Components
{
	/// <summary>
	/// Description of ComRenderKeyNode.
	/// </summary>
	public class ComRenderKeyNode:ComRender
	{
		public ComRenderKeyNode()
		{
			keytarget=Module.Gfx.GraphicsDevice.Default.CreateBitmap(new SharpDX.Size2(10,10));
			OnResizeBuffer=(w,h)=>{
				Bitmap1 willdis=keytarget;
				keytarget=Module.Gfx.GraphicsDevice.Default.CreateBitmap(new SharpDX.Size2(w,h));
				willdis.Dispose();
			};
		}
		public ComRenderKeyNode(Bitmap1 swaptarget,Func<int,int,Bitmap1> onresize)
		{
			keytarget=swaptarget;
			isrootnode=true;
			OnResizeBuffer= (w,h)=>
			{
				Bitmap1 willdis = keytarget;
				keytarget= onresize(w,h);
				willdis.Dispose();
			};
		}
		bool isrootnode=false;
		public Action<int,int> OnResizeBuffer=(w,h)=>{};
		public override Component Copy()
		{
			throw new Exception("当时偷懒还没写啊");
		}
		Bitmap1 keytarget;
		public virtual void DrawKeyNode(doticworks.GameFx.Module.Gfx.IRender rd){
			rd._Target(keytarget);
			rd._Start();
			Owner.components.RI_ComNode.ChildInvoke((g)=>{g.components.RI_ComRender.Draw(rd);});
			rd._End();
		}
		public override void Draw(doticworks.GameFx.Module.Gfx.IRender rd)
		{
			rd._OverlayTransform(Owner.transform);
			DrawBefore(rd);
			rd._Bitmap(keytarget,0,0);
			DrawAfter(rd);
			rd._RemoveTransform();;
			
			
		}
	}
}
