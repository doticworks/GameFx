/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/11/7
 * 时间: 11:32
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
namespace doticworks.GameFx.IO
{
	public partial class Assetor
	{
		public Assetor(Assembly baseasm)
		{
			_asm = baseasm;
		}
		public Assetor()
		{
			_asm = Assembly.GetEntryAssembly();
		}
		Assembly _asm;
		Stream _temp;
	//	byte[] _buffer;
		
		public  byte[] Get_byte(string path)
		{
			_temp = _asm.GetManifestResourceStream(path);
			if (_temp == null) {
				throw new Exception("Not found!\r\nDo you embbed it?\r\nOr path type error?");
			}
			byte[] _buffer = new byte[_temp.Length]; 
			_temp.Read(_buffer, 0, _buffer.Length);
			return _buffer;
		}
		
	}
}
