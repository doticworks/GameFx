/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2021/2/10
 * 时间: 18:34
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
namespace doticworks.GameFx.Common
{
	public class TransformStack
	{
		public TransformStack()
		{Clear();
		}
		public Transform Tr{
			get{
				return stack.Peek();
			}
		}
		public void Clear(){stack.Clear();stack.Push(new Transform());}
		public int Count{get{return stack.Count;}}
		Stack<Transform> stack=new Stack<Transform>();
		public Transform push(Transform arg){
			stack.Push(stack.Peek().Copy().Overlay(arg));return stack.Peek();
		}
		public Transform pop(){
			stack.Pop();return stack.Peek();
		}
	}
}
