/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/12/26
 * 时间: 18:51
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using doticworks.GameFx.COMMON;
namespace doticworks.GameFx.GAME.WORLD
{
	public class GameObject
	{
		public GameObject()
		{
		}
		public TransformRaw transform=new TransformRaw();
		bool hasparent=false;
		GameObject parent=null;
		List<GameObject> childs=new List<GameObject>();
		public GameWorld gw;
		public void AddChild(GameObject child){
			if(!childs.Contains(child)){childs.Add(child);
				if(gw!=null){
					child.gw=gw;
					gw.AddGameObjectCompetions(child);}
			}
		}
		public void RemoveChild(GameObject child){
			if(childs.Contains(child)){childs.Remove(child);}
			if(gw!=null){child.gw=null;gw.RemGameObjectCompetions(child);}
		}
	}
}
