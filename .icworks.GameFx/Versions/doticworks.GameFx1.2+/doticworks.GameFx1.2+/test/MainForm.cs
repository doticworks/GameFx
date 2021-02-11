/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2020/11/21
 * 时间: 20:32
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using doticworks.GameFx.GAME;
using doticworks.GameFx.IO;
using doticworks.GameFx.COMMON;
using SharpDX;using SharpDX.XInput;
using SharpDX.Windows;
using SharpDX.Direct2D1;
using SharpDX.RawInput;
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
			RenderForm rf=new RenderForm("faf");
			rf.IsFullscreen=true;
			rf.Show();
			SharpDX.
		}
		IOMachine m;
		Assetor asset;
		float ang;
		int x;int y;
		void MainFormShown(object sender, EventArgs e)
		{
			m=new IOMachine(this);
	//		m.LockSize(500,500);
			TextPainter textp=new TextPainter();
			textp.x=20;textp.y=20;textp.Size=10F;textp.Color=Color.Black;
			ShaderLayer sl=new ShaderLayer(500,500,5f,5f);
			Canvas tempc=new Canvas(500,500);
			tempc.Draw=(c)=>{
				c.g.Clear(Color.Transparent);
				c.Text("GameFx",textp);
			};
			
			m.DebugMode=true;
			Bitmap temp=tempc.OutImage;
			LightSource ls=new LightSource();
			ls.col=Color.FromArgb(5,Color.Blue);
			ls.lightlength=300;
			ls.pos=new Point(150,150);
			
			m.Canvas.Draw=(c)=>{
				c.g.Clear(Color.Black);
		//		c.Texture(new Texture2D(sl.output(temp,new LightSource[]{ls})),PrePainter.TexturePainter(0,0));
				c.Rect(x,y,50,50,10,Color.Red,ang);
				c.RectFill(x+50,y+50,50,50,5,Color.Red,ang,new Point(50,0));
			};
			m.DebugMode=true;
			m.Update=()=>{ang++;x=m.InputMap.Mousex-25;y=m.InputMap.Mousey-25;};
		//	m.StartGame();
		
		}
	}
}
