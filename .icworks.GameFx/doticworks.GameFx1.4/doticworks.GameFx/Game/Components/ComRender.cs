/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2021/1/16
 * 时间: 18:44
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using doticworks.GameFx.Module.Gfx;

namespace doticworks.GameFx.Game.Components
{
	/// <summary>
	/// Description of ComRender.
	/// </summary>
	public class ComRender:Component
	{
		public override void Load(ComponentModel model)
		{
			model.RI_ComRender=this;
		}
		public override Component Copy()
		{
			return new ComRender();
		}
		public virtual void DrawBefore(IRender rd){
			
		}
		public virtual void DrawAfter(IRender rd){
			
		}
		public virtual void Draw(IRender rd){
			rd._OverlayTransform(Owner.transform);
			DrawBefore(rd);
			this.Owner.components.RI_ComNode.ChildInvoke(cr=>cr.components.RI_ComRender.Draw(rd));
			DrawAfter(rd);
			rd._RemoveTransform();
//			rd.transformstack.SubtractTransform(Owner.transform);
		}
	}
}
