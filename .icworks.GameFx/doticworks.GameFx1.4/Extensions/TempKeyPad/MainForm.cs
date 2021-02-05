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
			Extension.ExEvent += (s) => {
				if (s == "EVENT_GAMEWORLD_LOAD")
				{
					cm=Extension.Invoke_("KEYPADM", null) as ComMotion;
					cm.a_friction = 200;
				}
			};
		}

		private ComMotion cm;
		void MainFormKeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.W:
				{
					cm.ay = -500;
					break;
				}
				case Keys.A:
				{
					cm.ax = -500;
					break;
				}
				case Keys.S:
				{
					cm.ay = 500;
					break;
				}
				case Keys.D:
				{
					cm.ax = 500;
					break;
				}
			}

		}
		void MainFormKeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.W:
				{
					cm.ay =0;
					break;
				}
				case Keys.A:
				{
					cm.ax = 0;
					break;
				}
				case Keys.S:
				{
					cm.ay =0;
					break;
				}
				case Keys.D:
				{
					cm.ax =0;
					break;
				}
			}
		}
	}
}
