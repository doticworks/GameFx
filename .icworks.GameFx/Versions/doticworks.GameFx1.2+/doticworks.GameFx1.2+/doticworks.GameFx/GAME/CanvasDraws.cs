/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/11/21
 * 时间: 8:17
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using doticworks.GameFx.COMMON;
namespace doticworks.GameFx.GAME
{
	/// <summary>
	/// Description of Canvas.
	/// </summary>
	public partial class Canvas
	{
		public bool Texture(Texture t,TexturePainter p){
			p._texture=t;
			return p.Paint(g);
		}
		public void Canvasx(Canvas can,int x,int y){
			g.DrawImage(can.OutImage,x,y);
		}
		
		
		public bool Text(string s,TextPainter p){
			p.Text=s;
			return p.Paint(g);
		}
		public void Text(string str,int x,int y,float size,Color c,float rotate,Point rotatepoint){
			g.TranslateTransform(x+rotatepoint.X,y+rotatepoint.Y);
			g.RotateTransform(rotate);
			g.DrawString(str,new System.Drawing.Font("微软雅黑", size, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))),new SolidBrush(c),-rotatepoint.Y,-rotatepoint.Y);
			g.ResetTransform();
		}
		public void Text(string str,int x,int y,float size,Color c){
			g.DrawString(str,new System.Drawing.Font("微软雅黑", size, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))),new SolidBrush(c),x,y);
		}
	}
}
