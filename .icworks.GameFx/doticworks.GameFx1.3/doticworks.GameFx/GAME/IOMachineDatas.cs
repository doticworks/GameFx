/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2020/121
 * 时间: 22:38
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using G=doticworks.GameFx.GFX;
namespace doticworks.GameFx.GAME
{
	/// <summary>
	/// Description of IOMachine.
	/// </summary>
	public partial class IOMachine
	{
		Control _gamewindow;
		Thread _trace;
		Thread _debugtrace;
		
		public int MaxFps=40;
		public int NowFps;
		public int CanFps;
		
		bool isworking=false;
		bool gamewndneedupdate=false;
		
		bool locksize=false;
		int lockw;
		int lockh;
		
		bool FullscreenStyle=false;
		int formw=1,formh=1;
		Point fornp=new Point(),zerop=new Point(0,0);
		public bool FullScreen{
			set{_gamewindow.Invoke(new MethodInvoker(()=>{
			   	_gamewindow.BringToFront();
//			   	Screen.FromControl(_gamewindow).Bounds;
			   	if(value){fornp=_gamewindow.Location; formw=_gamewindow.Width;formh=_gamewindow.Height;}
			   	if(value){FullscreenStyle=true;if(_gamewindow is Form){(_gamewindow as Form).Location=zerop;(_gamewindow as Form).Width=	Screen.FromControl(_gamewindow).WorkingArea.Width+200;(_gamewindow as Form).Height=(Screen.FromControl(_gamewindow).WorkingArea).Height+200;(_gamewindow as Form).FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;}}
				
				if(!value){FullscreenStyle=false;if(_gamewindow is Form){(_gamewindow as Form).Location=fornp; (_gamewindow as Form).WindowState = System.Windows.Forms.FormWindowState.Normal;(_gamewindow as Form).FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;(_gamewindow as Form).Width=formw;(_gamewindow as Form).Height=formh;}}
             	}));
             		_gamewindow.BringToFront();
             }get{
				return FullscreenStyle;
			}
		}
		
		public Action Update=()=>{};
		public event Action UpdateE;
		
		G.RenderMode rendermode;
		G.LayerNode iomdatalayer;
		G.Render render;
		public G.Render Render{
			get{return render;}
			set{render=value;}
		}
		InputMap _inputMap;
		public InputMap InputMap{
			get{return _inputMap;}
			set{_inputMap=value;}
		}
		
		bool debugmode=false;
		public bool DebugMode{
			get{
				return debugmode;
			}
			set{
				debugmode=value;
				if(isworking){
					iomdatalayer.Active=value;
				}
				
			}
		}
		#region debugData
		public string debugdatastr="";
		public long TickInput;
		public long TickUpdateFunc;
		public long TickPresent;
		#endregion
	}
}
