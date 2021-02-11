/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/12/26
 * 时间: 21:43
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace doticworks.GameFx
{
	/// <summary>
	/// Description of Hello.
	/// </summary>
	public class Hello
	{
		public static void GameFx还是可以的(){}
		public static string Note(){
			string t="Undone:\r\n";
			t+="transform.overlay.sx/sy\r\n";
			
			
			t+="\r\nNotes:\r\n";
			t+="Gfx:IRender as universal rendering interface\r\n";
			t+="Render:draw in windows under IRender Standard\r\n";
			t+="Render2D:only rendertargetdraw when d3d unsupport\r\n";
			t+="\r\n";
			t+="InputState as universal inputing interface";
			t+="";
			t+="";
			return t;
		}
	}
}
