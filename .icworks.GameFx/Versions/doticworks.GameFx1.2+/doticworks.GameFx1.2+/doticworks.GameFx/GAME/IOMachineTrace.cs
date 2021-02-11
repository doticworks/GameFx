/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2020/11/21
 * 时间: 21:05
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
namespace doticworks.GameFx.GAME
{
	/// <summary>
	/// Description of IOMachine.
	/// </summary>
	public partial class IOMachine
	{
		void Trace(){
			Stopwatch sw=new Stopwatch();
			Bitmap temp;
			while(isworking){
				sw.Start();
				_inputMap.I_OnUpdate();
					if(DebugMode){
						sw.Stop();
							TickInput=sw.ElapsedTicks;
							sw.Start();}
				Update();
					if(DebugMode){
						sw.Stop();
							TickUpdateFunc=sw.ElapsedTicks-TickInput;;
						sw.Start();}
				temp=_canvas.OutImage.Clone() as Bitmap;
			//	temp=new Bitmap(_canvas.OutImage);
					if(DebugMode){
						sw.Stop();
							TickDraw=sw.ElapsedTicks-TickInput-TickUpdateFunc;
							sw.Start();}
				_gamewindow.Invoke(new MethodInvoker(()=>{ picbox.Image=temp;}));
				sw.Stop();
					if(DebugMode){
						TickToScreen=sw.ElapsedTicks-TickInput-TickUpdateFunc-TickDraw;}
				
				int MaxTickTime=(int)(1000/MaxFps);
				float allms=(float)sw.ElapsedTicks/30000f;
				if(allms<MaxTickTime){
					Thread.Sleep((int)(MaxTickTime-allms));
				//	Thread.Sleep((int)(5));
					NowFps=MaxFps;
					CanFps=(int)(1000/allms);
				}else{
					NowFps=(int)(1000/allms);
					CanFps=(int)(1000/allms);
				}
				sw.Reset();
			}
		}
	}
}
