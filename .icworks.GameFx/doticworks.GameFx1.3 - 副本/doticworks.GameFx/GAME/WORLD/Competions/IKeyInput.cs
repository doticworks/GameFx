/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/12/31
 * 时间: 9:38
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Windows.Forms;
namespace doticworks.GameFx.GAME.WORLD.Competions
{
	public interface IKeyInput
	{
		void KeyDown(Keys k);
		void KeyHold(Keys k);
	}
}
