/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/12/2
 * 时间: 17:16
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using doticworks.GameFx.COMMON;
namespace doticworks.GameFx.GAME
{
	/// <summary>
	/// Description of Canvas.
	/// </summary>
	public partial class Canvas
	{
		public void Rect(int x,int y,int w,int h,int linewidth,Color c,float rotate,Point rotatepoint){
			g.TranslateTransform(x+rotatepoint.X,y+rotatepoint.Y);
			g.RotateTransform(rotate);
			g.DrawRectangle(new Pen(c,linewidth),-rotatepoint.X,-rotatepoint.Y,w,h);
			g.ResetTransform();
		}
		public void Rect(int x,int y,int w,int h,int linewidth,Color c,float rotate){
			g.TranslateTransform(x+w/2,y+h/2);
			g.RotateTransform(rotate);
			g.DrawRectangle(new Pen(c,linewidth),-w/2,-h/2,w,h);
			g.ResetTransform();
		}
		public void Rect(int x,int y,int w,int h,Color c){
			g.DrawRectangle(new Pen(c,1),x,y,w,h);
		}
		public void Rect(int x,int y,int w,int h,int linewidth,Color c){
			g.DrawRectangle(new Pen(c,linewidth),x,y,w,h);
		}
		public void RectFill(int x,int y,int w,int h,int linewidth,Color c,float rotate,Point rotatepoint){
			g.TranslateTransform(x+rotatepoint.X,y+rotatepoint.Y);
			g.RotateTransform(rotate);
			g.FillRectangle(new SolidBrush(c),-rotatepoint.X,-rotatepoint.Y,w,h);
			g.ResetTransform();
		}
		public void RectFill(int x,int y,int w,int h,int linewidth,Color c,float rotate){
			g.TranslateTransform(x+w/2,y+h/2);
			g.RotateTransform(rotate);
			g.FillRectangle(new SolidBrush(c),-w/2,-h/2,w,h);
			g.ResetTransform();
		}
		public void RectFill(int x,int y,int w,int h,Color c){
			g.FillRectangle(new SolidBrush(c),x,y,w,h);
		}
		public void RectFill(int x,int y,int w,int h,int linewidth,Color c){
			g.FillRectangle(new SolidBrush(c),x,y,w,h);
		}
	}
}
