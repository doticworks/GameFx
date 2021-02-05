/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2021/1/16
 * 时间: 19:27
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using doticworks.GameFx;
using doticworks.GameFx.Game;
using doticworks.GameFx.Game.Components;
using doticworks.GameFx.Modules.Clock;

namespace Tester
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			if(doticworks.GameFx.Module.Gfx.GraphicsDevice.Default.SupportD2D){}
			gameBox1.GameBoxLoad(
				load:(world)=>{world.TarHandle=(IntPtr)Win32.WindowFromPoint(50,50);
					GameObject back= PrefabGameObject.NormalGameObject;
					back.Tag = "back";
					GameObject g= PrefabGameObject.NormalGameObject;
					g.components.AddComponent(new ComMotion());
				//	GameObject g2=PrefabGameObject.NormalGameObject;
					back.components.GetComponent<ComRenderNormal>().paint=(ir)=>{
						ir._Clear(0,0,0);
						ir._Text(0,0,gameBox1.gameworld.NowFps.ToString()+" "+gameBox1.gameworld.CanFps.ToString(),10,0,1,0,1);
						ir._Text(0,10,gameBox1.gameworld.DeltaTime.ToString(),10,0,1,0,1);
					};
					g.components.GetComponent<ComRenderNormal>().paint=(ir)=>{
						ir._Rectangle_Fill(-3,-18,6,18,0.4f,0.5f,0.5f,1);
						ir._Circle_Fill(0,0,10,0.5f,0.5f,0.5f,1);
						};
					g.Tag="g";
				/*	g2.components.GetComponent<ComRenderNormal>().paint=(ir)=>{ir._Rectangle_Fill(100,100,50,50,0.6f,0.1f,0.7f,1);};
					
					g2.Tag="g2";
					g.components.RI_ComNode_Add(g2);
					GameObject gcol= g.Clone();
					Terminal.InputBinding+=(s)=>{try{
							
							gcol.x=int.Parse(s);
						}catch{}};
				*/		
					
					
					
				//	gcol.x=300;
					g.x = 100;
					g.y = 100;
					Extension.Regist_("KEYPADM", (o) => { return g.components.GetComponent<ComMotion>();});
					world.root.components.RI_ComNode.Add(back);
					world.root.components.RI_ComNode_Add(g);
				//	world.root.components.RI_ComNode_Add(gcol);
				}
				,loaddone:()=>
				{
				//	gw.LoadGame();
				});
			                                            
		}
		GameWorld gw;
		void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
			Win32.Exit();
		}
		void GameBox1Click(object sender, EventArgs e)
		{
			gameBox1.StartGame();
		}
		void MainFormShown(object sender, EventArgs e)
		{
			Clocker._.TimerDelay(200,()=>{gameBox1.gameworld.StartGame();});
		}
		
	}
}
