/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2021/2/15
 * 时间: 21:06
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using doticworks.GameFx.Game;
using doticworks.GameFx.Game.Components;
using doticworks.GameFx.Module.Gfx;
using System.Windows.Forms;
using doticworks.GameFx.Common;
namespace Learn1.__1
{
	/// <summary>
	/// Description of GameInit.
	/// </summary>
	public class GameInit
	{
		public GameInit(GameWorld world)
		{
			//这里是精华
			PrefabGameObject.BackGround.Clone(world.root);//从模板中clone出一个gameobj  直接把母gameobj设成root
			//这里有个background 因为画板每一帧都要清空为黑色 所以搞个背景gameobj方便点
			
			GameObject earth = PrefabGameObject.NormalGameObject.Clone(world.root);//同上  clone到指定的parent之下
			//预制的normalgameobj包括了画图和输入 但啥也不画  此后要对组件进行具体设置
			earth.Tag="Earth";//改个名
			earth.transform.Position=new Vector2(250,500);//初始位置
			
			earth.components.GetComponent<ComRenderNormal>().paint=(ir)=>{//获取画图的组件 跟他说要画些什么  以gameobj的坐标为坐标原点
				ir._Circle_Fill(0,0,100,0.1f,0.1f,1f,1);
				ir._Text(0,0,world.CanFps.ToString(),10,0.3f,0.7f,0.5f,1);//略 同1.3 除了基坐标变了
			};
			
			
			GameObject moonmover=PrefabGameObject.NodeGameObject.Clone(earth);//因为月球绕地球转 就搞个mover 让mover转 而moon作为其子节点
			//nodegameobject 只起到节点功能 （能拥有子节点） 其他啥也没有
			GameObject moon=PrefabGameObject.DrawGameObject.Clone(moonmover);//月球
			moonmover.Tag="MoonHx";
			moon.Tag="Moon";
			
			
			moon.transform.Position=new Vector2(150,0);//月球对于mover的位置
			moon.components.DoComponents<ComRenderNormal>(crn=>{crn.paint=ir=>{ir._Circle_Fill(0,0,15,0.7f,0.6f,0.4f,1);};});
			
			ComEvent ce=new ComEvent();
			ce.OnUpdate=f=>{moonmover.transform.Theta+=0.005f;};
			moonmover.components.AddComponent(ce);
			
			GameObject hamover=moonmover.Clone(moon);
			hamover.components.GetComponent<ComEvent>().OnUpdate=f=>{hamover.transform.Theta+=0.01f;};
			hamover.GetChilds()[0].transform.Position=new Vector2(30,0);
			hamover.GetChilds()[0].components.DoComponents<ComRenderNormal>(crn=>{crn.paint=ir=>{ir._Circle_Fill(0,0,5,0.4f,0.6f,0.4f,1);};});
		//	GameObject ha=moon.Clone();
	//		ha.transform.Position=new Vector2(15,0);
	//		ha.components.DoComponents<ComRenderNormal>(crn=>{crn.paint=ir=>{ir._Circle_Fill(0,0,4,0.7f,0.6f,0.4f,1);};});
			
			
			earth.components.DoComponents<ComInput>((ci)=>{
            	ci.MouseMove=(v,z)=>{
//		            		Terminal.WF("{0}\r\n",(v-earth.transform.Position).Normalize().ToString());
            		if((v-earth.transform.Position).Length()>15){
            			earth.transform.Position+=8*((v-earth.transform.Position).Normalize());}
            	};
				ci.KeyDown=(k)=>{
            	//	Terminal.WF("{0}\r\n",k.ToString());
            		if(k==Keys.Space){
            			earth.transform.Theta+=0.01f;
            		}
		    	};
            });
		}
	}
}
