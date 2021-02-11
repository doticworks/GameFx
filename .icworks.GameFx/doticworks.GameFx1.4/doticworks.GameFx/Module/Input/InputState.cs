/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2021/2/11
 * 时间: 21:39
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using SharpDX.DirectInput;
namespace doticworks.GameFx.Module.Input
{
	/// <summary>
	/// Description of InputArg.
	/// </summary>
	public struct InputState
	{
		public InputState(int x,int y,int z,bool[] b,System.Collections.Generic.List<Key> p){
			MouseX=x;MouseY=y;Whell=z;buttons=b;pressedkey=p;
		}
		public int MouseX;
		public int MouseY;
		public int Whell;
		public bool[] buttons;
		
		public System.Collections.Generic.List<Key> pressedkey;
	}
}
