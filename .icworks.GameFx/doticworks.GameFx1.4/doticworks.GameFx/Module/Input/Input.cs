/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2021/2/10
 * 时间: 19:29
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Windows.Forms;
using SharpDX.DirectInput;
namespace doticworks.GameFx.Module.Input
{
	/// <summary>
	/// Description of Input.
	/// </summary>
	public class Input
	{
		static readonly Lazy<Input> defaultmng=new Lazy<Input>(()=>{
		     Terminal.WF("<Y>ModuleLoad	<B>Input  	");
		     Input gd= new Input();
		     Terminal.WF("<G>{0}<W>\r\n","<G>Success!<w>");
		     return gd;
		     });
		public static Input Default{
			get{return defaultmng.Value;}
		}
		public InputState Current{get{
				int x=0;int y=0;
				if(mouseControl!=null){
					var point=mouseControl.PointToClient(Control.MousePosition);x=point.X;y=point.Y;
				}
				var ms=mouse.GetCurrentState();
				int z=ms.Z;
				bool[] button=ms.Buttons;
				var ks=keyb.GetCurrentState();
				var keys=ks.PressedKeys;
				
				return new InputState(x,y,z,button,keys);}}
		
		public void AcquireMouse(out Action<Control> controldo){
			Action<Control> cd=(con)=>{mouseControl=con;};
			controldo=cd;
		}
		private Input(){
			DI= new DirectInput();
			
		    mouse = new Mouse(DI);
		    mouse.Properties.AxisMode = DeviceAxisMode.Absolute;
		    mouse.Properties.BufferSize = 128;
		    mouse.Acquire();
		    
			if(mouseControl!=null){
		    	Terminal.WF(mouseControl.PointToClient(Control.MousePosition).ToString());
			}
		    
		    Console.WriteLine(mouse.GetCurrentState());
			
		    
		    keyb = new Keyboard(DI);
			keyb.Acquire();
		}
		Control mouseControl=null;
		
		DirectInput DI;
		
		Mouse mouse;
		Keyboard keyb;
	}
}
