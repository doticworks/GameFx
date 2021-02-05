/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/12/31
 * 时间: 9:39
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using doticworks.GameFx.GFX;
using System.Windows.Forms;
using doticworks.GameFx.GAME.WORLD.Competions;
namespace doticworks.GameFx.GAME.WORLD
{
	/// <summary>
	/// Description of GameObjectControl.
	/// </summary>
	public class GameObjectControl:GameObject,IRender,IKeyInput
	{
		public GameObjectControl()
		{
		}
		public virtual void Draw(Render rd){
			
		}
		public virtual void KeyDown(Keys k){
			
		}
		public virtual void KeyHold(Keys k){
			
		}
	}
}
