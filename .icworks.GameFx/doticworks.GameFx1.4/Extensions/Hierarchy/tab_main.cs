/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2021/2/4
 * 时间: Go home day！ 10:36
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using doticworks.GameFx.Game;
using System.Collections.Generic;
using System.Threading.Tasks;
using doticworks.GameFx;
using doticworks.GameFx.Game.Components;

namespace Hierarchy
{
	/// <summary>
	/// Description of tab_main.
	/// </summary>
	public partial class tab_main : UserControl
	{
		public tab_main()
		{
			InitializeComponent();
			pointer = PrefabGameObject.DrawGameObject;
			pointer.components.GetComponent<ComRenderNormal>().paint = (ir) =>
			{
				ir._Circle_Fill(0,0,15,0,1,0,0.2f);
				ir._Rectangle_Fill(-0.5f,-25,1,50,1,0,0,0.4f);
				ir._Rectangle_Fill(-25,-0.5f,50,1,0,0,1,0.4f);
			//	ir._Text(0.5f,-30,"X:"+choosedgo.transform.Position.X.ToString()+" Y:"+choosedgo.transform.Position.X.ToString(),10,0,1,0,1);
				ir._Text(0.5f,-30,choosedgo.transform.ToString(),10,0,1,0,1);
			};
			pointer.Tag = "Hierarchy Pointer";
		}
		public Dictionary<TreeNode,GameObject> shell=new Dictionary<TreeNode, GameObject>();
		public GameWorld gw;
		public Action<string> settitle;
		void TreeNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			settitle("Hierarchy - Connected to GameFx - Syncing GameObject...");
			e.Node.Nodes.Clear();
			if (e.Node != tree.TopNode)
			{
				GameObject tmp = shell[e.Node];
				tmp.components.RI_ComNode.Enum((g) =>
				{
					shell.Add(e.Node.Nodes.Add(g.Tag),g);
				});
				choosedgo=tmp;
			}
			else
			{
				GameObject tmp = gw.root;
				tmp.components.RI_ComNode.Enum((g) =>
				{
					shell.Add(e.Node.Nodes.Add(g.Tag),g);
				});
				choosedgo=tmp;
			}

			textBox1.Text = choosedgo.transform.ToString();
			resetpointer();
			
			if(e.Button==MouseButtons.Left){e.Node.Expand();}
			if(e.Button!=MouseButtons.Left){e.Node.Collapse();}
			settitle("Hierarchy - Connected to GameFx");
			
		}
		public GameObject choosedgo;
		public GameObject pointer;

		public void resetpointer()
		{
			if (choosedgo != pointer)
			{
				if (pointer.parent != null) pointer.parent.components.RI_ComNode.Remove(pointer);
			choosedgo.components.RI_ComNode.Add(pointer);
		}

		//	pointer.x = choosedgo.x;
		//	pointer.y = choosedgo.y;
		}

		
	}
}
