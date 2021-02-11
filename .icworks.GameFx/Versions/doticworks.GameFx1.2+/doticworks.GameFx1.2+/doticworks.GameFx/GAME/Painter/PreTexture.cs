/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/11/22
 * 时间: 17:13
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
namespace doticworks.GameFx.GAME
{
	/// <summary>
	/// Description of PreTexture.
	/// </summary>
	public static class PrePainter
	{
		public static TexturePainter TexturePainter(int x,int y){
			TexturePainter tp=new TexturePainter();
			tp.x=x;tp.y=y;
			return tp;
		}
		public static TexturePainter TexturePainter(int x,int y,int w,int h){
			TexturePainter tp=new TexturePainter();
			tp.x=x;tp.y=y;tp.w=w;tp.h=h;
			return tp;
		}
		public static TextPainter TextPainter(int x,int y,float size,Color c){
			TextPainter tp=new TextPainter();
			tp.x=x;tp.y=y;tp.Size=size;tp.Color=c;
			return tp;
		}
		
	}
}
