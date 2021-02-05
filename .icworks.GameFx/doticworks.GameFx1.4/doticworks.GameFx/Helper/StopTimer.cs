/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2021/1/30
 * 时间: 8:18
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Diagnostics;
namespace doticworks.GameFx.Helper
{
	/// <summary>
	/// Description of StopTimer.
	/// </summary>
	public class StopTimer
	{
		public StopTimer()
		{
			
		}
		public static void CheckTer(string str,Action arg){
			Stopwatch sw=new Stopwatch();
			sw.Start();
			arg();
			sw.Stop();
			Terminal.WF("\r\nStopTimer {0} {1} Ticks",str,sw.ElapsedTicks);
		}
		public static void CheckTer(Action arg){
			Stopwatch sw=new Stopwatch();
			sw.Start();
			arg();
			sw.Stop();
			Terminal.WF("\r\nStopTimer Res {0} Ticks",sw.ElapsedTicks);
		}
	}
}
