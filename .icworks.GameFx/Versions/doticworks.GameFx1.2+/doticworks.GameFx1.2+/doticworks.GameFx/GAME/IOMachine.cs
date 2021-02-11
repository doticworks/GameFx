/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/11/20
 * 时间: 21:49
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
namespace doticworks.GameFx.GAME
{
	/// <summary>
	/// Description of IOMachine.
	/// </summary>
	public partial class IOMachine
	{
		public IOMachine(Form gameWindow)
		{
			_gamewindow=gameWindow;
			_gamewindow.KeyDown+=I_KeyDown;
			_gamewindow.KeyUp+=I_KeyUp;
			_trace=new Thread(()=>{Trace();});
			_trace.IsBackground=true;
			_debugtrace=new Thread(()=>{TraceDebug();});
			_debugtrace.IsBackground=true;
			_canvas=new Canvas(1,1);
			_inputMap=new InputMap();
			_canvas.IOMdatalayer=(c)=>{
				if(DebugMode){
				/*	c.Text("FPS "+NowFps+"("+CanFps+")"+
					       "\r\nINPUT	"+TickInput+
					       "\r\nUPDAT	"+TickUpdateFunc+
					       "\r\nDRAW	"+TickDraw+
					       "\r\nSHOW	"+TickToScreen+
					       "\r\nMLOC	"+InputMap.Mousex+" "+InputMap.Mousey
					       ,TextPainter.New(15,15,Color.FromArgb(255,Color.Green),10f));*/
					c.Text(debugdatastr
					       ,TextPainter.New(15,15,Color.FromArgb(255,Color.Green),10f));
				}
			};
			AppDomain.CurrentDomain.UnhandledException +=(s,e)=>{
				MessageBox.Show((e.ExceptionObject as Exception).ToString(),"GameFx Crash Report");
			};
            Application.ThreadException +=(s,e)=>{
				MessageBox.Show((e.Exception).ToString(),"GameFx Crash Report");
			};
		}
		
		
		void gamewindowupdated(){
			Action<Canvas> temp;
			Action<Canvas> tempdebug;
			temp=_canvas.Draw;
			tempdebug=_canvas.IOMdatalayer;
			if(!locksize){
				_canvas=new Canvas(picbox.Size.Width,picbox.Size.Height);
			}else{
				_canvas=new Canvas(lockw,lockh);
			}
			_canvas.Draw=temp;
			_canvas.IOMdatalayer=tempdebug;
		}
		public void UnLockSize(){
			locksize=false;
			gamewindowupdated();
		}
		public void LockSize(int w,int h){
			locksize=true;
			lockw=w;
			lockh=h;
			gamewindowupdated();
		}
		public void StartGame(){
			_gamewindow.Invoke(new MethodInvoker(()=>{
             	picbox=new PictureBox();
             	picbox.Parent=_gamewindow;
             	picbox.Dock=DockStyle.Fill;
				picbox.SizeMode=PictureBoxSizeMode.StretchImage;
             	picbox.SendToBack();
             	_gamewindow.SizeChanged+=(s,e)=>{gamewindowupdated();};
             	picbox.MouseMove+=I_MouseMove;
             	picbox.MouseDown+=I_MouseDown;
             	picbox.MouseUp+=I_MouseUp;
			 }));
			gamewindowupdated();
			isworking=true;
			_trace.Start();
			_debugtrace.Start();
		}
		public void EndGame(){
			isworking=false;
			_trace.Abort();
			_debugtrace.Abort();
			_gamewindow.Invoke(new MethodInvoker(()=>{
			   	picbox.Parent=null;;
			   	picbox.Dispose();
			 }));
		//	gamewindowupdated();
			
		}
	}
}
