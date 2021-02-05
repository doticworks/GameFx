/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2021/1/15
 * 时间: 21:41
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
namespace doticworks.GameFx.Game.Components
{
	/// <summary>
	/// Description of ComNode.
	/// </summary>
	public class ComNode:Component
	{
		public override void Load(ComponentModel model)
		{
			model.NodeComponent=true;
			model.RI_ComNode=this;
			model.RI_ComNode_Add=Add;
			model.RI_ComNode_Remove=Remove;
			model.RI_ComNode_Exist=Exist;
			model.RI_ComNode_Enum=Enum;
			model.RI_ComNode_ToArray=ToArray;
		}
		public override Component Copy()
		{
			ComNode cn=new ComNode();
			Enum(g=>{cn.Add(g.Clone());});
			return cn;
		}
		List<GameObject> childs=new List<GameObject>();
		public void Add(GameObject go){
			if(!childs.Contains(go)){childs.Add(go);
				go.parent = Owner;
				go.hasparent = true;
			}
		}public void Remove(GameObject go){
			if (childs.Contains(go))
			{
				childs.Remove(go);
				go.parent = null;
				go.hasparent = false;
			}
		}
		public bool Exist(GameObject go){
			return childs.Contains(go);
		}
	    public virtual void Enum(Action<GameObject> act){
			for(int i=0;i<=childs.Count-1;i++){
				act(childs[i]);
			}
		}
		#region ChildInvokes
		public void ChildInvoke(Action<GameObject> arg){
			Enum(arg);
		}
		#endregion
		#region TreeInvokes
		public void TreeInvoke(Action<GameObject> before=null,Action<GameObject> after=null){
			if(before!=null){before(this.Owner);}
			Enum(g =>g.components.RI_ComNode.TreeInvoke(before,after));
			if(after!=null){after(this.Owner);}
		}
		#endregion
		
		public GameObject[] ToArray(){
			return childs.ToArray();
		}
	}
}
