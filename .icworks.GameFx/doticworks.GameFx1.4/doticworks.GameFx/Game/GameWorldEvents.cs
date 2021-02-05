/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2021/2/2
 * 时间: 不要看我，还没下课 5:01
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Threading;
using doticworks.GameFx.Game;
using doticworks.GameFx.Module.Gfx;
using doticworks.GameFx.Game.Components;
namespace doticworks.GameFx.Game
{
	/// <summary>
	/// Description of GameWorld.
	/// </summary>
	public partial class GameWorld
	{
		public event Action<int,int> ClientResize;
		private bool needresize = false;
		private int needrsw = 1;private int needrsh = 1;
		public void ClientResize_(int w,int h)
		{
			if (!unloaded)
			{
				needresize = true;
				needrsw = w;
				needrsh = h;
			}
		}
	}
}
