/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/122
 * 时间: 11:40
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
		public int Mousex;
		public int Mousey;
		public int MouseDx;
		public int MouseDy;
		public int MouseWheel;
		public bool MouseLeftDown;
		Dictionary<MouseButtons,Action> _Mouseevents_press=new Dictionary<MouseButtons, Action>();
		Dictionary<MouseButtons,Action> _Mouseevent_press_change=new Dictionary<MouseButtons, Action>();
		Dictionary<MouseButtons,Action> _Mouseevents_hold=new Dictionary<MouseButtons, Action>();
		Dictionary<MouseButtons,Action> _Mouseevent_hold_change=new Dictionary<MouseButtons, Action>();
		Action<MouseButtons> AllMouseevent=(a)=>{};
		Action MouseMove=()=>{};
		public bool MouseDown(MouseButtons k){
			return _holdedmouse.Contains(k);
		}
		public void MousePress(MouseButtons key,Action arg){
			if(_Mouseevent_press_change.ContainsKey(key)){
				_Mouseevent_press_change.Remove(key);
			   	_Mouseevent_press_change.Add(key,arg);
			}else{
				_Mouseevent_press_change.Add(key,arg);
			}
			
		}
		public void MousePress(Action<MouseButtons> arg){
			AllMouseevent=arg;
		}
		public void MouseHold(MouseButtons key,Action arg){
			if(_Mouseevent_hold_change.ContainsKey(key)){
				_Mouseevent_hold_change.Remove(key);
			   	_Mouseevent_hold_change.Add(key,arg);
			}else{
				_Mouseevent_hold_change.Add(key,arg);
			}
			
		}
	}
}
