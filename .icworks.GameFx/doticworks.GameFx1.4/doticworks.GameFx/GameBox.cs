/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2021/1/15
 * 时间: 17:11
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using doticworks.GameFx.Game;
using System.Threading;
namespace doticworks.GameFx
{
	/// <summary>
	/// Description of GameBox.
	/// </summary>
	public partial class GameBox : UserControl
	{
		public GameBox(){
			InitializeComponent();
		}
		private bool GameStarted = false;
		public void Invoker(Action arg){this.Invoke(new MethodInvoker(()=>{arg();}));}
		//Bitmap splash=null,ImageLayout imagelayout=ImageLayout.Center,
		public void GameBoxLoad(Action<GameWorld> load=null,Action loaddone=null)
		{
			new Thread(()=>{
			           	Thread.Sleep(100);
			gameworld=new GameWorld();
			IntPtr h=IntPtr.Zero;
			Invoker(()=>{h=Handle;});
			gameworld.TarHandle=h;
			if(this.BackgroundImage==null){
				Invoker(()=>{
				BackgroundImage=new Bitmap(doticworks.GameFx.IO.Assetor.QuickGetS(typeof(GameBox),"doticworks.GameFx.Asset.logo1.png"));
				BackgroundImageLayout=ImageLayout.Center;
				        });}
			if(load!=null){
				gameworld.Loader=(world)=>{
					load(world);
					
					
				};
//				gameworld.LoadGame();
			}
			}).Start();
			if(loaddone!=null){
            	loaddone();
            }
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			if(!GameStarted){
				base.OnPaintBackground(e);}
		}
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			if(!GameStarted){
				base.OnPaintBackground(e);}
		}

		public GameWorld gameworld;
		
		
		public void StartGame(){
			gameworld.StartGame();
			GameStarted=true;
		}
		void GameBoxSizeChanged(object sender, EventArgs e)
		{
			if(gameworld!=null){
				gameworld.ClientResize_(Width,Height);}
		}
	}
}
