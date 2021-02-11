/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2021/2/4
 * 时间: Go home day！ 10:29
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using doticworks.GameFx;
using doticworks.GameFx.Game;

namespace Hierarchy
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			main=new tab_main();
			unc= new tab_unconnect();
			main.Dock=DockStyle.Fill;
			unc.Dock=DockStyle.Fill;
			unc.Parent=this;
			extensioninit();
			Text="Hierarchy - Unconnected to GameFx";
		}

		private bool eventgameworldreceived = false;
		private GameWorld gw;
		void extensioninit()
		{
			Extension.ExEvent += (s) => {
				if (s == "EVENT_GAMEWORLD_LOAD")
				{
					eventgameworldreceived = true;
				}
			};
		}
		
		tab_main main;
		tab_unconnect unc;
		void MainFormShown(object sender, EventArgs e)
		{
			
			if (eventgameworldreceived)
			{
				gw = Extension.Invoke_("GF_GAMEWORLD", null) as GameWorld;
					Invoke(new MethodInvoker(() => { unc.Parent = null;
						main.Parent = this;
						main.gw = gw;
						main.settitle=(s)=>{Text=s;};
						main.settitle("Hierarchy - Connected to GameFx");
					}));
			}
			else{
				Extension.ExEvent += (s) => {
					if (s == "EVENT_GAMEWORLD_LOAD")
					{
						gw = Extension.Invoke_("GF_GAMEWORLD", null) as GameWorld;
						Invoke(new MethodInvoker(() => { unc.Parent = null;
							main.Parent = this;
							main.gw = gw;
							main.settitle=(r)=>{Text=r;};
							main.settitle("Hierarchy - Connected to GameFx");
						}));
					}
				};
			}
			
		}
	}
}
