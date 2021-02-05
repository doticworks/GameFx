
using System;
using System.IO;
using System.Reflection;
namespace doticworks.GameFx
{
	/// <summary>
	/// Description of Extension.
	/// </summary>
	public class Extension
	{
		static readonly Lazy<Extension> _Extension=new Lazy<Extension>(()=>new Extension());
		public static Extension Extension_{
			get{
				return _Extension.Value;
			}
		}
		Extension()
		{
		}
		public bool ExtensionEnable=false;
		public static void ExtensionLoad(){
			foreach(var item in Directory.GetFiles(System.Windows.Forms.Application.StartupPath)){
				if(item.EndsWith(".extension.ic")){
					System.Threading.Thread t=new System.Threading.Thread(()=>{
						System.Reflection.Assembly asm=Assembly.Load(File.ReadAllBytes(item));
						asm.GetTypes()[0].GetMethod("ExtensionMain").Invoke(new object(),new Object[]{Extension_ as object});
					});
					t.ApartmentState=System.Threading.ApartmentState.STA;
					t.IsBackground=true;
					t.Start();
					                                                      }
			}
		}
	}
	public class ExtensionBase{
		public virtual void ExtensionMain(Extension exten){
			
		}
	}
}
