/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/11/20
 * 时间: 21:56
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
	public class TexturePainterEx:TexturePainter
	{
		public override bool Paint(Graphics g)
		{
			g.TranslateTransform(x+RotateTransform.X,y+RotateTransform.Y);
			g.RotateTransform(Rotate);
			int dx=-RotateTransform.X;
			int dy=-RotateTransform.Y;
			bool drawed=false;
			try{
				if(w==0&&h==0){
					g.DrawImage(_texture.Paint(),dx,dy);drawed=true;
				}else{
					if(cutted&&stretched&&colormartixed&&!drawed){
						return false;
					}if(cutted&&stretched&&!colormartixed&&!drawed){
						g.DrawImage(_texture.Paint(),_stretch,_cut,GraphicsUnit.Pixel);drawed=true;
					}if(cutted&&!stretched&&colormartixed&&!drawed){
						return false;
					}if(cutted&&!stretched&&!colormartixed&&!drawed){
						g.DrawImage(_texture.Paint(),_cut,new Rectangle(dx,dy,w,h),GraphicsUnit.Pixel);drawed=true;
					}if(!cutted&&stretched&&colormartixed&&!drawed){
						return false;
					}if(!cutted&&stretched&&!colormartixed&&!drawed){
						g.DrawImage(_texture.Paint(),_stretch,new Rectangle(0,0,_texture.Paint().Width,_texture.Paint().Height),GraphicsUnit.Pixel);drawed=true;
					}if(!cutted&&!stretched&&colormartixed&&!drawed){
						return false;
					}if(!cutted&&!stretched&&!colormartixed&&!drawed){
						g.DrawImage(_texture.Paint(),(float)dx,(float)dy,(float)w,(float)h);drawed=true;
					}
				}
				g.ResetTransform();
				return drawed;
				
			}catch{return false;}
		}
		bool cutted=false;
		bool stretched=false;
		bool colormartixed=false;
		
		
		Rectangle _cut;
		public Rectangle Cut{
			get{return _cut;}
			set{if(value!=null){_cut=value;cutted=true;}else{cutted=false;}}
		}
		
		Point[] _stretch;
		public Point[] Stretch{
			get{return _stretch;}
			set{if(value!=null){_stretch=value;stretched=true;}else{stretched=false;}}
		}
		
		ColorMatrix _colormat;
		public ColorMatrix Colormat{
			get{return _colormat;}
			set{if(value!=null){_colormat=value;colormartixed=true;}else{colormartixed=false;}}
		}
	}
}
