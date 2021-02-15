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
	public class Transform
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
		
	/*	public Matrix matrix{
			get{
				return Matrix.Transformation(sX,sY,Theta,X,Y);
			}set{
				X=value.TranslationVector.X;Y=value.TranslationVector.Y;
				sX=value.ScaleVector.X;sY=value.ScaleVector.Y;
				Theta=value;
			}
		}*/
		
		public Vector2 Position{
			get{return new Vector2(X,Y);}
			set{X=value.X;Y=value.Y;}
		}
		public Vector2 Toward{
			get{return new Vector2((float)Math.Cos(Theta),-(float)Math.Sin(Theta));}
			set{Theta=(float)value.Angle;}
		}
		public Transform Copy(){
			return new Transform(X,Y,Theta,sX,sY);
		}
	/*	public Vector2 Scaling{
			get{
				
			}set{
				
			}
		}*/
		public Transform Overlay(Transform child){
		X+=(float)(child.X*Math.Cos(Theta)-child.Y*Math.Sin(Theta));
		Y+=(float)(child.Y*Math.Cos(Theta)+child.X*Math.Sin(Theta));
			Theta+=child.Theta;
			//TODO sx,sy
			return this;
		}
	/*	public void Overlay(Matrix child){
			Matrix tmp=matrix*child;
			Vector2 tv=Matrix.TransformPoint(matrix,new Vector2(child.M31,child.M32));
			tmp.M31=tv.X;tmp.M32=tv.Y;
			matrix=tmp;
		//	matrix=child*matrix;
		}*/
		public void ToMat(ref SharpDX.Mathematics.Interop.RawMatrix3x2 mat){
			mat.M11=(float)(sX*Math.Cos(Theta));
			mat.M12=(float)(-Math.Sin(Theta));
			mat.M21=(float)(Math.Sin(Theta));
			mat.M22=(float)(sY*Math.Cos(Theta));
			mat.M31=X;
			mat.M32=Y;
		}
		public override string ToString(){
		return X.ToString()+" "+Y.ToString()+" "+Theta.ToString()+" "+sX.ToString()+" "+sY.ToString()+"";
		}
//		public static Transform Normal(){
			
//		}
	}
}
