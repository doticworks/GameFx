/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2021/1/16
 * 时间: 19:07
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace doticworks.GameFx.Common
{
	/// <summary>
	/// Description of TransformStack.
	/// </summary>
	public class TransformStack:Transform
	{
		public TransformStack()
		{
		}
		public void AddTransform(Transform willadd){
			
			Changed(this);
		}
		public void SubtractTransform(Transform willsub){
			
			Changed(this);
		}
		public event Action<Transform> Changed;
	}
}
