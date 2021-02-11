/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/11/20
 * 时间: 21:41
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
namespace doticworks.GameFx.COMMON
{
	public class Texture2D : Texture
	{
		public override Bitmap Paint(){
			return _bmp;
		}
		public Texture2D(Bitmap bitmap){
			_bmp=bitmap;
		}
		Bitmap _bmp;
	}
}
