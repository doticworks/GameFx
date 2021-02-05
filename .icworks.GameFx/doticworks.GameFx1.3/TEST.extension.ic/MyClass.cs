/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2021/1/13
 * 时间: 21:38
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;

namespace TEST.extension.ic
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public class EntriPoint:doticworks.GameFx.ExtensionBase
	{
		public override void ExtensionMain(doticworks.GameFx.Extension exten)
		{
			base.ExtensionMain(exten);System.Windows.Forms.MessageBox.Show("Load Me!!!");
		} 
	}
}