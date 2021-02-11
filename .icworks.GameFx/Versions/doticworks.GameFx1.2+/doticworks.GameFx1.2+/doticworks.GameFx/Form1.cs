/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2020/12/12
 * 时间: 20:59
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using FarseerPhysics;
using SharpDX;
using SharpDX.Windows;
using SharpDX.Direct2D1;
using SharpDX.RawInput;
namespace doticworks.GameFx
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class Form1 : Form
	{
		public Form1()
			
		{SharpDX.Windows.RenderControl rc=new RenderControl();
			InitializeComponent();
			RenderForm rf=new RenderForm("faf");
			rf.Show();
		}
	}
}
