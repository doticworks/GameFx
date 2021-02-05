/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2021/1/27
 * 时间: 18:03
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using doticworks.GameFx.Common;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;
using Transform = doticworks.GameFx.Common.Transform;

namespace doticworks.GameFx.Module.Gfx
{
	/// <summary>
	/// Description of RenderDraw.
	/// </summary>
	public partial class Render
	{
		public void _Clear(float R,float B,float G){
			Set_temp_color(R,G,B,1);
			DC.Clear(temp_color);
		}
		
		public void _Transform(doticworks.GameFx.Common.TransformRaw tr){
			
		}
		Transform tr=new Transform();
		public void _Transform(float x,float y){
			tr.X+=x;tr.Y+=y;
			tr.ToMat(ref transformbuffer);
			DC.Transform=transformbuffer;
		}
		#region Rectangle
		bool CheckOut_Rect(float x,float y,float w,float h){
			if(x>_w){return true;}
			if(y>_h){return true;}
			if(x+w<0){return true;}
			if(y+h<0){return true;}
			return false;
		}

		public void _Target(Bitmap1 bmp)
		{
			DC.Target = bmp;
		}

		public void _Start()
		{
			DC.BeginDraw();
		}

		public void _End()
		{
			DC.EndDraw();
		}

		public void _Bitmap(Bitmap1 bmp, float x, float y)
		{
			DC.DrawBitmap(bmp,new RawRectangleF(0,0,200,200),1,BitmapInterpolationMode.Linear );
		}

		public void _Rectangle_Fill(float x,float y,float w,float h,float R,float G,float B,float A,Vector2 RotatePoint=null,Vector2 Rotate=null){
			if(CheckOut_Rect(x,y,w,h)){return;}
			Set_temp_rect(x,y,w,h);
			Set_temp_color_and_brush(R,G,B,A);
			DC.FillRectangle(temp_rect,temp_brush_solid);
		}
		
		public void _Rectangle_Draw(float x,float y,float w,float h,float R,float G,float B,float A,float linew=1,Vector2 RotatePoint=null,Vector2 Rotate=null){
			if(CheckOut_Rect(x,y,w,h)){return;}
			Set_temp_rect(x,y,w,h);
			Set_temp_color_and_brush(R,G,B,A);
			DC.DrawRectangle(temp_rect,temp_brush_solid,linew);
		}
		#endregion
		
		#region Circle
		bool CheckOut_Cir(float x,float y,float r){
			if(x-r>_w){return true;}
			if(y-r>_h){return true;}
			if(x+r<0){return true;}
			if(y+r<0){return true;}
			return false;
		}
		public void _Circle_Draw(float x,float y,float r,float R,float G,float B,float A,float linew=1,Vector2 RotatePoint=null,Vector2 Rotate=null){
			if(CheckOut_Cir(x,y,r)){return;}
			Set_temp_Ellipse(x,y,r,r);
			Set_temp_color_and_brush(R,G,B,A);
			DC.DrawEllipse(temp_ell,temp_brush_solid,linew);
		}
		public void _Circle_Fill(float x,float y,float r,float R,float G,float B,float A,Vector2 RotatePoint=null,Vector2 Rotate=null){
			if(CheckOut_Cir(x,y,r)){return;}
			Set_temp_Ellipse(x,y,r,r);
			Set_temp_color_and_brush(R,G,B,A);
			DC.FillEllipse(temp_ell,temp_brush_solid);
		}
		public void _Circle_Draw(float x,float y,float rx,float ry,float R,float G,float B,float A,float linew=1,Vector2 RotatePoint=null,Vector2 Rotate=null){
			if(CheckOut_Cir(x,y,(rx+ry)/2)){return;}
			Set_temp_Ellipse(x,y,rx,ry);
			Set_temp_color_and_brush(R,G,B,A);
			DC.DrawEllipse(temp_ell,temp_brush_solid,linew);
		}
		public void _Circle_Fill(float x,float y,float rx,float ry,float R,float G,float B,float A,Vector2 RotatePoint=null,Vector2 Rotate=null){
			if(CheckOut_Cir(x,y,(rx+ry)/2)){return;}
			Set_temp_Ellipse(x,y,rx,ry);
			Set_temp_color_and_brush(R,G,B,A);
			DC.FillEllipse(temp_ell,temp_brush_solid);
		}
		#endregion
		#region Line
		public void _Line_Draw(float x1,float y1,float x2,float y2,float R,float G,float B,float A,Vector2 RotatePoint=null,Vector2 Rotate=null){
			temp_vec2.X=x1;temp_vec2.Y=y1;temp_vec2_2.X=x2;temp_vec2_2.Y=y2;
			Set_temp_color_and_brush(R,G,B,A);
			DC.DrawLine(temp_vec2,temp_vec2_2,temp_brush_solid);
		}
		#endregion
		#region Text
		public void _Text(float X,float Y,string text,float size, float R,float G,float B,float A,Vector2 RotatePoint=null,Vector2 Rotate=null){
			Set_temp_rect(X,Y,10000,10000);
			Set_temp_color_and_brush(R,G,B,A);
			if((int)temp_textfmt.FontSize-(int)size!=0){
				SharpDX.DirectWrite.TextFormat fmtdis=temp_textfmt;
				temp_textfmt=new SharpDX.DirectWrite.TextFormat(dwFactory,"微软雅黑",size);
				DC.DrawText(text,temp_textfmt,temp_rect,temp_brush_solid);
				fmtdis.Dispose();
			}else{
				DC.DrawText(text,temp_textfmt,temp_rect,temp_brush_solid);
			}
		}
		#endregion
		#region Polygon
		public void _Polygon_Draw(float R,float G,float B,float A,Vector2 RotatePoint=null,Vector2 Rotate=null,params float[] points_x_y){
			Set_temp_polygon(points_x_y);
			Set_temp_color_and_brush(R,G,B,A);
			DC.DrawGeometry(temp_polygon,temp_brush_solid);
		}
		public void _Polygon_Fill(float R,float G,float B,float A,Vector2 RotatePoint=null,Vector2 Rotate=null,params float[] points_x_y){
			Set_temp_polygon(points_x_y);
			Set_temp_color_and_brush(R,G,B,A);
			DC.FillGeometry(temp_polygon,temp_brush_solid);
		}
		#endregion
		
	}
}
