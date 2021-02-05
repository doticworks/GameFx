/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/12/22
 * 时间: 9:22
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using doticworks.GameFx;
using doticworks.GameFx.GAME;
using doticworks.GameFx.GAME.WORLD;
using doticworks.GameFx.GAME.WORLD.Competions;
using G= doticworks.GameFx.GFX;
using doticworks.GameFx.WIN;
using System.Collections.Generic;
namespace test
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		IOMachine iom;
//		G.Render rd;
		G.Layer l2=new G.Layer(5);
		List<float> xy=new List<float>();
		List<float[]> geos=new List<float[]>();
		int mousestate=0;//hold 1
		float the=0;
		GameWorld gw;
		void MainFormShown(object sender, EventArgs e)
		{
			Hello.GameFx还是可以的();
//			MessageBox.Show(InputBox.Show("Type something!"));
			iom=new IOMachine(this,G.RenderMode.CPU);
			iom.Task(()=>{});
//			rd=new G.Render(Handle,Width,Height,G.RenderMode.CPU);
//			iom.LockSize(800,600);
			gw=new GameWorld();
			iom.Render.root.Active=true;
			iom.Render.root.Add("L2",l2);
//			l2.Active=false;
			iom.Render.root.Add("GW",gw.worldLayer);
			gw.root.AddChild(new MyPlayer());
			iom.Render.root.paint=rdx=>{
//				MessageBox.Show("painted");
				rdx._Clear(0,0,0);
//				for(int i=0;i<=299999;i++){
//					try{rdx._Rectangle_Fill(0,0,5,5,0.5f,0.5f,0.5f,1f);}catch{}}
			};
			l2.paint=rdx=>{
				rdx._Text(5,5,iom.CanFps.ToString()+" "+the.ToString()+" "+STR.STR_().s,20,0.2f,0.4f,0.6f,1);
//				rdx._Transform(new doticworks.GameFx.COMMON.Transform(iom.InputMap.Mousex,iom.InputMap.Mousey,the,1,1));
//				rdx._Text(300,50,"F1:SetFps",20,0.2f,0.4f,0.6f,1);
//				rdx._Text(300,70,"F2:SetDebug",20,0.2f,0.4f,0.6f,1);
//				rdx._Rectangle_Fill(250,250,100,100,0.5f,0.5f,0.5f,1f);
//				rdx._Transform(new doticworks.GameFx.COMMON.Transform(0,0,0,1,1));
//				rdx._Polygon_Fill(0.4f,1,0.3f,0.8f,100,100,100,200,200,the*100,iom.InputMap.Mousex,iom.InputMap.Mousey);
				rdx._Polygon_Fill(0.4f,1,0.3f,0.4f,xy.ToArray());
				foreach(var item in geos){
					rdx._Polygon_Fill(0.4f,1,0.3f,0.4f,item);
				}
			};
			iom.InputMap.KeyPress(Keys.F1,()=>{
			                      	STR.STR_().Add("fa");
//			                      	mtfun(s1:"efg");
//			                    	int t=40;
//									try{t=int.Parse(InputBox.Show("MaxFps Setting"));}catch{};
//									iom.MaxFps=t;
			                      });
			iom.InputMap.KeyPress(Keys.F2,()=>{
			                      	iom.DebugMode=!iom.DebugMode;
			                      });
//			iom.InputMap.MousePress(MouseButtons.Left,()=>{
//			                        	l2.Active=!l2.Active;
//			                        });
			iom.InputMap.MousePress(MouseButtons.Right,()=>{
			                        	iom.FullScreen=!iom.FullScreen;
			                        });
			
			iom.Update=()=>{
			                        	the+=1f/180f;
			                        	if(iom.InputMap.MouseDown(MouseButtons.Left)){
			                        		if(mousestate==0){
			                        			mousestate=1;
			                        			
			                        		}
			                        	}else{
			                        		if(mousestate==1){
			                        			mousestate=0;
			                        			geos.Add(xy.ToArray());
			                        			xy.Clear();
			                        		}
			                        	}
			                        	if(mousestate==1){
			                        		xy.Add(iom.InputMap.Mousex);
			                        		xy.Add(iom.InputMap.Mousey);
			                        	}
			                        	
//			                        	GC.Collect();
//			                        	xt.Enqueue(iom.InputMap.Mousex);yt.Enqueue(iom.InputMap.Mousey);
//			                        	if(xt.Count>=500){xt.Dequeue();yt.Dequeue();}
			                        };
//			iom.DebugMode=true;
			iom.StartGame();
			
		}
		void mtfun(string s1="s1 ",string s2="s2 ",string s3="s3 "){
			MessageBox.Show(s1+s2+s3);
		}
		public class MyPlayer:doticworks.GameFx.GAME.WORLD.GameObjectControl{
			public MyPlayer()
			{
				transform=new doticworks.GameFx.COMMON.Transform(100,100,0,1,1);
			}
			public override void Draw(G.Render rd)
			{
				base.Draw(rd);
				rd._Circle_Fill(-5,-5,5,0.8f,0.6f,0.33f,-0.6f);
			}
		}
		
	}public class STR{
			public string s;
			public void Add(string a){
				s+=a;
			}
			static readonly Lazy<STR> str=new Lazy<STR>(()=>new STR());
			private STR(){}
			public static STR STR_(){
				return str.Value;
			}
		}
}
