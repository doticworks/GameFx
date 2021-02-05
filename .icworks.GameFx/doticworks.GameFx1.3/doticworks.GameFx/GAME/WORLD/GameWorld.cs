/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/12/31
 * 时间: 9:41
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using doticworks.GameFx.GAME.WORLD.Competions;
using doticworks.GameFx.GFX;
namespace doticworks.GameFx.GAME.WORLD
{
	/// <summary>
	/// Description of GameWorld.
	/// </summary>
	public class GameWorld
	{
		public GameWorld()
		{
			root=new GameObject();
			root.gw=this;
			worldLayer=new Layer(1);
			worldLayer.Active=true;
			worldLayer.paint=(rdx)=>{
				foreach(var item in _go_render){
					item.Draw(rdx);
				}
			};
		}
		List<IKeyInput> _go_keyin=new List<IKeyInput>();
		List<IRender> _go_render=new List<IRender>();
		public Layer worldLayer;
		public GameObject root;
		public void AddGameObjectCompetions(GameObject gameobj){
			if(gameobj.GetType() is IRender){_go_render.Add(gameobj as IRender);};
			if(gameobj.GetType() is IKeyInput){_go_keyin.Add(gameobj as IKeyInput);};
		}
		public void RemGameObjectCompetions(GameObject gameobj){
			if(gameobj.GetType() is IRender){_go_render.Remove(gameobj as IRender);};
			if(gameobj.GetType() is IKeyInput){_go_keyin.Remove(gameobj as IKeyInput);};
		}
	}
}
