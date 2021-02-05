/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2021/1/15
 * 时间: 17:24
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using doticworks.GameFx.Common;
namespace doticworks.GameFx.Game.Components
{
	/// <summary>
	/// Description of ComponentModel.
	/// </summary>
	public partial class ComponentModel
	{
		public ComponentModel(GameObject owner_)
		{owner=owner_;
		}
//		Dictionary<Type,Component> components=new Dictionary<Type,Component>();
		List<Component> components=new List<Component>();
//		public void AddComponent<T>(T value)where T:Component{
//			value.Load(this);
//			value.Owner=owner;
//			components.Add(typeof(T),value);
//		}
		
		public T GetComponent<T>()where T:Component{
			for(int i=0;i<components.Count;i++){
				if(components[i]is T){return components[i]as T;}
			}return null;
		}
		public T[] GetComponents<T>()where T:Component{
			List<T> tmp=new List<T>();
			for(int i=0;i<components.Count;i++){
				if(components[i]is T){tmp.Add(components[i] as T);}
			}return tmp.ToArray();
		}
		public void DoComponents<T>(Action<T> arg)where T:Component{
			for(int i=0;i<components.Count;i++){
				if(components[i]is T){arg(components[i]as T);}
			}
		}
		public void AddComponent(Component value){
			value.Load(this);
			value.Owner=owner;
			components.Add(value);
		}
		public ComponentModel Copy(GameObject __owner){
			ComponentModel cm=new ComponentModel(__owner);
			for(int i=0;i<components.Count;i++){
				cm.AddComponent(components[i].Copy());
			}
			return cm;
		}
		public bool NodeComponent=false;
		GameObject owner;
//		
	}
}
