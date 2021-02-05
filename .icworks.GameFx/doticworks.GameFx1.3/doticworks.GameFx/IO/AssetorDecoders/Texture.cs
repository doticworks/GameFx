/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2020/11/14
 * 时间: 19:23
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Reflection;
using System.IO;
using System.Drawing;
using doticworks.GameFx.COMMON;
namespace doticworks.GameFx.IO
{
	public partial class Assetor
	{
		public Texture2D Get_Texture2D(string path)
		{
			return new Texture2D(new Bitmap(new MemoryStream(Get_byte(path))));
		}
	//	public Texture2T Get_Texture2T(string path)
	//	{
	//		return new Texture2T(new Bitmap(new MemoryStream(Get_byte(path))));
	//	}
	}
}
