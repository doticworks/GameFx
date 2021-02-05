/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2021/1/16
 * 时间: 19:27
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Windows.Forms;
using doticworks.GameFx;
namespace Tester
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
//			Terminal.Enable=false;
			Terminal.WF("Process start with {0}\r\n<W>Prepare to load...\r\n",args.Length==0?"<Y>no arguments":args[0]);
			doticworks.GameFx.GameFxRuntime.Load();
			Terminal.InputBinding+=(s)=>{if(s=="CLS"){Terminal.WF("<CLS>");}};
			Terminal.InputBinding+=(s)=>{if(s=="YYY"){Terminal.WF("<Y>eofnweoifnoseifhoiwefhoiwaejfoiwehois<W>eh"+s);}};
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
	}
}
