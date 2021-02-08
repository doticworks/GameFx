/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2021/1/16
 * 时间: 18:30
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using doticworks.GameFx.Common;
using doticworks.GameFx.Game;
namespace doticworks.GameFx.Game.Components
{
	public partial class ComponentModel{
		public ComNode RI_ComNode=null;
		public Action<GameObject> RI_ComNode_Add;
		public Action<GameObject> RI_ComNode_Remove;
		public Func<GameObject,bool> RI_ComNode_Exist;
		public Func<GameObject[]> RI_ComNode_ToArray;
		public Action<Action<GameObject>> RI_ComNode_Enum;
		///
		public ComRender RI_ComRender=null;

		public ComEvent RI_ComEvent = null;
		public event Action<float> onupdate;

		public void Onupdate(float dt)
		{
			try
			{
				onupdate(dt);
			}
			catch
			{
			}
		}
	}
}
