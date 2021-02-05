/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2021/1/23
 * 时间: 19:08
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using SharpDX.Mathematics;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;
namespace doticworks.GameFx.Common
{
	[Serializable]
	public class Vector2//:SharpDX.Vector2
	{
		public float X;public float Y;
		public void RawVector(ref SharpDX.Mathematics.Interop.RawVector2 value){
			value.X=X;value.Y=Y;
		}
	}
}
