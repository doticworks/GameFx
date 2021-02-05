/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/12/30
 * 时间: 9:09
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace doticworks.GameFx.COMMON
{
	
	public class TransformRaw
	{
		public TransformRaw()
		{
		}
		public float m11;
		public float m12;
		public float m21;
		public float m22;
		public float m31;
		public float m32;
		public virtual void ToMat(ref SharpDX.Mathematics.Interop.RawMatrix3x2 mat){
			mat.M11=m11;mat.M21=m21;mat.M31=m31;
			mat.M12=m12;mat.M22=m22;mat.M32=m32;
		}
	}
}
