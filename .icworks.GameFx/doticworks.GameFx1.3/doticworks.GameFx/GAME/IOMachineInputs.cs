/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2020/121
 * 时间: 20:59
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
namespace doticworks.GameFx.GAME
{
	/// <summary>
	/// Description of IOMachine.
	/// </summary>
	public partial class IOMachine
	{
		void I_KeyDown(object s,KeyEventArgs e){
			if(isworking){
				_inputMap.I_KeyDown(e.KeyData);
			}
		}
		void I_KeyUp(object s,KeyEventArgs e){
			if(isworking){
				_inputMap.I_KeyUp(e.KeyData);
			}
		}
		public void I_MouseUp(object sender, MouseEventArgs e)
		{
			if(isworking){
				_inputMap.I_MouseUp(e);
			}
		}
		public void I_MouseDown(object sender, MouseEventArgs e)
		{
			if(isworking){
				_inputMap.I_MouseDown(e);
			}
		}
		public void I_MouseMove(object s,MouseEventArgs e)
		{
			if(isworking){
				int lx=(int)(e.X);
				int ly=(int)(e.Y);
				if(!FullScreen){
					lx+=10;
					ly+=5;
				}
				int sx=(int)(lx);
				int sy=(int)(ly);
				if(locksize){
					sx=(int)((float)((float)lx/(float)_gamewindow.Width)*(float)lockw);
					sy=(int)((float)((float)ly/(float)_gamewindow.Height)*(float)lockh);
				}
				
				_inputMap.I_MouseMove(sx,sy,e);
			}
			
		}
	}
}
