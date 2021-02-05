/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2021/1/23
 * 时间: 20:16
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace doticworks.GameFx.Common
{
//	public static class MathUtil
//	{
//		public const float ZeroTolerance = 1E-06f;
//
//		public const float Pi = 3.14159274f;
//
//		public const float TwoPi = 6.28318548f;
//
//		public const float PiOverTwo = 1.57079637f;
//
//		public const float PiOverFour = 0.7853982f;
//
//		public static bool WithinEpsilon(float a, float b)
//		{
//			return MathUtil.WithinEpsilon(a, b, 1.401298E-45f);
//		}
//
//		public static bool WithinEpsilon(float a, float b, float epsilon)
//		{
//			float num = a - b;
//			return -epsilon <= num && num <= epsilon;
//		}
//
//		public static T[] Array<T>(T value, int count)
//		{
//			T[] array = new T[count];
//			for (int i = 0; i < count; i++) {
//				array[i] = value;
//			}
//			return array;
//		}
//
//		public static float RevolutionsToDegrees(float revolution)
//		{
//			return revolution * 360f;
//		}
//
//		public static float RevolutionsToRadians(float revolution)
//		{
//			return revolution * 6.28318548f;
//		}
//
//		public static float RevolutionsToGradians(float revolution)
//		{
//			return revolution * 400f;
//		}
//
//		public static float DegreesToRevolutions(float degree)
//		{
//			return degree / 360f;
//		}
//
//		public static float DegreesToRadians(float degree)
//		{
//			return degree * 0.0174532924f;
//		}
//
//		public static float RadiansToRevolutions(float radian)
//		{
//			return radian / 6.28318548f;
//		}
//
//		public static float RadiansToGradians(float radian)
//		{
//			return radian * 63.6619759f;
//		}
//
//		public static float GradiansToRevolutions(float gradian)
//		{
//			return gradian / 400f;
//		}
//
//		public static float GradiansToDegrees(float gradian)
//		{
//			return gradian * 0.9f;
//		}
//
//		public static float GradiansToRadians(float gradian)
//		{
//			return gradian * 0.0157079641f;
//		}
//
//		public static float RadiansToDegrees(float radian)
//		{
//			return radian * 57.2957764f;
//		}
//
//		public static float Clamp(float value, float min, float max)
//		{
//			if (value < min) {
//				return min;
//			}
//			if (value <= max) {
//				return value;
//			}
//			return max;
//		}
//
//		public static int Clamp(int value, int min, int max)
//		{
//			if (value < min) {
//				return min;
//			}
//			if (value <= max) {
//				return value;
//			}
//			return max;
//		}
//
//		public static double Lerp(double from, double to, double amount)
//		{
//			return (1.0 - amount) * from + amount * to;
//		}
//
//		public static float Lerp(float from, float to, float amount)
//		{
//			return (1f - amount) * from + amount * to;
//		}
//
//		public static byte Lerp(byte from, byte to, float amount)
//		{
//			return (byte)MathUtil.Lerp((float)from, (float)to, amount);
//		}
//
//		public static float Mod(float value, float modulo)
//		{
//			if (modulo == 0f) {
//				return value;
//			}
//			return value % modulo;
//		}
//
//		public static float Mod2PI(float value)
//		{
//			return MathUtil.Mod(value, 6.28318548f);
//		}
//
//		public static int Wrap(int value, int min, int max)
//		{
//			if (min > max) {
//				throw new ArgumentException(string.Format("min {0} should be less than or equal to max {1}", min, max), "min");
//			}
//			int num = max - min + 1;
//			if (value < min) {
//				value += num * ((min - value) / num + 1);
//			}
//			return min + (value - min) % num;
//		}
//
//		public static float Wrap(float value, float min, float max)
//		{
//			if (MathUtil.WithinEpsilon(min, max)) {
//				return min;
//			}
//			double num = (double)min;
//			double num2 = (double)max;
//			double num3 = (double)value;
//			if (num > num2) {
//				throw new ArgumentException(string.Format("min {0} should be less than or equal to max {1}", min, max), "min");
//			}
//			double num4 = num2 - num;
//			return (float)(num + (num3 - num) - num4 * Math.Floor((num3 - num) / num4));
//		}
//
//		public static float Gauss(float amplitude, float x, float y, float radX, float radY, float sigmaX, float sigmaY)
//		{
//			return (float)MathUtil.Gauss((double)amplitude, (double)x, (double)y, (double)radX, (double)radY, (double)sigmaX, (double)sigmaY);
//		}
//
//		public static double Gauss(double amplitude, double x, double y, double radX, double radY, double sigmaX, double sigmaY)
//		{
//			return amplitude * 2.7182818284590451 - (Math.Pow(x - radX / 2.0, 2.0) / (2.0 * Math.Pow(sigmaX, 2.0)) + Math.Pow(y - radY / 2.0, 2.0) / (2.0 * Math.Pow(sigmaY, 2.0)));
//		}
//
//		public static float NextFloat(this Random random, float min, float max)
//		{
//			return MathUtil.Lerp(min, max, (float)random.NextDouble());
//		}
//
//		public static double NextDouble(this Random random, double min, double max)
//		{
//			return MathUtil.Lerp(min, max, random.NextDouble());
//		}
//
//		public static long NextLong(this Random random)
//		{
//			byte[] array = new byte[8];
//			random.NextBytes(array);
//			return BitConverter.ToInt64(array, 0);
//		}
//
//		public static long NextLong(this Random random, long min, long max)
//		{
//			byte[] array = new byte[8];
//			random.NextBytes(array);
//			long num = BitConverter.ToInt64(array, 0);
//			return Math.Abs(num % (max - min)) + min;
//		}
//
//		public static Vector2 NextVector2(this Random random, Vector2 min, Vector2 max)
//		{
//			return new Vector2(random.NextFloat(min.X, max.X), random.NextFloat(min.Y, max.Y));
//		}
//		public static Vector2 NextDPointF(this Random random, Vector2 min, Vector2 max)
//		{
//			return new Vector2(random.NextFloat(min.X, max.X), random.NextFloat(min.Y, max.Y));
//		}
//
//		public static TimeSpan NextTime(this Random random, TimeSpan min, TimeSpan max)
//		{
//			return TimeSpan.FromTicks(random.NextLong(min.Ticks, max.Ticks));
//		}
//	}
}
