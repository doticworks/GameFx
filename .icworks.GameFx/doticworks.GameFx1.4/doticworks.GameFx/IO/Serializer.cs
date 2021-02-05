/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/12/13
 * 时间: 11:54
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
namespace doticworks.GameFx.IO
{
	/// <summary>
	/// Description of Serializer.
	/// </summary>
	public class Serializer
	{
		
		public static byte[] DoSeria(object obj){
			using (MemoryStream ms = new MemoryStream()){
				IFormatter formatter = new BinaryFormatter();
				formatter.Serialize(ms,obj);
				byte[] buffer=ms.GetBuffer();
				return buffer;
			}
		}
		public static byte[] SerializeObject(object pObj){
			if (pObj == null)
				return null;
			System.IO.MemoryStream _memory = new System.IO.MemoryStream();
			BinaryFormatter formatter = new BinaryFormatter();
			formatter.Serialize(_memory, pObj);
			_memory.Position = 0;
			byte[] read = new byte[_memory.Length];
			_memory.Read(read, 0, read.Length);
			_memory.Close();
			return read;
		}
		public static object Unseria(byte[] buffer){
			using (MemoryStream ms = new MemoryStream(buffer)){
				IFormatter formatter = new BinaryFormatter();
				return formatter.Deserialize(ms);
			}
		}
		public static object DeserializeObject(byte[] pBytes){
			object _newOjb = null;
			if (pBytes == null)
				return _newOjb;
			System.IO.MemoryStream _memory = new System.IO.MemoryStream(pBytes);
			_memory.Position = 0;
			BinaryFormatter formatter = new BinaryFormatter();
			_newOjb = formatter.Deserialize(_memory);
			_memory.Close();
			return _newOjb;
		}
		
	}
}
