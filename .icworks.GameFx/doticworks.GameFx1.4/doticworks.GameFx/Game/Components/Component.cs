/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2021/1/15
 * 时间: 17:26
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace doticworks.GameFx.Game.Components
{
	/// <summary>
	/// Description of Component.
	/// </summary>
	public class Component
	{
		public virtual void Load(ComponentModel model){
			
		}
		public virtual Component Copy(){
			throw new Exception("Undefined Component Copy Func!");
		}
		public GameObject Owner;
		public bool Enable=true;
	}
}
