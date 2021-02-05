/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/12/26
 * 时间: 21:13
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using doticworks.GameFx.GFX;
using FarseerPhysics.Dynamics;
using doticworks.GameFx.GAME.WORLD.Competions;
namespace doticworks.GameFx.GAME.WORLD
{
	/// <summary>
	/// Description of GameObjectNormal.
	/// </summary>
	public class GameObjectNormal:GameObject,IRender
	{
		public GameObjectNormal()
		{
//			Body b=new Body();
//			b.CollisionGroup=;
			
//			Category
		}
		public virtual void Draw(Render rd){
			rd._Transform(transform);
		}
		
	}
}
