/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/11/20
 * 时间: 21:50
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
namespace doticworks.GameFx.GAME
{
	/// <summary>
	/// Description of InputMap.
	/// </summary>
	public partial class InputMap
	{
		Queue<Keys> _keydown=new Queue<Keys>();
		List<Keys> _holdedkeys=new List<Keys>();
		Queue<MouseButtons> _mousedown=new Queue<MouseButtons>();
		List<MouseButtons> _holdedmouse=new List<MouseButtons>();
		
		public void I_MouseMove(int sx,int sy,MouseEventArgs e)
		{
			MouseDx=sx-Mousex;
			MouseDy=sy-Mousey;
			Mousex=sx;
			Mousey=sy;
			MouseWheel=e.Delta;
		}
		public void I_MouseUp(MouseEventArgs e)
		{
			if(_holdedmouse.Contains(e.Button)){
				_holdedmouse.Remove(e.Button);
			}
		}
		public void I_MouseDown(MouseEventArgs e)
		{
			_mousedown.Enqueue(e.Button);
			if(!_holdedmouse.Contains(e.Button)){
				_holdedmouse.Add(e.Button);
			}
		}
		public void I_KeyDown(Keys k){
			_keydown.Enqueue(k);
			if(!_holdedkeys.Contains(k)){
				_holdedkeys.Add(k);
			}
		}
		public void I_KeyUp(Keys k){
			if(_holdedkeys.Contains(k)){
				_holdedkeys.Remove(k);
			}
		}
	}
}
