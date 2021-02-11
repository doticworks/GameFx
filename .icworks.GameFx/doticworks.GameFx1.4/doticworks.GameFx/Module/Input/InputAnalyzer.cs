/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2021/2/10
 * 时间: 19:38
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using SharpDX.DirectInput;
namespace doticworks.GameFx.Module.Input
{
	public class InputAnalyzer
	{
		public InputAnalyzer(out Action onupdate)
		{
			onupdate=()=>{OnUpdate();};
			input=Input.Default;
		}
		MouseState last=new MouseState();
		void OnUpdate(){
			MouseState ms=input.State_Mouse;
			Terminal.WF(ms.ToString()+"\r\n");
			last=ms;
			Terminal.WF(input.State_Keyboard.ToString()+"\r\n");
		}
		Input input;
		
		int changechecker(bool last,bool now){
			return 1;
		}
	}
}
