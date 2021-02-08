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
using St=doticworks.GameFx.Helper.StopTimer;
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
					GameObject earth = PrefabGameObject.NodeGameObject;
					
				}
				,loaddone:()=>
				{
				//	gw.LoadGame();
				});
			                                            
		}
		void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
			Win32.Exit();
		}
		void GameBox1Click(object sender, EventArgs e)
		{
		//	gameBox1.gameworld.StartGame();
		}
		void MainFormShown(object sender, EventArgs e)
		{
			Clocker._.TimerDelay(200, () =>
			{
				gameBox1.gameworld.StartGame();
			});
		}
		
	}
}
