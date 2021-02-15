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
using System.Diagnostics;
namespace doticworks.GameFx
{
	/// <summary>
	/// Description of GameFxRuntime.
	/// </summary>
	public static class GameFxRuntime
	{
		public static void Load(bool isDebug=false){
			Terminal.WF(".ICWORKS GameFx {1}-D3D ({2})\r\n{0}\r\n","<Y>ModuleLoad	<B>GRuntime  	<G>Success!<W>",GameFx.Environment.FullStr,GameFx.Environment.SimpStr);
			if (isDebug) Environment.isDebug = true;

			AppDomain.CurrentDomain.UnhandledException +=(s,e)=>{
				try{
				System.Threading.Thread.CurrentThread.SetApartmentState(System.Threading.ApartmentState.STA);
				Clipboard.SetText((e.ExceptionObject as Exception).ToString());
				MessageBox.Show((e.ExceptionObject as Exception).ToString(),"GameFx Crash Report  |  Error has been outputed to Clipboard");
				Process.GetCurrentProcess().Kill();
				}catch(Exception nowe){MessageBox.Show((e.ExceptionObject as Exception).ToString()+nowe.ToString(),"GameFx Crash Report  |  Output error failed");Process.GetCurrentProcess().Kill();}
			};
			Application.ThreadException +=(s,e)=>{try{
				System.Threading.Thread.CurrentThread.SetApartmentState(System.Threading.ApartmentState.STA);
				Clipboard.SetText((e.Exception).ToString());
				MessageBox.Show((e.Exception).ToString(),"GameFx Crash Report  |  Error has been outputed to Clipboard");
				Process.GetCurrentProcess().Kill();
				}catch(Exception nowe){MessageBox.Show((e.Exception).ToString()+nowe.ToString(),"GameFx Crash Report  |  Output error failed");Process.GetCurrentProcess().Kill();}
			};
			Terminal.WF("{0}\r\n","<Y>ModuleLoad	<B>CrashRp  	<G>Success!<W>");
			AppDomain.CurrentDomain.AssemblyResolve+=(s,e)=>{
//				MessageBox.Show(e.Name);
//				string temp="";
//				foreach(var item in System.Reflection.Assembly.GetAssembly(typeof(GameFxRuntime)).GetManifestResourceNames()){temp+=item;}
//				MessageBox.Show(temp);
				Dictionary<string,string> dlldict=new Dictionary<string, string>();
				dlldict.Add("SharpDX.Direct3D11, Version=4.2.0.0, Culture=neutral, PublicKeyToken=b4dcf0f35e5521f1","doticworks.GameFx.Dll.SharpDX.Direct3D11.dll");
				dlldict.Add("SharpDX.Direct2D1, Version=4.2.0.0, Culture=neutral, PublicKeyToken=b4dcf0f35e5521f1","doticworks.GameFx.Dll.SharpDX.Direct2D1.dll");
				dlldict.Add("SharpDX.DirectInput, Version=4.2.0.0, Culture=neutral, PublicKeyToken=b4dcf0f35e5521f1","doticworks.GameFx.Dll.SharpDX.DirectInput.dll");
				dlldict.Add("SharpDX, Version=4.2.0.0, Culture=neutral, PublicKeyToken=b4dcf0f35e5521f1","doticworks.GameFx.Dll.SharpDX.dll");
				dlldict.Add("SharpDX.DXGI, Version=4.2.0.0, Culture=neutral, PublicKeyToken=b4dcf0f35e5521f1","doticworks.GameFx.Dll.SharpDX.DXGI.dll");
				dlldict.Add("SharpDX.DirectSound, Version=4.2.0.0, Culture=neutral, PublicKeyToken=b4dcf0f35e5521f1","doticworks.GameFx.Dll.SharpDX.DirectSound.dll");
				dlldict.Add("SharpDX.Mathematics, Version=4.2.0.0, Culture=neutral, PublicKeyToken=b4dcf0f35e5521f1","doticworks.GameFx.Dll.SharpDX.Mathematics.dll");
				try{
					
				System.IO.Stream _temp=System.Reflection.Assembly.GetAssembly(typeof(GameFxRuntime)).GetManifestResourceStream(dlldict[e.Name]);
				byte[] _buffer = new byte[_temp.Length];
				_temp.Read(_buffer, 0, _buffer.Length);
				return System.Reflection.Assembly.Load(_buffer);}catch{return null;}
				
			};
			Terminal.WF("{0}\r\n","<Y>ModuleLoad	<B>DirectBase  	<G>Success!<W>");
			Terminal.WF("{0}","<Y>ModuleLoad	<B>Extension  	");
			Extension.InitiativeLoad_();
			Terminal.WF("\r\n				{0}\r\n",Extension.ExtensionLoaded==0?"<Y>NoExtension!<W>":"<G>Loaded!<Y> Ext "+"<G>"+Extension.ExtensionLoaded.ToString());
//			Terminal.WF("<W>.ICWORKS GameFx v1.4-D3D\r\n{0}\r\n{1}\r\n","LoadingRuntime	<G>Success!<W>",
//			            "LoadingD3D	"+(GameFx.Module.GraphicsDevice.Default.SupportD3D?"<G>D3DSupport!<w>":"<R>D3DUnSupport(All Effect will not work)")
//			           );
			
		}
	}
}
