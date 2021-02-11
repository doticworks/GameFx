/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/11/22
 * 时间: 17:14
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
	public class TexturePainter:Painter
	{
		public override bool Paint(Graphics g)
		{try{
				if(w!=0&&h!=0){
					g.DrawImage(_texture.Paint(),x,y,w,h);
				}else{
					g.DrawImage(_texture.Paint(),x,y);
				}
				return true;}catch{return false;}
		}
		public Texture _texture;
		public int w=0;
		public int h=0;
	}
}
