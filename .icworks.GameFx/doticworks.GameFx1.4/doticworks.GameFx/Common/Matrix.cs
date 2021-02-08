/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2021/1/26
 * 时间: 17:22
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Globalization;
namespace doticworks.GameFx.Common
{
	/// <summary>
	/// Description of Transform.
	/// </summary>
	public struct Matrix{
		public static readonly Matrix Identity = new Matrix(1f, 0f, 0f, 1f, 0f, 0f);

		public float M11;

		public float M12;

		public float M21;

		public float M22;

		public float M31;

		public float M32;

		public Vector2 Row1 {
			get {
				return new Vector2(this.M11, this.M12);
			}
			set {
				this.M11 = value.X;
				this.M12 = value.Y;
			}
		}

		public Vector2 Row2 {
			get {
				return new Vector2(this.M21, this.M22);
			}
			set {
				this.M21 = value.X;
				this.M22 = value.Y;
			}
		}

		public Vector2 Row3 {
			get {
				return new Vector2(this.M31, this.M32);
			}
			set {
				this.M31 = value.X;
				this.M32 = value.Y;
			}
		}
		public Vector2 TranslationVector {
			get {
				return new Vector2(this.M31, this.M32);
			}
			set {
				this.M31 = value.X;
				this.M32 = value.Y;
			}
		}
		public Vector2 ScaleVector {
			get {
				return new Vector2(this.M11, this.M22);
			}
			set {
				this.M11 = value.X;
				this.M22 = value.Y;
			}
		}
		public float this[int index] {
			get {
				switch (index) {
					case 0:
						return this.M11;
					case 1:
						return this.M12;
					case 2:
						return this.M21;
					case 3:
						return this.M22;
					case 4:
						return this.M31;
					case 5:
						return this.M32;
					default:
						throw new ArgumentOutOfRangeException("index", "Indices for Matrix run from 0 to 5, inclusive.");
				}
			}
			set {
				switch (index) {
					case 0:
						this.M11 = value;
						return;
					case 1:
						this.M12 = value;
						return;
					case 2:
						this.M21 = value;
						return;
					case 3:
						this.M22 = value;
						return;
					case 4:
						this.M31 = value;
						return;
					case 5:
						this.M32 = value;
						return;
					default:
						throw new ArgumentOutOfRangeException("index", "Indices for Matrix run from 0 to 5, inclusive.");
				}
			}
		}

		public float this[int row, int column] {
			get {
				if (row < 0 || row > 2) {
					throw new ArgumentOutOfRangeException("row", "Rows and columns for matrices run from 0 to 2, inclusive.");
				}
				if (column < 0 || column > 1) {
					throw new ArgumentOutOfRangeException("column", "Rows and columns for matrices run from 0 to 1, inclusive.");
				}
				return this[row * 2 + column];
			}
			set {
				if (row < 0 || row > 2) {
					throw new ArgumentOutOfRangeException("row", "Rows and columns for matrices run from 0 to 2, inclusive.");
				}
				if (column < 0 || column > 1) {
					throw new ArgumentOutOfRangeException("column", "Rows and columns for matrices run from 0 to 1, inclusive.");
				}
				this[row * 2 + column] = value;
			}
		}

		public Matrix(float value)
		{
			this.M32 = value;
			this.M31 = value;
			this.M22 = value;
			this.M21 = value;
			this.M12 = value;
			this.M11 = value;
		}

		public Matrix(float M11, float M12, float M21, float M22, float M31, float M32)
		{
			this.M11 = M11;
			this.M12 = M12;
			this.M21 = M21;
			this.M22 = M22;
			this.M31 = M31;
			this.M32 = M32;
		}

		public Matrix(float[] values)
		{
			if (values == null) {
				throw new ArgumentNullException("values");
			}
			if (values.Length != 6) {
				throw new ArgumentOutOfRangeException("values", "There must be six input values for Matrix.");
			}
			this.M11 = values[0];
			this.M12 = values[1];
			this.M21 = values[2];
			this.M22 = values[3];
			this.M31 = values[4];
			this.M32 = values[5];
		}

		public float[] ToArray()
		{
			return new float[] {
				this.M11,
				this.M12,
				this.M21,
				this.M22,
				this.M31,
				this.M32
			};
		}

		public static void Add(ref Matrix left, ref Matrix right, out Matrix resultx)
		{
			Matrix result=Matrix.Identity;
			result.M11 = left.M11 + right.M11;
			result.M12 = left.M12 + right.M12;
			result.M21 = left.M21 + right.M21;
			result.M22 = left.M22 + right.M22;
			result.M31 = left.M31 + right.M31;
			result.M32 = left.M32 + right.M32;resultx=result;
		}

