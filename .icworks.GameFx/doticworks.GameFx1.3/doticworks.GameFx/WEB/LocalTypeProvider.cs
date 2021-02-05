/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/12/13
 * 时间: 11:35
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
namespace doticworks.GameFx.WEB
{
	[Serializable]
	public class LocalTypeProvider
	{
		public LocalTypeProvider()
		{
		}
		public Dictionary<string,Type> types=new Dictionary<string, Type>();
		public void AddType(Type t){
			types.Add(t.FullName,t);
		}
		public Type GetTypex(LocalType lt){
			return types[lt.typestr];
		}
	}
}
