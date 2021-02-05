/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2020/11/7
 * 时间: 19:28
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Reflection;
using System.IO;
namespace doticworks.GameFx.IO
{
	public partial class Assetor
	{
		public string Get_string(string path){
			return System.Text.Encoding.Default.GetString(Get_byte(path));
		}
		public string getstr(string path,System.Text.Encoding encode){
			return encode.GetString(Get_byte(path));
		}
	}
}