		public static Matrix Add(Matrix left, Matrix right)
		{
			Matrix result;
			Matrix.Add(ref left, ref right, out result);
			return result;
		}
		public static void Subtract(ref Matrix left, ref Matrix right, out Matrix resultx)
		{Matrix result=Matrix.Identity;
			result.M11 = left.M11 - right.M11;
			result.M12 = left.M12 - right.M12;
			result.M21 = left.M21 - right.M21;
			result.M22 = left.M22 - right.M22;
			result.M31 = left.M31 - right.M31;
			result.M32 = left.M32 - right.M32;resultx=result;
		}

		public static Matrix Subtract(Matrix left, Matrix right)
		{
			Matrix result;
			Matrix.Subtract(ref left, ref right, out result);
			return result;
		}
		public static void Multiply(ref Matrix left, float right, out Matrix resultx)
		{Matrix result=Matrix.Identity;
			result.M11 = left.M11 * right;
			result.M12 = left.M12 * right;
			result.M21 = left.M21 * right;
			result.M22 = left.M22 * right;
			result.M31 = left.M31 * right;
			result.M32 = left.M32 * right;resultx=result;
		}

		public static Matrix Multiply(Matrix left, float right)
		{
			Matrix result;
			Matrix.Multiply(ref left, right, out result);
			return result;
		}

		public static void Multiply(ref Matrix left, ref Matrix right, out Matrix result)
		{
			result = new Matrix(
				M11 = left.M11 * right.M11 + left.M12 * right.M21,
				M12 = left.M11 * right.M12 + left.M12 * right.M22,
				M21 = left.M21 * right.M11 + left.M22 * right.M21,
				M22 = left.M21 * right.M12 + left.M22 * right.M22,
				M31 = left.M31 * right.M11 + left.M32 * right.M21 + right.M31,
				M32 = left.M31 * right.M12 + left.M32 * right.M22 + right.M32
			);
		}
		public static Matrix Multiply(Matrix left, Matrix right)
		{
			Matrix result;
			Matrix.Multiply(ref left, ref right, out result);
			return result;
		}
		public static void Divide(ref Matrix left, float right, out Matrix resultx)
		{Matrix result=Matrix.Identity;
			float num = 1f / right;
			result.M11 = left.M11 * num;
			result.M12 = left.M12 * num;
			result.M21 = left.M21 * num;
			result.M22 = left.M22 * num;
			result.M31 = left.M31 * num;
			result.M32 = left.M32 * num;resultx=result;
		}

		public static void Divide(ref Matrix left, ref Matrix right, out Matrix resultx)
		{Matrix result=Matrix.Identity;
			result.M11 = left.M11 / right.M11;
			result.M12 = left.M12 / right.M12;
			result.M21 = left.M21 / right.M21;
			result.M22 = left.M22 / right.M22;
			result.M31 = left.M31 / right.M31;
			result.M32 = left.M32 / right.M32;resultx=result;
		}

		public static void Negate(ref Matrix value, out Matrix resultx)
		{Matrix result=Matrix.Identity;
			result.M11 = -value.M11;
			result.M12 = -value.M12;
			result.M21 = -value.M21;
			result.M22 = -value.M22;
			result.M31 = -value.M31;
			result.M32 = -value.M32;resultx=result;
		}

		public static Matrix Negate(Matrix value)
		{
			Matrix result;
			Matrix.Negate(ref value, out result);
			return result;
		}
		public static void Scaling(ref Vector2 scale, out Matrix result)
		{
			Matrix.Scaling(scale.X, scale.Y, out result);
		}

		public static Matrix Scaling(Vector2 scale)
		{
			Matrix result;
			Matrix.Scaling(ref scale, out result);
			return result;
		}
		public static void Scaling(float x, float y, out Matrix resultx)
		{Matrix result=Matrix.Identity;
			result = Matrix.Identity;
			result.M11 = x;
			result.M22 = y;resultx=result;
		}

		public static Matrix Scaling(float x, float y)
		{
			Matrix result;
			Matrix.Scaling(x, y, out result);
			return result;
		}

		public static void Scaling(float scale, out Matrix resultx)
		{Matrix result=Matrix.Identity;
			result = Matrix.Identity;
			result.M22 = scale;
			result.M11 = scale;resultx=result;
		}

