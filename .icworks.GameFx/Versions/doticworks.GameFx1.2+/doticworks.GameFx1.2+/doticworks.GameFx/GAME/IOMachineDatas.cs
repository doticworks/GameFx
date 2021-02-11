/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2020/11/21
 * 时间: 22:38
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
		Form _gamewindow;
		PictureBox picbox;
		Thread _trace;
		Thread _debugtrace;
		
		public int MaxFps=40;
		public int NowFps;
		public int CanFps;
		
		bool isworking=false;
		
		bool locksize=false;
		int lockw;
		int lockh;
		
		public Action Update=()=>{};
		
		Canvas _canvas;
		public Canvas Canvas{
			get{return _canvas;}
			set{_canvas=value;}
		}
		InputMap _inputMap;
		public InputMap InputMap{
			get{return _inputMap;}
			set{_inputMap=value;}
		}
		
		public bool DebugMode=false;
		#region debugData
		public string debugdatastr="";
		public long TickInput;
		public long TickUpdateFunc;
		public long TickDraw;
		public long TickToScreen;
		#endregion
	}
}
