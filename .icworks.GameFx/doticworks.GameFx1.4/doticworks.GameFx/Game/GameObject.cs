/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2021/1/15
 * 时间: 17:13
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using doticworks.GameFx.Game.Components;
using doticworks.GameFx.Common;
namespace doticworks.GameFx.Game
{
	/// <summary>
	/// Description of GameObject.
	/// </summary>
	public class GameObject
	{
		public GameObject()
		{
			components=new ComponentModel(this);
			transform=new Transform();
		}
		public ComponentModel components;
		public Transform transform;
	//	public float x=0;public float y=0;
		
		public bool Enable=true;
		public void Destory(){
			
		}
		public GameObject Clone(){
			if(hasparent){return Clone(parent);}
			GameObject g=new GameObject();
			g.Tag = Tag;
			g.transform=transform.Copy();
			g.components=components.Copy(g);
			return g;
		}
		public GameObject Clone(GameObject parent){
			GameObject g=Clone();
			parent.components.RI_ComNode_Add(g);
			return g;
		}
		public string Tag="UnTagged";
		public GameWorld rootworld;
		public GameObject parent=null;
		public bool hasparent=false;
		public GameWorld world{
			get{
				return getparentworld(this);
			}
		}
		GameWorld getparentworld(GameObject la){
			if(la.hasparent){
				return getparentworld(la.parent);
			}else{
				try{
					return la.components.GetComponent<ComRooter>().gw;
				}catch{
					return null;
				}
			}
		}
		
		public GameObject[] GetChilds(){//Returns an ordered list if ComNodeIndex
			if(components.NodeComponent){
				return components.RI_ComNode.ToArray();
			}return null;
		}
	}
}
