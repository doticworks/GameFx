/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2021/1/31
 * 时间: 17:01
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
namespace doticworks.GameFx
{
	public class Extension
	{
		static readonly Lazy<Extension> __=new Lazy<Extension>(()=>{return new Extension();});
		public static Extension _{
			get{
				return __.Value;
			}
		}
		public int extensionnum=0;
		public Dictionary<string,Func<object,object>> funcshell=new Dictionary<string, Func<object, object>>();
		public event Action<string> extensionevent;
		public object Invoke(string name, object arg){
			if(funcshell.ContainsKey(name)){
				return funcshell[name](arg);
			}
			return null;
		}
		public void Regist(string name,Func<object,object> arg){
			if(funcshell.ContainsKey(name)){funcshell.Remove(name);}
			funcshell.Add(name,arg);
		}
		public void InitiativeLoad(){
			foreach(var item in Directory.GetFiles(System.Windows.Forms.Application.StartupPath)){
				if(item.EndsWith(".ic")||item.EndsWith(".ic.exe")){
					Terminal.WF("\r\nExtension	{0}	<G>Loaded",(item.Split('\\')[item.Split('\\').Length-1]).Split('.')[0]);
					extensionnum++;
					System.Threading.Thread t=new System.Threading.Thread(()=>{
						System.Reflection.Assembly asm=Assembly.Load(File.ReadAllBytes(item));
						asm.EntryPoint.Invoke(this,new object[1]{new string[]{}});
					});
					t.ApartmentState=System.Threading.ApartmentState.STA;
					t.IsBackground=true;
					t.Start();
				}
			}
		}
		
		
		public static object Invoke_(string name, object arg){
			Terminal.WF("\r\n{0} Invoking\r\n",name);
			return _.Invoke(name,arg);
		}
		public static void Regist_(string name,Func<object,object> arg){
			_.Regist(name,arg);
		}
		public static void InitiativeLoad_(){
			_.InitiativeLoad();
		}
		public static event Action<string> ExEvent{
			add{
				_.extensionevent+=value;
			}remove{
				_.extensionevent-=value;
			}
		}
		public static void DoEvent(string arg){
			try
			{
				_.extensionevent(arg);
			}
			catch(Exception e)
			{
				Terminal.WF("\r\n<R>Warning<W>:<Y>Some added Extension crashed\r\nThis will cause <R>other extensions to be unnormal<Y>\r\n{0}",e.ToString());
			}
		}
		public static int ExtensionLoaded{
			get{
				return _.extensionnum;
			}
		}
		public static string[] AvailableFuncs(){
			var tmp=_.funcshell.Keys;
			string[] tm=new string[tmp.Count];
			tmp.CopyTo(tm,0);
			return tm;
		}
	}
}
