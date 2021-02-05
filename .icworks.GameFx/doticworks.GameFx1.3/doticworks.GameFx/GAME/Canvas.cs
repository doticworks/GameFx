/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/120
 * 时间: 21:50
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using doticworks.GameFx.IO;
namespace doticworks.GameFx.GAME
{
	/// <summary>
	/// Description of Canvas.
	/// </summary>
	public partial class Canvas
	{
		public Canvas(int w,int h,float anitalias)
		{
			try{
				AntiAlias=anitalias;
				_bmp=new Bitmap((int)(w*anitalias),(int)(h*anitalias));}catch{_bmp=new Bitmap(1,1);}
			g=System.Drawing.Graphics.FromImage(_bmp);
			g.SmoothingMode=System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			Draw=(c)=>g.Clear(Color.Black);
			IOMdatalayer=(c)=>{};
			GraphicsPath gp=new GraphicsPath();
		//	gp.AddRectangle(new RectangleF(0,0,w,h));
		//	gp.Reverse();
			g.ExcludeClip(new Region(gp));
			g.ScaleTransform(AntiAlias,AntiAlias);
		}
		public float AntiAlias=1;
		public Bitmap _bmp;
		public System.Drawing.Graphics g;
		
		public Action<Canvas> Draw;
		public Action<Canvas> IOMdatalayer;//show some iomachine debug datas
		public virtual Bitmap OutImage{
			get{
				g.Clear(Color.Transparent);
				
				Draw(this);
				IOMdatalayer(this);
				
				return _bmp;
			}
		}
	}
}