		public static Matrix Scaling(float scale)
		{
			Matrix result;
			Matrix.Scaling(scale, out result);
			return result;
		}

		public static Matrix Scaling(float x, float y, Vector2 center)
		{
			Matrix result;
			result.M11 = x;
			result.M12 = 0f;
			result.M21 = 0f;
			result.M22 = y;
			result.M31 = center.X - x * center.X;
			result.M32 = center.Y - y * center.Y;
			return result;
		}

		public static void Scaling(float x, float y, ref Vector2 center, out Matrix resultx)
		{Matrix result=Matrix.Identity;
			Matrix matrix3x;
			matrix3x.M11 = x;
			matrix3x.M12 = 0f;
			matrix3x.M21 = 0f;
			matrix3x.M22 = y;
			matrix3x.M31 = center.X - x * center.X;
			matrix3x.M32 = center.Y - y * center.Y;
			result = matrix3x;resultx=result;
		}

		public float Determinant()
		{
			return this.M11 * this.M22 - this.M12 * this.M21;
		}
		public static void Rotation(float angle, out Matrix resultx)
		{Matrix result=Matrix.Identity;
			float num = (float)Math.Cos((double)angle);
			float num2 = (float)Math.Sin((double)angle);
			result = Matrix.Identity;
			result.M11 = num;
			result.M12 = num2;
			result.M21 = -num2;
			result.M22 = num;resultx=result;
		}

		public static Matrix Rotation(float angle)
		{
			Matrix result;
			Matrix.Rotation(angle, out result);
			return result;
		}

		public static Matrix Rotation(float angle, Vector2 center)
		{
			Matrix result;
			Matrix.Rotation(angle, center, out result);
			return result;
		}

		public static void Rotation(float angle, Vector2 center, out Matrix resultx)
		{Matrix result=Matrix.Identity;
			result = Matrix.Translation(-center) * Matrix.Rotation(angle) * Matrix.Translation(center);resultx=result;
		}
		public static void Transformation(float xScale, float yScale, float angle, float xOffset, float yOffset, out Matrix result)
		{
			result = Matrix.Scaling(xScale, yScale) * Matrix.Rotation(angle) * Matrix.Translation(xOffset, yOffset);
		}
		public static Matrix Transformation(float xScale, float yScale, float angle, float xOffset, float yOffset)
		{
			Matrix result;
			Matrix.Transformation(xScale, yScale, angle, xOffset, yOffset, out result);
			return result;
		}
		public static void Translation(ref Vector2 value, out Matrix resultx)
		{Matrix result=Matrix.Identity;
			Matrix.Translation(value.X, value.Y, out result);resultx=result;
		}

		public static Matrix Translation(Vector2 value)
		{
			Matrix result;
			Matrix.Translation(ref value, out result);
			return result;
		}

		public static void Translation(float x, float y, out Matrix resultx)
		{Matrix result=Matrix.Identity;
			result = Matrix.Identity;
			result.M31 = x;
			result.M32 = y;resultx=result;
		}

		public static Matrix Translation(float x, float y)
		{
			Matrix result;
			Matrix.Translation(x, y, out result);
			return result;
		}

		public static Vector2 TransformPoint(Matrix matrix, Vector2 point)
		{
			Vector2 result;
			result.X = point.X * matrix.M11 + point.Y * matrix.M21 + matrix.M31;
			result.Y = point.X * matrix.M12 + point.Y * matrix.M22 + matrix.M32;
			return result;
		}

		public static void TransformPoint(ref Matrix matrix, ref Vector2 point, out Vector2 resultx)
		{
			Vector2 vector=Vector2.Zero;
			vector.X = point.X * matrix.M11 + point.Y * matrix.M21 + matrix.M31;
			vector.Y = point.X * matrix.M12 + point.Y * matrix.M22 + matrix.M32;
			resultx = vector;
		}
		public static Matrix Skew(float angleX, float angleY)
		{
			Matrix result;
			Matrix.Skew(angleX, angleY, out result);
			return result;
		}

		public static void Skew(float angleX, float angleY, out Matrix resultx)
		{Matrix result=Matrix.Identity;
			result = Matrix.Identity;
			result.M12 = (float)Math.Tan((double)angleX);
			result.M21 = (float)Math.Tan((double)angleY);resultx=result;
		}
		public static Matrix operator +(Matrix left, Matrix right) {
			Matrix result;
			Matrix.Add(ref left, ref right, out result);
			return result;
		}

