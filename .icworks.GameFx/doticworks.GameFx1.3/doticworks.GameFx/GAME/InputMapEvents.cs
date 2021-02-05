/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2020/121
 * 时间: 20:46
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
		Dictionary<Keys,Action> _keyevents_press=new Dictionary<Keys, Action>();
		Dictionary<Keys,Action> _keyevent_press_change=new Dictionary<Keys, Action>();
		Dictionary<Keys,Action> _keyevents_hold=new Dictionary<Keys, Action>();
		Dictionary<Keys,Action> _keyevent_hold_change=new Dictionary<Keys, Action>();
		Action<Keys> Allkeyevent=(a)=>{};
		
		IEnumerator<Keys> enumt;
		public void I_OnUpdate(){
			updatekeypresschange();
			updatekeyholdchange();
			try{
			foreach(var item in _keydown){
				Allkeyevent(item);
				if(_keyevents_press.ContainsKey(item)){
				   	_keyevents_press[item]();
				}
				}}catch{}
			_keydown.Clear();
			try{
			foreach(var item in _holdedkeys){
				if(_keyevents_hold.ContainsKey(item)){
				   	_keyevents_hold[item]();
				}
			}}catch{}
			MouseMove();
			updatemousepresschange();
			updatemouseholdchange();
			try{
			foreach(var item in _mousedown){
				AllMouseevent(item);
				if(_Mouseevents_press.ContainsKey(item)){
				   	_Mouseevents_press[item]();
				}
			}}catch{}
			_mousedown.Clear();
			try{
			foreach(var item in _holdedmouse){
				if(_Mouseevents_hold.ContainsKey(item)){
				   	_Mouseevents_hold[item]();
				}
			}}catch{}
		}
		
		
		void updatekeypresschange(){
			lock(_keyevent_press_change){
			foreach(var item in _keyevent_press_change){
				if(_keyevents_press.ContainsKey(item.Key)){
					_keyevents_press.Remove(item.Key);
					_keyevents_press.Add(item.Key,item.Value);
				}else{
					_keyevents_press.Add(item.Key,item.Value);
				}
			}}
		}
		void updatekeyholdchange(){
			lock(_keyevent_press_change){
			foreach(var item in _keyevent_hold_change){
				if(_keyevents_hold.ContainsKey(item.Key)){
					_keyevents_hold.Remove(item.Key);
					_keyevents_hold.Add(item.Key,item.Value);
				}else{
					_keyevents_hold.Add(item.Key,item.Value);
					}}
			}
		}
		void updatemousepresschange(){
			lock(_keyevent_press_change){
			foreach(var item in _Mouseevent_press_change){
				if(_Mouseevents_press.ContainsKey(item.Key)){
					_Mouseevents_press.Remove(item.Key);
					_Mouseevents_press.Add(item.Key,item.Value);
				}else{
					_Mouseevents_press.Add(item.Key,item.Value);
				}
					}}
		}
		void updatemouseholdchange(){
			lock(_keyevent_press_change){
			foreach(var item in _Mouseevent_hold_change){
				if(_Mouseevents_hold.ContainsKey(item.Key)){
					_Mouseevents_hold.Remove(item.Key);
					_Mouseevents_hold.Add(item.Key,item.Value);
				}else{
					_Mouseevents_hold.Add(item.Key,item.Value);
				}
						}}
		}
	}
}
