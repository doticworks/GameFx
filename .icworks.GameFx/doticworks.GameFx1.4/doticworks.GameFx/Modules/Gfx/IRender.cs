/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2021/1/25
 * 时间: 17:46
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using doticworks.GameFx.Common;
using SharpDX.Direct2D1;

namespace doticworks.GameFx.Module.Gfx
{
	/// <summary>
	/// Description of IRender.
	/// </summary>
	public interface IRender
	{
		void _Target(Bitmap1 bmp);
		void _Start();
		void _End();
		
		void _Clear(float R,float B,float G);
		void _Transform(doticworks.GameFx.Common.TransformRaw tr);
		void _Transform(float x,float y);
		#region Rectangle
		void _Rectangle_Fill(float x,float y,float w,float h,float R,float G,float B,float A,Vector2 RotatePoint=Vector2.Zero,Vector2 Toward=Vector2.UnitY);
		void _Rectangle_Draw(float x,float y,float w,float h,float R,float G,float B,float A,float linew=1,Vector2 RotatePoint=Vector2.Zero,Vector2 Toward=Vector2.UnitY);
		#endregion
		
		#region Circle
		void _Circle_Draw(float x,float y,float r,float R,float G,float B,float A,float linew=1,Vector2 RotatePoint=Vector2.Zero,Vector2 Toward=Vector2.UnitY);
		void _Circle_Fill(float x,float y,float r,float R,float G,float B,float A,Vector2 RotatePoint=Vector2.Zero,Vector2 Toward=Vector2.UnitY);
		void _Circle_Draw(float x,float y,float rx,float ry,float R,float G,float B,float A,float linew=1,Vector2 RotatePoint=Vector2.Zero,Vector2 Toward=Vector2.UnitY);
		void _Circle_Fill(float x,float y,float rx,float ry,float R,float G,float B,float A,Vector2 RotatePoint=Vector2.Zero,Vector2 Toward=Vector2.UnitY);
		#endregion
		
		#region Line
		void _Line_Draw(float x1,float y1,float x2,float y2,float R,float G,float B,float A,Vector2 RotatePoint=Vector2.Zero,Vector2 Toward=Vector2.UnitY);
		#endregion
		
		#region Text
		void _Text(float X,float Y,string text,float size, float R,float G,float B,float A,Vector2 RotatePoint=Vector2.Zero,Vector2 Toward=Vector2.UnitY);
		#endregion
		
		#region Polygon
		void _Polygon_Draw(float R,float G,float B,float A,Vector2 RotatePoint=Vector2.Zero,Vector2 Toward=Vector2.UnitY,params float[] points_x_y);
		void _Polygon_Fill(float R,float G,float B,float A,Vector2 RotatePoint=Vector2.Zero,Vector2 Toward=Vector2.UnitY,params float[] points_x_y);
		#endregion
		
		#region Bitmap
		void _Bitmap(Bitmap1 bmp,float x,float y);
		#endregion
	}
}
