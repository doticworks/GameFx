/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2021/2/4
 * 时间: Go home day！ 10:30
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Hierarchy
{
	/// <summary>
	/// Description of tab_unconnect.
	/// </summary>
	public partial class tab_unconnect : UserControl
	{
		public tab_unconnect()
		{
			InitializeComponent();
		}
		public string TipText{
			get{
				return labtip.Text;
			}set{
				labtip.Text=value;
			}
		}
	}
}
