/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/12/10
 * 时间: 8:18
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace doticworks.GameFx.somecodes
{
	/// <summary>
	/// Description of Embed.
	/// </summary>
	public class Embed
	{
		public static void LoadGameFxEnvironment(){
			AppDomain.CurrentDomain.AssemblyResolve+=(s,e)=>{
			System.IO.Stream _temp=System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream(".icworks.GameFx.dll");
			byte[] _buffer = new byte[_temp.Length]; 
			_temp.Read(_buffer, 0, _buffer.Length);
			return _buffer;
			};
		}
	}
}
