/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2021/1/27
 * 时间: 18:05
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;
using SharpDX;
using SharpDX.DirectWrite;
namespace doticworks.GameFx.Module.Gfx
{
	/// <summary>
	/// Description of RenderTemps.
	/// </summary>
	public partial class Render
	{
		int _w;int _h;
		RawRectangleF temp_rect=new RawRectangleF(0,0,1,1);
		void Set_temp_rect(float x,float y,float w,float h){
			temp_rect.Left=x;temp_rect.Top=y;temp_rect.Right=x+w;temp_rect.Bottom=y+h;
		}
		RawVector2 temp_vec2=new RawVector2(0,0);
		RawVector2 temp_vec2_2=new RawVector2(0,0);
		
		RawColor4 temp_color=new RawColor4(0.5f,0,0,0);
		void Set_temp_color(float R,float G,float B,float A){
			temp_color.R=R;temp_color.G=G;temp_color.B=B;temp_color.A=A;
		}
		SolidColorBrush temp_brush_solid;
		void Set_temp_color_and_brush(float R,float G,float B,float A){
			bool changed=false;
			if(temp_color.R!=R){temp_color.R=R;changed=true;}
			if(temp_color.G!=G){temp_color.G=G;changed=true;}
			if(temp_color.B!=B){temp_color.B=B;changed=true;}
			if(temp_color.A!=A){temp_color.A=A;changed=true;}
			if(changed){temp_brush_solid.Color=temp_color;}
		}
		
		Ellipse temp_ell;
		void Set_temp_Ellipse(float x,float y,float rx,float ry){
			temp_vec2.X=x;temp_vec2.Y=y;
			temp_ell.Point=temp_vec2;temp_ell.RadiusX=rx;temp_ell.RadiusY=ry;
		}
		
		PathGeometry temp_polygon;
		void Set_temp_polygon(float[] values){
				temp_polygon.Dispose();
				temp_polygon=new PathGeometry(GraphicsDevice.Default.D2DFactory);
				GeometrySink a=temp_polygon.Open();
				if(values.Length!=0&&values.Length%2!=1){
				temp_vec2.X=values[0];temp_vec2.Y=values[1];
				a.BeginFigure(temp_vec2,FigureBegin.Filled);
				for(int i=2;i<=values.Length-1;i+=2){
					temp_vec2.X=values[i];temp_vec2.Y=values[i+1];
					a.AddLine(temp_vec2);
				}
				a.EndFigure(FigureEnd.Open);
				}
				a.Close();
		}
		TextLayout temp_textlay;
		TextFormat temp_textfmt;
	}
}
