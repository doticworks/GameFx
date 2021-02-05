/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2020/11/21
 * 时间: 20:32
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Windows.Forms;
using doticworks.GameFx;
namespace test
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			GameFxRuntime.Load();
			Application.Run(new MainForm());
		}
		
	}
}
