/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2020/11/7
 * 时间: 21:09
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using doticworks.GameFx;
namespace Temp1
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
		doticworks.GameFx.IOManager giom;
		doticworks.GameFx.Assetor astor;
		public int num = 0;
		void MainFormShown(object sender, EventArgs e)
		{
			giom=new doticworks.GameFx.IOManager(this);
			astor=new Assetor(this.
			giom.Input.KeyPress(Keys.Space, ()=> {
				num += 5;
			});
			giom.Input.KeyPress((arg)=>{
			num+= 1;
			});
			giom.Draw((g)=>{
			g.g.DrawString("score"+num, this.Font,new SolidBrush(Color.Black), 0, 0);
			g.Text("score"+num,30F,Color.Blue,0,5);
			});
		
			giom.StartGame();
		}
	}
}
