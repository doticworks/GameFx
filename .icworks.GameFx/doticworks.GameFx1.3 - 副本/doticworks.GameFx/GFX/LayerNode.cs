/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/12/21
 * 时间: 11:55
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
namespace doticworks.GameFx.GFX
{
	/// <summary>
	/// Description of LayerNode.
	/// </summary>
	public class LayerNode:Layer
	{
		public LayerNode(float index):base(index){}
		
		Dictionary<string,Layer> layers=new Dictionary<string, Layer>();
		bool needupdatelist=false;
		SortedList<float,string> layerlist=new SortedList<float, string>();
		
		public void ChildUpdated(){
			needupdatelist=true;
		}
		
		public void Add(string name,Layer child){
			if(layers.ContainsKey(name)){
				return;
			}
			layers.Add(name,child);
			child.parent=this;child.hasparent=true;
			ChildUpdated();
		}
		public void Remove(string name){
			if(!layers.ContainsKey(name)){
				return;
			}
			layers[name].hasparent=false;
			layers[name].parent=null;
			layers.Remove(name);
			ChildUpdated();
		}
		public bool Contain(string name){
			return layers.ContainsKey(name);
		}
		
		public override void Draw(Render rd)
		{
			if(needupdatelist){needupdatelist=false;updatelist();}
			paint(rd);
			foreach(var item in layerlist){
				layers[item.Value].paint(rd);
			}
		}
		void updatelist(){
			layerlist.Clear();
			foreach(var item in layers){
				if(item.Value.Active){
					float itemindexaddv=0;
					while(layerlist.ContainsKey(item.Value.Index+itemindexaddv)){
						itemindexaddv+=0.000001f;
					}
					layerlist.Add(item.Value.Index+itemindexaddv,item.Key);
				}
			}
			needupdatelist=false;
		}
	}
}
