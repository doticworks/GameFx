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
using doticworks.GameFx.Module.Clock;
using md= doticworks.GameFx.Module;
using St=doticworks.GameFx.Helper.StopTimer;
using doticworks.GameFx.Common;
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
			gameBox1.GameBoxLoad(
				load:(world)=>{
					
				//	world.MaxFps=1;//
					
				//	md.Sound.AudioDevice.Default.Cooper(Handle);
					PrefabGameObject.BackGround.Clone(world.root);
					GameObject earth = PrefabGameObject.NormalGameObject.Clone(world.root);
					earth.Tag="Earth";
					earth.transform.Position=new Vector2(250,500);
					earth.components.GetComponent<ComRenderNormal>().paint=(ir)=>{
					//	ir._Rectangle_Fill(-3,-18,6,18,0.4f,0.5f,0.5f,1);
						ir._Circle_Fill(0,0,100,0.1f,0.1f,1f,1);//ir._Circle_Fill(50,50,50,0.3f,0.1f,0.7f,1);
						ir._Text(0,0,world.CanFps.ToString(),10,0.3f,0.7f,0.5f,1);
					};
					GameObject moonmover=PrefabGameObject.NodeGameObject.Clone(earth);
					GameObject moon=PrefabGameObject.DrawGameObject.Clone(moonmover);
					moonmover.Tag="MoonHx";
					moon.Tag="Moon";
					
					
					moon.transform.Position=new Vector2(150,0);
					moon.components.DoComponents<ComRenderNormal>(crn=>{crn.paint=ir=>{ir._Circle_Fill(0,0,15,0.7f,0.6f,0.4f,1);};});
					
					ComEvent ce=new ComEvent();
					ce.OnUpdate=f=>{moonmover.transform.Theta+=0.005f;};
					moonmover.components.AddComponent(ce);
					
					GameObject hamover=moonmover.Clone(moon);
					hamover.components.GetComponent<ComEvent>().OnUpdate=f=>{hamover.transform.Theta+=0.01f;};
					hamover.GetChilds()[0].transform.Position=new Vector2(30,0);
					hamover.GetChilds()[0].components.DoComponents<ComRenderNormal>(crn=>{crn.paint=ir=>{ir._Circle_Fill(0,0,5,0.4f,0.6f,0.4f,1);};});
				//	GameObject ha=moon.Clone();
			//		ha.transform.Position=new Vector2(15,0);
			//		ha.components.DoComponents<ComRenderNormal>(crn=>{crn.paint=ir=>{ir._Circle_Fill(0,0,4,0.7f,0.6f,0.4f,1);};});
					
					
					earth.components.DoComponents<ComInput>((ci)=>{
                    	ci.MouseMove=(v,z)=>{
//		            		Terminal.WF("{0}\r\n",(v-earth.transform.Position).Normalize().ToString());
		            		if((v-earth.transform.Position).Length()>15){
		            			earth.transform.Position+=8*((v-earth.transform.Position).Normalize());}
                    	};
        				ci.KeyDown=(k)=>{
                    	//	Terminal.WF("{0}\r\n",k.ToString());
                    		if(k==Keys.Space){
                    			earth.transform.Theta+=0.01f;
                    		}
				    	};
                    });
				
				
			/*		GameObject moon = PrefabGameObject.NormalGameObject.Clone(earth);
					moon.Tag="Moon";
					moon.transform.Position=new Vector2(70,0);
					Clocker._.TimerStart("moonmove",25,()=>{
					                     //	moon.transform.Position=new Vector2((float)(moon.transform.Position.Angle+Math.PI/60),moon.transform.Position.Length(),0);;
					     //                earth.transform.Theta+=0.1f;
					                     });
					moon.components.GetComponent<ComRenderNormal>().paint=(ir)=>{
					//	ir._Rectangle_Fill(-3,-18,6,18,0.4f,0.5f,0.5f,1);
						ir._Circle_Fill(0,0,10,0.7f,0.7f,1f,1);//ir._Circle_Fill(50,50,50,0.3f,0.1f,0.7f,1);
						};*/
					
				}
				,loaddone: () =>
				Clocker._.TimerDelay(100, () => {
				gameBox1.gameworld.StartGame();
			}));
			                                            
		}
		void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
			Win32.Exit();
		}
		void GameBox1Click(object sender, EventArgs e)
		{
			gameBox1.gameworld.StartGame();
		}
		void MainFormShown(object sender, EventArgs e)
		{
			
		}
		
	}
}
