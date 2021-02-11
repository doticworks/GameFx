/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2021/1/15
 * 时间: 17:12
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Threading;
using doticworks.GameFx.Game;
using doticworks.GameFx.Module.Gfx;using doticworks.GameFx.Module;
using doticworks.GameFx.Game.Components;
namespace doticworks.GameFx.Game
{
	/// <summary>
	/// Description of GameWorld.
	/// </summary>
	public partial class GameWorld
	{
		public GameWorld()
		{
//			root=PrefabGameObject.NodeGameObject.Create(null);
		}

		public void LoadGame()
		{
			bool loadmonitorflag=false;
			Module.Clock.Clocker._.TimerDelay(1000,()=>{if(!loadmonitorflag){
          		Terminal.WF("<R>\r\nWARNING: loader thread no response after 1000 ms!!\r\nthere are some error\r\n<W>We will try restart it after 1000ms\r\n");
          		Module.Clock.Clocker._.TimerDelay(1000,()=>{this.StartGame();},()=>{return !loadmonitorflag;});
			                                  	}});
			presenter = new Presenter(TarHandle, root);
			ia=new doticworks.GameFx.Module.Input.InputAnalyzer(out inputUpdate);
			root = PrefabGameObject.GetRoot(presenter.swapbuffer, (w, h) => presenter.OnResize(TarHandle, w, h));
			root.components.GetComponent<ComRooter>().gw = this;
			root.Tag = "GameWorld Root";
			presenter.InitRoot(root);
			Loader(this);
			trace = new Thread(() => Trace());
			trace.IsBackground = true;
			trace.SetApartmentState(ApartmentState.STA);
			ClientResize+=(w,h)=>{
			root.components.RI_ComNode.TreeInvoke(after:(go)=>{
				go.components.DoComponents<ComRenderKeyNode>((crkn) =>
				{
					crkn.OnResizeBuffer(w, h);
				});
			});};
			
		//	Invoke(new MethodInvoker(() =>
		//	{
			Extension.Regist_("GF_GAMEWORLD", (o) => { return this; });
			Extension.DoEvent("EVENT_GAMEWORLD_LOAD");//Terminal.WF("DOEVENT");
		//	}));
			unloaded=false;
			loadmonitorflag=true;
		}
		bool unloaded=true;
		public int MaxFps=40;
		public int NowFps;
		public int CanFps;
		
		public IntPtr TarHandle=IntPtr.Zero;
		public Presenter presenter;
		
		public Module.Input.InputAnalyzer ia;
		Action inputUpdate;
		
		public Action<GameWorld> Loader;
		public GameObject root;
		private Thread trace;
		
		public void StartGame(){
			if(unloaded){unloaded=false;LoadGame();}
			if (!isworking)
			{
				isworking = true;
				trace.Start();
			}
		}
		public void EndGame()
		{
			if(isworking)
			{
				isworking = false;
				trace.Suspend();}
		}
	}
}
