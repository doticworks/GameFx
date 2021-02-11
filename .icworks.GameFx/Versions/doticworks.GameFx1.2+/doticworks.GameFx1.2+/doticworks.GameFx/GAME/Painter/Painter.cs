/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/11/20
 * 时间: 21:52
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using doticworks.GameFx.COMMON;
namespace doticworks.GameFx.GAME
{
	/// <summary>
	/// Description of Painter.
	/// </summary>
	public abstract class Painter
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns>Paint Success</returns>
		public virtual bool Paint(System.Drawing.Graphics g){
			try{
				
				return true;
			}catch{return false;}
		}
		public float Rotate=0;
		public Point RotateTransform;
		public int x;
		public int y;
		public float opacity;
	}
}
