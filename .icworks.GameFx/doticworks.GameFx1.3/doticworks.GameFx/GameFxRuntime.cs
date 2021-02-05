/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/12/21
 * 时间: 17:37
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Windows.Forms;
using System.Collections.Generic;
namespace doticworks.GameFx
{
	/// <summary>
	/// Description of GameFxRuntime.
	/// </summary>
	public static class GameFxRuntime
	{
		public static void Load(){
			
			AppDomain.CurrentDomain.UnhandledException +=(s,e)=>{
				try{
				System.Threading.Thread.CurrentThread.SetApartmentState(System.Threading.ApartmentState.STA);
				Clipboard.SetText((e.ExceptionObject as Exception).ToString());
				MessageBox.Show((e.ExceptionObject as Exception).ToString(),"GameFx Crash Report  |  Error has been outputed to Clipboard");
				}catch(Exception nowe){MessageBox.Show((e.ExceptionObject as Exception).ToString()+nowe.ToString(),"GameFx Crash Report  |  Output error failed");}
			};
			Application.ThreadException +=(s,e)=>{try{
				System.Threading.Thread.CurrentThread.SetApartmentState(System.Threading.ApartmentState.STA);
				Clipboard.SetText((e.Exception).ToString());
				MessageBox.Show((e.Exception).ToString(),"GameFx Crash Report  |  Error has been outputed to Clipboard");
				}catch(Exception nowe){MessageBox.Show((e.Exception).ToString()+nowe.ToString(),"GameFx Crash Report  |  Output error failed");}
			};
			AppDomain.CurrentDomain.AssemblyResolve+=(s,e)=>{
//				MessageBox.Show(e.Name);
//				string temp="";
//				foreach(var item in System.Reflection.Assembly.GetAssembly(typeof(GameFxRuntime)).GetManifestResourceNames()){temp+=item;}
//				MessageBox.Show(temp);
				Dictionary<string,string> dlldict=new Dictionary<string, string>();
				dlldict.Add("SharpDX.Direct2D1, Version=4.2.0.0, Culture=neutral, PublicKeyToken=b4dcf0f35e5521f1","doticworks.GameFx.DLL.SharpDX.Direct2D1.dll");
				dlldict.Add("SharpDX.DirectInput, Version=4.2.0.0, Culture=neutral, PublicKeyToken=b4dcf0f35e5521f1","doticworks.GameFx.DLL.SharpDX.DirectInput.dll");
				dlldict.Add("SharpDX, Version=4.2.0.0, Culture=neutral, PublicKeyToken=b4dcf0f35e5521f1","doticworks.GameFx.DLL.SharpDX.dll");
				dlldict.Add("SharpDX.DXGI, Version=4.2.0.0, Culture=neutral, PublicKeyToken=b4dcf0f35e5521f1","doticworks.GameFx.DLL.SharpDX.DXGI.dll");
				try{
					
				System.IO.Stream _temp=System.Reflection.Assembly.GetAssembly(typeof(GameFxRuntime)).GetManifestResourceStream(dlldict[e.Name]);
				byte[] _buffer = new byte[_temp.Length];
				_temp.Read(_buffer, 0, _buffer.Length);
				return System.Reflection.Assembly.Load(_buffer);}catch{return null;}
				
			};
			Extension.ExtensionLoad();
		}
	}
}
