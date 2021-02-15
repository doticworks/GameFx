/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2021/2/4
 * 时间: 不要看我，还没回家 2:43
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using doticworks.GameFx;
using doticworks.GameFx.Game.Components;

namespace TempKeyPad
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			doticworks.GameFx.Module.Sound.AudioDevice.Default.Cooper(Handle);
		}

		private ComMotion cm;
		void MainFormKeyDown(object sender, KeyEventArgs e)
		{
		}
		void MainFormKeyUp(object sender, KeyEventArgs e)
		{
			
		}
	}
}
