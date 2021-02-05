/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2021/1/23
 * 时间: 21:14
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace doticworks.GameFx
{
	public class Terminal
	{
		static bool enable=true;
		public static bool Enable{
			get{return enable;}
			set{
				enable=value;
				if(enable){Win32.AllocConsole();}else{Win32.FreeConsole();}
			}
		}
		static readonly Lazy<Terminal> defaultmng=new Lazy<Terminal>(()=>{return new Terminal();});
		public static Terminal Default{
			get{return defaultmng.Value;}
		}
		Terminal()
		{
			if(enable){
				
				Win32.AllocConsole();
				Console.Title="GameFx Terminal";
				Console.WindowWidth=50;
				Console.WindowHeight=15;
				System.Threading.Thread t=new System.Threading.Thread(()=>{InputTrace();});t.IsBackground=true;
				t.Start();
			}
		}
		
		public static void WF(string arg,params object[] values){
			if(!enable){return;}
			Default.WriteFormat(arg,values);
		}
		
		
		public static event Action<string> InputBinding{
			add{Default.inputbinding+=value;}
			remove{Default.inputbinding-=value;}
		}
		event Action<string> inputbinding;
		string input="";
		void InputTrace(){
			ConsoleKeyInfo ck;
			while(true){
				ck=Console.ReadKey();
//				ck=Console.ReadKey().Key;
				if(ck.Key==ConsoleKey.Enter){
					inputbinding(input);
					input="";
				}else{
					input=input+ck.KeyChar;
				}
				
			}
		}
		void WF(string arg){WriteFormat(arg);}
		void WriteFormat(string arg,params object[] values){
			if(!enable){return;}
			int n=0;
			arg="<W>"+arg;
			while(true){
				if(arg.Contains("{"+n.ToString()+"}")){
					if(n<values.Length){
						arg=arg.Replace(@"{"+n.ToString()+@"}",values[n].ToString());
					}else{
						break;
					}
				}else{
					break;
				}
				n++;
			}
			string[] spl=arg.Split(new char[]{'<'},StringSplitOptions.RemoveEmptyEntries);
			foreach(var item in spl){
				string[] split2=item.Split(new char[]{'>'},StringSplitOptions.RemoveEmptyEntries);
				MarkReader(split2[0]);if(split2.Length==2){Console.Write(split2[1]);}
			}
		}
		void MarkReader(string arg){
			arg=arg.ToUpper();
			switch(arg){
					//concolor
					case "R":{Console.ForegroundColor=ConsoleColor.Red;break;}
					case "G":{Console.ForegroundColor=ConsoleColor.Green;break;}
					case "B":{Console.ForegroundColor=ConsoleColor.Blue;break;}
					case "W":{Console.ForegroundColor=ConsoleColor.White;break;}
					case "Y":{Console.ForegroundColor=ConsoleColor.DarkYellow;break;}
					case "GRAY":{Console.ForegroundColor=ConsoleColor.Gray;break;}
					//cmds
					case "CLS":{Console.Clear();break;}
					
					
					default :{Console.Write("<"+arg+">");break;}
			}
		}
	}
}