		public static Matrix operator +(Matrix value) {
			return value;
		}

		public static Matrix operator -(Matrix left, Matrix right) {
			Matrix result;
			Matrix.Subtract(ref left, ref right, out result);
			return result;
		}

		public static Matrix operator -(Matrix value) {
			Matrix result;
			Matrix.Negate(ref value, out result);
			return result;
		}

		public static Matrix operator *(float left, Matrix right) {
			Matrix result;
			Matrix.Multiply(ref right, left, out result);
			return result;
		}

		public static Matrix operator *(Matrix left, float right) {
			Matrix result;
			Matrix.Multiply(ref left, right, out result);
			return result;
		}

		public static Matrix operator *(Matrix left, Matrix right) {
			Matrix result;
			Matrix.Multiply(ref left, ref right, out result);
			return result;
		}

		public static Matrix operator /(Matrix left, float right) {
			Matrix result;
			Matrix.Divide(ref left, right, out result);
			return result;
		}

		public static Matrix operator /(Matrix left, Matrix right) {
			Matrix result;
			Matrix.Divide(ref left, ref right, out result);
			return result;
		}

		public static bool operator ==(Matrix left, Matrix right) {
			return left.Equals(ref right);
		}

		public static bool operator !=(Matrix left, Matrix right) {
			return !left.Equals(ref right);
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "[M11:{0} M12:{1}] [M21:{2} M22:{3}] [M31:{4} M32:{5}]", new object[] {
				this.M11,
				this.M12,
				this.M21,
				this.M22,
				this.M31,
				this.M32
			});
		}

		public string ToString(string format)
		{
			if (format == null) {
				return this.ToString();
			}
			return string.Format(format, new object[] {
				CultureInfo.CurrentCulture,
				"[M11:{0} M12:{1}] [M21:{2} M22:{3}] [M31:{4} M32:{5}]",
				this.M11.ToString(format, CultureInfo.CurrentCulture),
				this.M12.ToString(format, CultureInfo.CurrentCulture),
				this.M21.ToString(format, CultureInfo.CurrentCulture),
				this.M22.ToString(format, CultureInfo.CurrentCulture),
				this.M31.ToString(format, CultureInfo.CurrentCulture),
				this.M32.ToString(format, CultureInfo.CurrentCulture)
			});
		}

		public string ToString(IFormatProvider formatProvider)
		{
			return string.Format(formatProvider, "[M11:{0} M12:{1}] [M21:{2} M22:{3}] [M31:{4} M32:{5}]", new object[] {
				this.M11.ToString(formatProvider),
				this.M12.ToString(formatProvider),
				this.M21.ToString(formatProvider),
				this.M22.ToString(formatProvider),
				this.M31.ToString(formatProvider),
				this.M32.ToString(formatProvider)
			});
		}

		public string ToString(string format, IFormatProvider formatProvider)
		{
			if (format == null) {
				return this.ToString(formatProvider);
			}
			return string.Format(format, new object[] {
				formatProvider,
				"[M11:{0} M12:{1}] [M21:{2} M22:{3}] [M31:{4} M32:{5}]",
				this.M11.ToString(format, formatProvider),
				this.M12.ToString(format, formatProvider),
				this.M21.ToString(format, formatProvider),
				this.M22.ToString(format, formatProvider),
				this.M31.ToString(format, formatProvider),
				this.M32.ToString(format, formatProvider)
			});
		}

		public override int GetHashCode()
		{
			return ((((this.M11.GetHashCode() * 397 ^ this.M12.GetHashCode()) * 397 ^ this.M21.GetHashCode()) * 397 ^ this.M22.GetHashCode()) * 397 ^ this.M31.GetHashCode()) * 397 ^ this.M32.GetHashCode();
		}

/*	public override bool Equals(object value)
		{
			if (!(value is Matrix)) {
				return false;
			}
			Matrix matrix3x = (Matrix)value;
			return this.Equals(ref matrix3x);
		}

		public static implicit operator Matrix(Matrix matrix) {
			return new Matrix {
				M11 = matrix.M11,
				M12 = matrix.M12,
				M21 = matrix.M21,
				M22 = matrix.M22,
				M31 = matrix.M41,
				M32 = matrix.M42
			};
		}

		public unsafe static implicit operator RawMatrix3x2(Matrix value) {
			return *(RawMatrix3x2*)(&value);
		}

		public unsafe static implicit operator Matrix(RawMatrix3x2 value) {
			return *(Matrix*)(&value);
		}
	}*/
	}
}
