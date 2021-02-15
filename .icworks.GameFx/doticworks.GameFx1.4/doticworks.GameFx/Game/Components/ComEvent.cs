/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2021/2/2
 * 时间: I love you  11:05
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace doticworks.GameFx.Game.Components
{
	/// <summary>
	/// Description of ComEvent.
	/// </summary>
	public class ComEvent:Component
	{
		public ComEvent()
		{
		}
		public override void Load(ComponentModel model)
		{
			base.Load(model);
			model.RI_ComEvent = this;
			model.onupdate += (t) =>
			{
				if (Enable)
				{
					OnUpdate(t);
				}
			};
		}
		

		public Action OnWorldStart;
		public Action<float> OnUpdate;
		public Action OnResize;
		public override Component Copy()
		{
			ComEvent ce = new ComEvent();
			ce.OnUpdate=(OnUpdate==null)?null:OnUpdate.Clone() as Action<float>;
			ce.OnWorldStart=OnWorldStart==null?null:OnWorldStart.Clone()as Action;
			ce.OnResize=OnResize==null?null:OnResize.Clone()as Action;
			return ce;
		}
	}
}
