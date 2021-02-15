/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2021/2/15
 * 时间: 20:48
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using doticworks.GameFx;
using doticworks.GameFx.Module.Clock;
namespace Learn1.__1
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//gamefx4的大概样子
			//启动画面在窗口设计器页面对background设置 在游戏未开始前会显示
			//启动页的背景色也可调
			
			InitializeComponent();
			gamebox1.GameBoxLoad(
				load:(world)=>{
					new GameInit(world);//搞成个函数 好看点
				}
				,loaddone: () =>
				Clocker._.TimerDelay(100, () => {//在加载结束后马上启动游戏
				gamebox1.gameworld.StartGame();
			}));
		}
	}
}
