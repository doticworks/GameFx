﻿/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2021/1/16
 * 时间: 20:17
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using doticworks.GameFx.Game.Components;
using SharpDX.Direct2D1;
namespace doticworks.GameFx.Game
{
	/// <summary>
	/// Description of PrefabGameObject.
	/// </summary>
	public static class PrefabGameObject
	{
		public static GameObject GetRoot(Bitmap1 swapbuffer,Func<int,int,Bitmap1> resize){
			GameObject go=new GameObject();
			go.Tag = "Perfab_Root";
	     	go.components.AddComponent(new ComRooter());
	     	go.components.AddComponent(new ComNode());
	     	ComRenderKeyNode crkn=new ComRenderKeyNode(swapbuffer,resize);
	     	go.components.AddComponent(crkn);
	     	return go;
		}
//		static Lazy<GameObject> RootGameObject_=new Lazy<GameObject>(()=>{
//	     	GameObject go=new GameObject();
//	     	go.components.AddComponent(new ComRooter());
//	     	go.components.AddComponent(new ComNode());
//	     	ComRenderKeyNode crkn=new ComRenderKeyNode(
//	     	go.components.AddComponent(new ComRender());
//	     	return go;
//		});public static GameObject RootGameObject{get{return RootGameObject_.Value.Clone();}}
		
		
		
		static Lazy<GameObject> NodeGameObject_=new Lazy<GameObject>(()=>{
	     	GameObject go=new GameObject();
	        go.Tag = "Perfab_Node";
	     	go.components.AddComponent(new ComNode());
	     	go.components.AddComponent(new ComRender());
	     	return go;
		});public static GameObject NodeGameObject{get{return NodeGameObject_.Value.Clone();}}
		
		//
		
		static Lazy<GameObject> DrawGameObject_=new Lazy<GameObject>(()=>{
           	GameObject go=new GameObject();
            go.Tag = "Perfab_Draw";
         	go.components.AddComponent(new ComNode());
         	go.components.AddComponent(new ComRenderNormal());
         	return go;
		});public static GameObject DrawGameObject{get{return NormalGameObject_.Value.Clone();}}
		
		//
		
		static Lazy<GameObject> NormalGameObject_=new Lazy<GameObject>(()=>{
           	GameObject go=new GameObject();
            go.Tag = "Perfab_Normal";
         	go.components.AddComponent(new ComNode());
         	go.components.AddComponent(new ComRenderNormal());
         	go.components.AddComponent(new ComInput());
         	return go;
		});public static GameObject NormalGameObject{get{return NormalGameObject_.Value.Clone();}}
		
		//
		
		static Lazy<GameObject> Background_=new Lazy<GameObject>(()=>{
           	GameObject go=new GameObject();
            go.Tag = "Perfab_Bg";
         	go.components.AddComponent(new ComNode());
         	ComRenderNormal crn=new ComRenderNormal();
         	crn.paint=(ir)=>{
         		ir._Clear(0,0,0);
         	};
         	go.components.AddComponent(crn);
         	go.Tag="BackGround";
         	return go;
		});public static GameObject BackGround{get{return Background_.Value.Clone();}}
	}
}
