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
	public struct Vector2//:SharpDX.Vector2
	{
		public void RawVector(ref SharpDX.Mathematics.Interop.RawVector2 value){
			value.X=X;value.Y=Y;
		}
/*		public const Vector2 Zero = default(Vector2);
		public const Vector2 UnitX =Vector2();//= Vector2(1f, 0f);
		public const Vector2 UnitY = Vector2(0f, 1f);
		public const Vector2 One = Vector2(1f, 1f);
		*/
		public static readonly Vector2 Zero = default(Vector2);

		public static readonly Vector2 UnitX = new Vector2(1f, 0f);

		public static readonly Vector2 UnitY = new Vector2(0f, 1f);

		public static readonly Vector2 One = new Vector2(1f, 1f);
		
		public float X;
		public float Y;
		
		public float Angle{
			get{
				return (float)Math.Atan2(-Y,X);
			}set{
				Vector2 tmp=new Vector2(value,this.Length(),0);
			}
		}
		
		public bool IsNormalized {
			get {
				return 1f==(this.X * this.X + this.Y * this.Y);
			}
		}

		public bool IsZero {
			get {
				return this.X == 0f && this.Y == 0f;
			}
		}

		public float this[int index] {
			get {
				if (index == 0) {
					return this.X;
				}
				if (index != 1) {
					throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
				}
				return this.Y;
			}
			set {
				if (index == 0) {
					this.X = value;
					return;
				}
				if (index != 1) {
					throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
				}
				this.Y = value;
			}
		}

		public Vector2(float angle,float len,int haha)
		{
			this.X = (float)Math.Cos(angle)*len;
			this.Y = -(float)Math.Sin(angle)*len;
		}

		public Vector2(float x, float y)
		{
			this.X = x;
			this.Y = y;
		}

		public Vector2(float[] values)
		{
			if (values == null) {
				throw new ArgumentNullException("values");
			}
			if (values.Length != 2) {
				throw new ArgumentOutOfRangeException("values", "There must be two and only two input values for Vector2.");
			}
			this.X = values[0];
			this.Y = values[1];
		}

		public float Length()
		{
			return (float)Math.Sqrt((double)(this.X * this.X + this.Y * this.Y));
		}

		public float LengthSquared()
		{
			return this.X * this.X + this.Y * this.Y;
		}

		public Vector2 Normalize()
		{
			float num = this.Length();
			if (!(num==0)) {
				float num2 = 1f / num;
				this.X *= num2;
				this.Y *= num2;
			}
			return this;
		}

		public float[] ToArray()
		{
			return new float[] {
				this.X,
				this.Y
			};
		}
		public static Vector2 Add(Vector2 left, Vector2 right)
		{
			return new Vector2(left.X + right.X, left.Y + right.Y);
		}
		public static Vector2 Add(Vector2 left, float right)
		{
			return new Vector2(left.X + right, left.Y + right);
		}
		public static Vector2 Lengthen(Vector2 left, float len)
		{
			float l=len/1.414f;
			return new Vector2(left.X +l, left.Y +l);
		}
		public static Vector2 Subtract(Vector2 left, Vector2 right)
		{
			return new Vector2(left.X - right.X, left.Y - right.Y);
		}
		public static Vector2 Subtract(Vector2 left, float right)
		{
			return new Vector2(left.X - right, left.Y - right);
		}
		public static Vector2 Multiply(Vector2 value, float scale)
		{
			return new Vector2(value.X * scale, value.Y * scale);
		}
		public static float DotMultiply(Vector2 value,Vector2 value2)
		{
			return value.X * value2.X+value.Y *value2.X;
		}
		public static float CrossMultiply(Vector2 value,Vector2 value2)
		{
			return value.X * value2.Y-value.Y *value2.X;
		}
		public static Vector2 Multiply(Vector2 left, Vector2 right)
		{
			return new Vector2(left.X * right.X, left.Y * right.Y);
		}
		public static Vector2 Divide(Vector2 value, float scale)
		{
			return new Vector2(value.X / scale, value.Y / scale);
		}
		public static Vector2 Divide(float scale, Vector2 value)
		{
			return new Vector2(scale / value.X, scale / value.Y);
		}
		public static Vector2 Negate(Vector2 value)
		{
			return new Vector2(-value.X, -value.Y);
		}
		public static Vector2 Abs(Vector2 value)
		{
			return new Vector2((value.X > 0f) ? value.X : (-value.X), (value.Y > 0f) ? value.Y : (-value.Y));
		}
		public static void Barycentric(ref Vector2 value1, ref Vector2 value2, ref Vector2 value3, float amount1, float amount2, out Vector2 result)
		{
			result = new Vector2(value1.X + amount1 * (value2.X - value1.X) + amount2 * (value3.X - value1.X), value1.Y + amount1 * (value2.Y - value1.Y) + amount2 * (value3.Y - value1.Y));
		}
		public static Vector2 Barycentric(Vector2 value1, Vector2 value2, Vector2 value3, float amount1, float amount2)
		{
			Vector2 result;
			Vector2.Barycentric(ref value1, ref value2, ref value3, amount1, amount2, out result);
			return result;
		}
		public static void Clamp(ref Vector2 value, ref Vector2 min, ref Vector2 max, out Vector2 result)
		{
			float num = value.X;
			num = ((num > max.X) ? max.X : num);
			num = ((num < min.X) ? min.X : num);
			float num2 = value.Y;
			num2 = ((num2 > max.Y) ? max.Y : num2);
			num2 = ((num2 < min.Y) ? min.Y : num2);
			result = new Vector2(num, num2);
		}
		public static Vector2 Clamp(Vector2 value, Vector2 min, Vector2 max)
		{
			Vector2 result;
			Vector2.Clamp(ref value, ref min, ref max, out result);
			return result;
		}
		public void Saturate()
		{
			this.X = ((this.X < 0f) ? 0f : ((this.X > 1f) ? 1f : this.X));
			this.Y = ((this.Y < 0f) ? 0f : ((this.Y > 1f) ? 1f : this.Y));
		}
		public static float Distance(Vector2 value1, Vector2 value2)
		{
			float arg_1B_0 = value1.X - value2.X;
			float num = value1.Y - value2.Y;
			return (float)Math.Sqrt((double)(arg_1B_0 * arg_1B_0 + num * num));
		}
		public static float DistanceSquared(Vector2 value1, Vector2 value2)
		{
			float arg_1B_0 = value1.X - value2.X;
			float num = value1.Y - value2.Y;
			return arg_1B_0 * arg_1B_0 + num * num;
		}
		public static float Dot(Vector2 left, Vector2 right)
		{
			return left.X * right.X + left.Y * right.Y;
		}
		public static Vector2 Normalize(Vector2 value)
		{
			value.Normalize();
			return value;
		}
		public static void Hermite(ref Vector2 value1, ref Vector2 tangent1, ref Vector2 value2, ref Vector2 tangent2, float amount, out Vector2 result)
		{Vector2 xresult=Vector2.Zero;
			float num = amount * amount;
			float num2 = amount * num;
			float num3 = 2f * num2 - 3f * num + 1f;
			float num4 = -2f * num2 + 3f * num;
			float num5 = num2 - 2f * num + amount;
			float num6 = num2 - num;
			xresult.X = value1.X * num3 + value2.X * num4 + tangent1.X * num5 + tangent2.X * num6;
			xresult.Y = value1.Y * num3 + value2.Y * num4 + tangent1.Y * num5 + tangent2.Y * num6;
		result=xresult;}

		public static Vector2 Hermite(Vector2 value1, Vector2 tangent1, Vector2 value2, Vector2 tangent2, float amount)
		{
			Vector2 result;
			Vector2.Hermite(ref value1, ref tangent1, ref value2, ref tangent2, amount, out result);
			return result;
		}

		public static void CatmullRom(ref Vector2 value1, ref Vector2 value2, ref Vector2 value3, ref Vector2 value4, float amount, out Vector2 result)
		{Vector2 xresult=Vector2.Zero;
			float num = amount * amount;
			float num2 = amount * num;
			xresult.X = 0.5f * (2f * value2.X + (-value1.X + value3.X) * amount + (2f * value1.X - 5f * value2.X + 4f * value3.X - value4.X) * num + (-value1.X + 3f * value2.X - 3f * value3.X + value4.X) * num2);
			xresult.Y = 0.5f * (2f * value2.Y + (-value1.Y + value3.Y) * amount + (2f * value1.Y - 5f * value2.Y + 4f * value3.Y - value4.Y) * num + (-value1.Y + 3f * value2.Y - 3f * value3.Y + value4.Y) * num2);
		result=xresult;}
		public static Vector2 CatmullRom(Vector2 value1, Vector2 value2, Vector2 value3, Vector2 value4, float amount)
		{
			Vector2 result;
			Vector2.CatmullRom(ref value1, ref value2, ref value3, ref value4, amount, out result);
			return result;
		}
		public static void Max(ref Vector2 left, ref Vector2 right, out Vector2 result)
		{Vector2 xresult=Vector2.Zero;
			xresult.X = ((left.X > right.X) ? left.X : right.X);
			xresult.Y = ((left.Y > right.Y) ? left.Y : right.Y);result=xresult;
		}
		public static Vector2 Max(Vector2 left, Vector2 right)
		{
			Vector2 result;
			Vector2.Max(ref left, ref right, out result);
			return result;
		}
		public static void Min(ref Vector2 left, ref Vector2 right, out Vector2 result)
		{
			Vector2 xresult=Vector2.Zero;
			xresult.X = ((left.X < right.X) ? left.X : right.X);
			xresult.Y = ((left.Y < right.Y) ? left.Y : right.Y);
			result=xresult;
		}
		public static Vector2 Min(Vector2 left, Vector2 right)
		{
			Vector2 result;
			Vector2.Min(ref left, ref right, out result);
			return result;
		}
		public static void Reflect(ref Vector2 vector, ref Vector2 normal, out Vector2 result)
		{
			Vector2 xresult=Vector2.Zero;
			float num = vector.X * normal.X + vector.Y * normal.Y;
			xresult.X = vector.X - 2f * num * normal.X;
			xresult.Y = vector.Y - 2f * num * normal.Y;
			result=xresult;
		}
		public static Vector2 Reflect(Vector2 vector, Vector2 normal)
		{
			Vector2 result;
			Vector2.Reflect(ref vector, ref normal, out result);
			return result;
		}
		public static void Orthogonalize(Vector2[] destination, params Vector2[] source)
		{
			if (source == null) {
				throw new ArgumentNullException("source");
			}
			if (destination == null) {
				throw new ArgumentNullException("destination");
			}
			if (destination.Length < source.Length) {
				throw new ArgumentOutOfRangeException("destination", "The destination array must be of same length or larger length than the source array.");
			}
			for (int i = 0; i < source.Length; i++) {
				Vector2 vector = source[i];
				for (int j = 0; j < i; j++) {
					vector -= Vector2.Dot(destination[j], vector) / Vector2.Dot(destination[j], destination[j]) * destination[j];
				}
				destination[i] = vector;
			}
		}
		public static void Orthonormalize(Vector2[] destination, params Vector2[] source)
		{
			if (source == null) {
				throw new ArgumentNullException("source");
			}
			if (destination == null) {
				throw new ArgumentNullException("destination");
			}
			if (destination.Length < source.Length) {
				throw new ArgumentOutOfRangeException("destination", "The destination array must be of same length or larger length than the source array.");
			}
			for (int i = 0; i < source.Length; i++) {
				Vector2 vector = source[i];
				for (int j = 0; j < i; j++) {
					vector -= Vector2.Dot(destination[j], vector) * destination[j];
				}
				vector.Normalize();
				destination[i] = vector;
			}
		}
	/*	public static void Transform(ref Vector2 vector, ref Matrix transform, out Vector4 result)
		{
			result = new Vector4(vector.X * transform.M11 + vector.Y * transform.M21 + transform.M41, vector.X * transform.M12 + vector.Y * transform.M22 + transform.M42, vector.X * transform.M13 + vector.Y * transform.M23 + transform.M43, vector.X * transform.M14 + vector.Y * transform.M24 + transform.M44);
		}
		public static Vector4 Transform(Vector2 vector, Matrix transform)
		{
			Vector4 result;
			Vector2.Transform(ref vector, ref transform, out result);
			return result;
		}
		public static void Transform(Vector2[] source, ref Matrix transform, Vector4[] destination)
		{
			if (source == null) {
				throw new ArgumentNullException("source");
			}
			if (destination == null) {
				throw new ArgumentNullException("destination");
			}
			if (destination.Length < source.Length) {
				throw new ArgumentOutOfRangeException("destination", "The destination array must be of same length or larger length than the source array.");
			}
			for (int i = 0; i < source.Length; i++) {
				Vector2.Transform(ref source[i], ref transform, out destination[i]);
			}
		}
		public static void TransformCoordinate(ref Vector2 coordinate, ref Matrix transform, out Vector2 result)
		{
			Vector4 vector = default(Vector4);
			vector.X = coordinate.X * transform.M11 + coordinate.Y * transform.M21 + transform.M41;
			vector.Y = coordinate.X * transform.M12 + coordinate.Y * transform.M22 + transform.M42;
			vector.Z = coordinate.X * transform.M13 + coordinate.Y * transform.M23 + transform.M43;
			vector.W = 1f / (coordinate.X * transform.M14 + coordinate.Y * transform.M24 + transform.M44);
			result = new Vector2(vector.X * vector.W, vector.Y * vector.W);
		}
		public static Vector2 TransformCoordinate(Vector2 coordinate, Matrix transform)
		{
			Vector2 result;
			Vector2.TransformCoordinate(ref coordinate, ref transform, out result);
			return result;
		}
		public static void TransformCoordinate(Vector2[] source, ref Matrix transform, Vector2[] destination)
		{
			if (source == null) {
				throw new ArgumentNullException("source");
			}
			if (destination == null) {
				throw new ArgumentNullException("destination");
			}
			if (destination.Length < source.Length) {
				throw new ArgumentOutOfRangeException("destination", "The destination array must be of same length or larger length than the source array.");
			}
			for (int i = 0; i < source.Length; i++) {
				Vector2.TransformCoordinate(ref source[i], ref transform, out destination[i]);
			}
		}
		public static void TransformNormal(ref Vector2 normal, ref Matrix transform, out Vector2 result)
		{
			result = new Vector2(normal.X * transform.M11 + normal.Y * transform.M21, normal.X * transform.M12 + normal.Y * transform.M22);
		}
		public static Vector2 TransformNormal(Vector2 normal, Matrix transform)
		{
			Vector2 result;
			Vector2.TransformNormal(ref normal, ref transform, out result);
			return result;
		}

		public static void TransformNormal(Vector2[] source, ref Matrix transform, Vector2[] destination)
		{
			if (source == null) {
				throw new ArgumentNullException("source");
			}
			if (destination == null) {
				throw new ArgumentNullException("destination");
			}
			if (destination.Length < source.Length) {
				throw new ArgumentOutOfRangeException("destination", "The destination array must be of same length or larger length than the source array.");
			}
			for (int i = 0; i < source.Length; i++) {
				Vector2.TransformNormal(ref source[i], ref transform, out destination[i]);
			}
		}*/
		public static Vector2 operator +(Vector2 left, Vector2 right) {
			return new Vector2(left.X + right.X, left.Y + right.Y);
		}

		public static Vector2 operator *(Vector2 left, Vector2 right) {
			return new Vector2(left.X * right.X, left.Y * right.Y);
		}

		public static Vector2 operator +(Vector2 value) {
			return value;
		}

		public static Vector2 operator -(Vector2 left, Vector2 right) {
			return new Vector2(left.X - right.X, left.Y - right.Y);
		}

		public static Vector2 operator -(Vector2 value) {
			return new Vector2(-value.X, -value.Y);
		}

		public static Vector2 operator *(float scale, Vector2 value) {
			return new Vector2(value.X * scale, value.Y * scale);
		}

		public static Vector2 operator *(Vector2 value, float scale) {
			return new Vector2(value.X * scale, value.Y * scale);
		}

		public static Vector2 operator /(Vector2 value, float scale) {
			return new Vector2(value.X / scale, value.Y / scale);
		}

		public static Vector2 operator /(float scale, Vector2 value) {
			return new Vector2(scale / value.X, scale / value.Y);
		}

		public static Vector2 operator /(Vector2 value, Vector2 scale) {
			return new Vector2(value.X / scale.X, value.Y / scale.Y);
		}

		public static Vector2 operator +(Vector2 value, float scalar) {
			return new Vector2(value.X + scalar, value.Y + scalar);
		}

		public static Vector2 operator +(float scalar, Vector2 value) {
			return new Vector2(scalar + value.X, scalar + value.Y);
		}

		public static Vector2 operator -(Vector2 value, float scalar) {
			return new Vector2(value.X - scalar, value.Y - scalar);
		}

		public static Vector2 operator -(float scalar, Vector2 value) {
			return new Vector2(scalar - value.X, scalar - value.Y);
		}

	//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Vector2 left, Vector2 right) {
			return left.Equals(right);
		}

	//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(Vector2 left, Vector2 right) {
			return !left.Equals(right);
		}
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", new object[] {
				this.X,
				this.Y
			});
		}
		public string ToString(string format)
		{
			if (format == null) {
				return this.ToString();
			}
			return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", new object[] {
				this.X.ToString(format, CultureInfo.CurrentCulture),
				this.Y.ToString(format, CultureInfo.CurrentCulture)
			});
		}
		public string ToString(IFormatProvider formatProvider)
		{
			return string.Format(formatProvider, "X:{0} Y:{1}", new object[] {
				this.X,
				this.Y
			});
		}
		public string ToString(string format, IFormatProvider formatProvider)
		{
			if (format == null) {
				this.ToString(formatProvider);
			}
			return string.Format(formatProvider, "X:{0} Y:{1}", new object[] {
				this.X.ToString(format, formatProvider),
				this.Y.ToString(format, formatProvider)
			});
		}
		public override int GetHashCode()
		{
			return this.X.GetHashCode() * 397 ^ this.Y.GetHashCode();
		}
		public override bool Equals(object value)
		{
			if (!(value is Vector2)) {
				return false;
			}
			Vector2 vector = (Vector2)value;
			return X==vector.X&&Y==vector.Y;
		}
	}
}
