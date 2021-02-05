/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/124
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
using System.Collections.Generic;
namespace doticworks.GameFx.GAME
{
	/// <summary>
	/// Description of IOMachine.
	/// </summary>
	public partial class IOMachine
	{
//		Action<doticworks.GameFx.GFX.Render> iom
		void TraceDebug(){
			int[] fpslineele=new int[100];
			int fpslineupdateseek=0;
			int shellx=3;int shelly=63;
			Process p=Process.GetCurrentProcess();
			StringBuilder sb=new StringBuilder();
			int oldTickInput=0;int oldTickUpdateFunc=0;int oldTickDraw=0;
			iomdatalayer.paint=rd=>{
				rd._Text(10,10,debugdatastr,12,0f,1,0,0.8f);
//				rd._Text(100,5,Process.GetCurrentProcess().WorkingSet64.ToString(),12,0f,1,0,0.8f);
//				int ixold=0;
				rd._Rectangle_Fill(shellx,shelly,200,65,0.6f,0.6f,0.6f,0.06f);
				rd._Rectangle_Draw(shellx,shelly,200,65,0.6f,0.6f,0.6f,0.5f,1);
				
				rd._Line_Draw(shellx,(float)Math.Sqrt(1200)*1.6f+shelly,shellx+200,(float)Math.Sqrt(1200)*1.6f+shelly,0,0,1,0.1f);
				rd._Text(shellx+200,(float)Math.Sqrt(1200)*1.6f+shelly,"1200",8,0,0,1,0.5f);
				rd._Line_Draw(shellx,(float)Math.Sqrt(400)*1.6f+shelly,shellx+200,(float)Math.Sqrt(800)*1.6f+shelly,0,0,1,0.1f);
				rd._Text(shellx+200,(float)Math.Sqrt(400)*1.6f+shelly,"400",8,0,0,1,0.5f);
				rd._Line_Draw(shellx,(float)Math.Sqrt(100)*1.6f+shelly,shellx+200,(float)Math.Sqrt(400)*1.6f+shelly,0,0,1,0.1f);
				rd._Text(shellx+200,(float)Math.Sqrt(100)*1.6f+shelly,"100",8,0,0,1,0.5f);
				rd._Line_Draw(shellx,(float)Math.Sqrt(30)*1.6f+shelly,shellx+200,(float)Math.Sqrt(300)*1.6f+shelly,0,0,1,0.1f);
				rd._Text(shellx+200,(float)Math.Sqrt(30)*1.6f+shelly,"30",8,0,0,1,0.5f);
				
				for(int i=0;i<=98;i++){
					if(i==fpslineupdateseek){
						rd._Line_Draw(shellx+2+i*2,shelly,shellx+2+i*2,65+shelly,1,0,0,0.8f);
					}else{
						rd._Line_Draw(shellx+i*2,(float)Math.Sqrt(fpslineele[i])*1.6f+shelly,shellx+2+i*2,(float)Math.Sqrt(fpslineele[i+1])*1.6f+shelly,0,1,0,0.8f);
					}
				}
				int fpslinexxx=fpslineupdateseek-1;if(fpslinexxx==-1){fpslinexxx=99;}
				rd._Line_Draw(shellx,(float)Math.Sqrt(fpslineele[fpslinexxx])*1.6f+shelly,shellx+200,(float)Math.Sqrt(fpslineele[fpslinexxx])*1.6f+shelly,0,0,1,0.6f);
			};
			UpdateE+=()=>{
			                    	fpslineele[fpslineupdateseek]=CanFps;
			                    	fpslineupdateseek++;if(fpslineupdateseek>=100){fpslineupdateseek=0;}//shellx=InputMap.Mousex;shelly=InputMap.Mousey;
			                    };
			while(isworking){
				Thread.Sleep(50);
				sb.Clear();
				sb.AppendFormat("FPS {0}({1})\t",NowFps,CanFps);
//				cput=p.TotalProcessorTime-cput;
				sb.AppendFormat("MEM: {0}M({1})\r\n",Process.GetCurrentProcess().PrivateMemorySize64/(1024*1024),Process.GetCurrentProcess().PrivateMemorySize64.ToString());
//				cput=p.TotalProcessorTime;
				sb.AppendFormat("A{0}	=I{1}	+U{2}	+P{3}\r\n",TickInput+TickUpdateFunc+TickPresent,TickInput,TickUpdateFunc,TickPresent);
				oldTickInput=(int)((oldTickInput*49+TickInput)/50);
				oldTickUpdateFunc=(int)((oldTickUpdateFunc*49+TickUpdateFunc)/50);
				oldTickDraw=(int)((oldTickDraw*49+TickPresent)/50);
				sb.AppendFormat("A{0}	=I{1}	+U{2}	+P{3}\r\n",oldTickInput+oldTickUpdateFunc+oldTickDraw,oldTickInput,oldTickUpdateFunc,oldTickDraw);

				debugdatastr=sb.ToString();
			}
		}
	}
}
