/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2021/1/16
 * 时间: 18:45
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using doticworks.GameFx.Module.Gfx;
namespace doticworks.GameFx.Game.Components
{
	/// <summary>
	/// Description of ComRenderNormal.
	/// </summary>
	public class ComRenderNormal:ComRender
	{
		public ComRenderNormal()
		{
		}
		public Action<IRender> paint;
		public override Component Copy()
		{
			ComRenderNormal crn=new ComRenderNormal();
			if(paint!=null){
				crn.paint=paint.Clone() as Action<IRender>;
			}
			return crn;
		}
		public override void DrawBefore(IRender rd)
		{
			if(paint!=null){paint(rd);}
		}
		
	}
}
