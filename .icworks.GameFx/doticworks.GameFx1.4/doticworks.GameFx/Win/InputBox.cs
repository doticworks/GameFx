/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/12/27
 * 时间: 7:06
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace doticworks.GameFx.Win
{
	
	partial class InputBoxF : Form
	{
		public InputBoxF(string Caption,string Tip,string defaultstr,valsenderstr tmp)
		{
			InitializeComponent();
			Text=Caption;
			label1.Text=Tip;
			Height=70+Tip.Split(new char[]{'\r','\n'}).Length*12-15;
			textBox1.Text=defaultstr;
			temp=tmp;
		}
		valsenderstr temp;
		void TextBox1KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter){
				temp.Val=textBox1.Text;
				this.Close();
			}
		}
	}
	class valsenderstr{
		string val=null;
		public string Val{
			get{
				return val;
			}set{
				val=value;
			}
		}
	}
	public static class InputBox{
		public static string Show(string Caption,string Tip,string defstr){
			valsenderstr vss=new valsenderstr();
			new InputBoxF(Caption,Tip,defstr,vss).ShowDialog();
			return vss.Val;
		}
		public static string Show(string Caption){
			return Show(Caption,"","");
		}
		public static string Show(){
			return Show("InputBox","","");
		}
	}
}
