/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/12/26
 * 时间: 18:51
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace doticworks.GameFx.Common
{
	public class Transform:TransformRaw
	{
		public Transform(float x,float y,float th,float sxx,float syy)
		{
			X=x;Y=y;Theta=th;sY=syy;sX=sxx;
		}
		public Transform(){}
		public float X=0;
		public float Y=0;
		public float Theta=0;
		public float sX=1;
		public float sY=1;
		
		public override void ToMat(ref SharpDX.Mathematics.Interop.RawMatrix3x2 mat){
			mat.M11=(float)(sX*Math.Cos(Theta));
			mat.M12=(float)(sY*-Math.Sin(Theta));
			mat.M21=(float)(sX*Math.Sin(Theta));
			mat.M22=(float)(sY*Math.Cos(Theta));
			mat.M31=X;
			mat.M32=Y;
		}
//		public static Transform Normal(){
			
//		}
	}
}
