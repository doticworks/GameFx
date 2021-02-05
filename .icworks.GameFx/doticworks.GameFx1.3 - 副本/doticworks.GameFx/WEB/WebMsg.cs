/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/12/13
 * 时间: 11:40
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace doticworks.GameFx.WEB
{
	[Serializable]
	public class WebMsg
	{
		public WebType type;
		public object obj;
		public WebID From;
		public WebID To;
	}
}
