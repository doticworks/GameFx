/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/12/10
 * 时间: 17:12
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace doticworks.GameFx.COMMON
{
	/// <summary>
	/// Description of Vector2.
	/// </summary>
	public class Vector2
	{
		public Vector2(){
			_x=0;_y=0;
		}
		public Vector2(Vector2 vec){
			_x=vec.X;_y=vec.Y;
		}
		public Vector2(float X,float Y)
		{
			
		}
		float _x;
		float _y;
		public float X{
			get{
				return _x;
			}set{
				_x=value;
			}
		}
		public float Y{
			get{
				return _y;
			}set{
				_y=value;
			}
		}
		public float ThetaD{
			get{
				return (float)(ThetaR/(2*Math.PI)*180);
			}set{
				ThetaR=(float)((value/180)*2*Math.PI);
			}
		}
		public float ThetaR{
			get{
				return (float)Math.Atan2(-Y,-X);
			}set{
				float temp=Mod;
				_x=(float)(temp*Math.Sin(value));
				_y=(float)(temp*Math.Cos(value));
			}
		}
		public float Mod{
			get{
				return (float)Math.Sqrt(_x*_x+_y*_y);
			}set{
				float temp=Mod;
				_x=_x/temp*value;
				_y=_y/temp*value;
			}
		}
		#region Rotate
		public Vector2 RotateR(Vector2 vec){
			ThetaR=ThetaR+vec.ThetaR;return this;
		}
		public Vector2 RotateR(float theta){
			ThetaR=ThetaR+theta;return this;
		}
		public Vector2 RotateD(Vector2 vec){
			ThetaD=ThetaD+vec.ThetaD;return this;
		}
		public Vector2 RotateD(float theta){
			ThetaD=ThetaD+theta;return this;
		}
		#endregion
		#region Calc
		public Vector2 Add(Vector2 vec){
			_x+=vec.X;_y+=vec.Y;return this;
		}
		public Vector2 Add(float len){
			Mod=Mod+len;return this;
		}
		public Vector2 Minus(Vector2 vec){
			_x-=vec.X;_y-=vec.Y;return this;
		}
		public Vector2 Minus(float len){
			Mod=Mod-len;return this;
		}
		public float MultiPly(Vector2 vec){
			return _x*vec.X+_y*vec.Y;
		}
		public Vector2 MultiPly(float len){
			Mod=Mod*len;return this;
		}
		public Vector2 Divide(float len){
			Mod=Mod/len;return this;
		}
		#endregion
		#region Static
		public static Vector2 RotateR(Vector2 v1,Vector2 v2){
			Vector2 t=new Vector2(v1);
			t.ThetaR=t.ThetaR+v2.ThetaR;return t;
		}
		public static Vector2 RotateR(Vector2 vec,float theta){
			Vector2 t=new Vector2(vec);
			t.ThetaR=t.ThetaR+theta;return t;
		}
		public static Vector2 RotateD(Vector2 vec1,Vector2 vec){
			Vector2 t=new Vector2(vec1);
			t.ThetaD=t.ThetaD+vec.ThetaD;return t;
		}
		public static Vector2 RotateD(Vector2 vec,float theta){
			Vector2 t=new Vector2(vec);
			t.ThetaD=t.ThetaD+theta;return t;
		}
		public static Vector2 Add(Vector2 v1,Vector2 v2){
			return new Vector2(v1).Add(v2);
		}
		public static Vector2 Add(Vector2 v1,float len){
			return new Vector2(v1).Add(len);
		}
		public Vector2 Minus(Vector2 vec,Vector2 vec1){
			Vector2 t=new Vector2(vec);
			t._x-=vec1.X;t._y-=vec1.Y;return t;
		}
		public Vector2 Minus(Vector2 vec,float len){
			Vector2 t=new Vector2(vec);
			t.Mod=t.Mod-len;return t;
		}
		public float MultiPly(Vector2 v1,Vector2 vec){
			return v1._x*vec.X+v1._y*vec.Y;
		}
		public Vector2 MultiPly(Vector2 v1,float len){
			Vector2 t=new Vector2(v1);
			v1.Mod=v1.Mod*len;return t;
		}
		public Vector2 Divide(Vector2 v1,float len){
			Vector2 t=new Vector2(v1);
			t.Mod=t.Mod/len;return t;
		}
		#endregion
		
	}
}
