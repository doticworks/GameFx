/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/11/21
 * 时间: 9:14
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using doticworks.GameFx.COMMON;
namespace doticworks.GameFx.GAME
{
	/// <summary>
	/// Description of TexturePainter.
	/// </summary>
	public class TextPainter:Painter
	{
		public override bool Paint(Graphics g)
		{
			try{
				g.TranslateTransform(x+RotateTransform.X,y+RotateTransform.Y);
				g.RotateTransform(Rotate);
				int dx=-RotateTransform.X;
				int dy=-RotateTransform.Y;
				g.DrawString(Text,new System.Drawing.Font(Font, Size, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))),new SolidBrush(Color),dx,dy);
				g.ResetTransform();
				return true;
			}catch{return false;}
			
		}
		public string Text;
		public Color Color;
		public string Font="微软雅黑";
		public float Size=9f;
		
		public static TextPainter New(int x,int y,Color c,float size){
			TextPainter tp=new TextPainter();
			tp.x=x;
			tp.y=y;
			tp.Color=c;
			tp.Size=size;
			return tp;
		}
	}
}
