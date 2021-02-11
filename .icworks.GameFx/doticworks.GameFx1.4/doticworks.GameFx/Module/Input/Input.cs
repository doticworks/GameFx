/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2021/2/10
 * 时间: 19:29
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using SharpDX.XInput;
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
		public MouseState State_Mouse{get{return mouse.GetCurrentState();}}
		public KeyboardState State_Keyboard{get{return keyb.GetCurrentState();}}
		private Input(){
			DI= new DirectInput();
		    mouse = new Mouse(DI);
		    mouse.Properties.AxisMode = DeviceAxisMode.Absolute;
		    mouse.Properties.BufferSize = 128;
		//    mouse.Properties.
		    mouse.Acquire();
		    Console.WriteLine(mouse.GetCurrentState());
			
		    
		    keyb = new Keyboard(DI);
			keyb.Acquire();
		}
		DirectInput DI;
		
		Mouse mouse;
		Keyboard keyb;
	}
}
