/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2021/2/11
 * 时间: 22:41
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Windows.Forms;
using doticworks.GameFx.Common;
namespace doticworks.GameFx.Game.Components
{
	public class ComInput:Component
	{
		public ComInput()
		{
		}
		public override Component Copy()
		{
			ComInput ci=new ComInput();
			ci.MouseMove=MouseMove==null?null:MouseMove.Clone() as Action<Vector2,int>;
			ci.KeyDown=KeyDown==null?null:KeyDown.Clone() as Action<Keys>;
			ci.KeyUp=KeyUp==null?null:KeyUp.Clone() as Action<Keys>;
			ci.KeyHold=KeyHold==null?null:KeyHold.Clone() as Action<Keys>;
			ci.MouseDown=MouseDown==null?null:MouseDown.Clone() as Action<MouseButtons>;
			ci.MouseUp=MouseUp==null?null:MouseUp.Clone() as Action<MouseButtons>;
			ci.MouseHold=MouseHold==null?null:MouseHold.Clone() as Action<MouseButtons>;
			ci.MouseDouble=MouseDouble==null?null:MouseDouble.Clone() as Action<MouseButtons>;
			return ci;
		}
		public override void Load(ComponentModel model)
		{
			model.RI_ComInput=this;
		}
		public Action<Vector2,int> MouseMove=(v,z)=>{};
		public Action<Keys> KeyDown=(k)=>{};
		public Action<Keys> KeyUp=(k)=>{};
		public Action<Keys> KeyHold=(k)=>{};
		public Action<MouseButtons> MouseDown=(m)=>{};
		public Action<MouseButtons> MouseUp=(m)=>{};
		public Action<MouseButtons> MouseHold=(m)=>{};
		public Action<MouseButtons> MouseDouble=(m)=>{};
	}
}
