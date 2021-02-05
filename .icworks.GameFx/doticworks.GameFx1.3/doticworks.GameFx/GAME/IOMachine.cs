/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/120
 * 时间: 21:49
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using G=doticworks.GameFx.GFX;
namespace doticworks.GameFx.GAME
{
	/// <summary>
	/// Description of IOMachine.
	/// </summary>
	public partial class IOMachine
	{
		public IOMachine(Control gameWindow,G.RenderMode rm)
		{
			_gamewindow=gameWindow;
			_gamewindow.KeyDown+=I_KeyDown;
			_gamewindow.KeyUp+=I_KeyUp;
			_trace=new Thread(()=>{Trace();});
			_trace.SetApartmentState(ApartmentState.STA);
			_trace.IsBackground=true;
			_debugtrace=new Thread(()=>{TraceDebug();});
			_debugtrace.IsBackground=true;
			render=new G.Render(gameWindow.Handle,1,1,rm);
			_inputMap=new InputMap();
			
			rendermode=rm;
			iomdatalayer=new G.LayerNode(999999);
			render.root.Add("iomdatalayer",iomdatalayer);
			
//			DinputInit();
		}
		
		
		void _gamewindowupdated(){
			G.LayerNode temp;
			temp=render.root;
			G.Render rdtemp=render;
			IntPtr hant=(IntPtr)0;int gw=1;int gh=2;
			_gamewindow.Invoke(new MethodInvoker(()=>{hant=_gamewindow.Handle;gw=_gamewindow.Width;if(FullScreen){gh=_gamewindow.Height;}else{gh=_gamewindow.Height-30;}}));
			if(!locksize){
				render=new G.Render(hant,gw,gh,rendermode);
			}else{
				render=new G.Render(hant,lockw,lockh,rendermode);
			}
			render.root=temp;
			rdtemp.Dispose();
		}
		void gamewindowupdated(){gamewndneedupdate=true;}
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
             	_gamewindow.SizeChanged+=(s,e)=>{gamewindowupdated();};
             	_gamewindow.MouseMove+=I_MouseMove;
             	_gamewindow.MouseDown+=I_MouseDown;
             	_gamewindow.MouseUp+=I_MouseUp;
			 }));
			gamewindowupdated();
			isworking=true;
			_trace.Start();
			if(DebugMode){
				try{_debugtrace.Start();}catch{}}
		}
		public void EndGame(){
			isworking=false;
			_trace.Abort();
			if(DebugMode){
				try{_debugtrace.Abort();}catch{}}
		//	gamewindowupdated();
			
		}
		public void Task(Action act){
			new Thread(()=>act()).Start();
		}
	}
}
