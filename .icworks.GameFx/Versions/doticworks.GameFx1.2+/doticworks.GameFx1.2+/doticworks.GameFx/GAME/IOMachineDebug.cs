/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/11/24
 * 时间: 12:02
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件c.Text("FPS "+NowFps+"("+CanFps+")"+
					       "\r\nINPUT	"++
					       "\r\nUPDAT	"+TickUpdateFunc+
					       "\r\nDRAW	"+TickDraw+
					       "\r\nSHOW	"+TickToScreen+
					       "\r\nMLOC	"+InputMap.Mousex+" "+InputMap.Mousey
					       ,TextPainter.New(15,15,Color.FromArgb(255,Color.Green),10f));*/
 
using System;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;
namespace doticworks.GameFx.GAME
{
	/// <summary>
	/// Description of IOMachine.
	/// </summary>
	public partial class IOMachine
	{
		void TraceDebug(){
			Process p=Process.GetCurrentProcess();
			StringBuilder sb=new StringBuilder();
			int oldTickInput=0;int oldTickUpdateFunc=0;int oldTickDraw=0;int oldTickToScreen=0;
			while(isworking){
				Thread.Sleep(50);
				sb.Clear();
				sb.AppendFormat("FPS {0}({1})\r\n",NowFps,CanFps);
				sb.AppendFormat("AL	=IN	+UP	+DR	+SH\r\n");
				sb.AppendFormat("{0}	={1}	+{2}	+{3}	+{4}\r\n",TickInput+TickUpdateFunc+TickDraw+TickToScreen,TickInput,TickUpdateFunc,TickDraw,TickToScreen);
				oldTickInput=(int)((oldTickInput*49+TickInput)/50);
				oldTickUpdateFunc=(int)((oldTickUpdateFunc*49+TickUpdateFunc)/50);
				oldTickDraw=(int)((oldTickDraw*49+TickDraw)/50);
				oldTickToScreen=(int)((oldTickToScreen*49+TickToScreen)/50);
				sb.AppendFormat("{0}	={1}	+{2}	+{3}	+{4}\r\n",oldTickInput+oldTickUpdateFunc+oldTickDraw+oldTickToScreen,oldTickInput,oldTickUpdateFunc,oldTickDraw,oldTickToScreen);

				debugdatastr=sb.ToString();
			}
		}
	}
}
