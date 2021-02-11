/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2020/11/21
 * 时间: 20:50
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
		public bool KeyDown(Keys k){
			return _holdedkeys.Contains(k);
		}
		public void KeyPress(Keys key,Action arg){
			if(_keyevent_press_change.ContainsKey(key)){
				_keyevent_press_change.Remove(key);
			   	_keyevent_press_change.Add(key,arg);
			}else{
				_keyevent_press_change.Add(key,arg);
			}
			
		}
		public void KeyPress(Action<Keys> arg){
			Allkeyevent=arg;
		}
		public void KeyHold(Keys key,Action arg){
			if(_keyevent_hold_change.ContainsKey(key)){
				_keyevent_hold_change.Remove(key);
			   	_keyevent_hold_change.Add(key,arg);
			}else{
				_keyevent_hold_change.Add(key,arg);
			}
			
		}
	}
}
