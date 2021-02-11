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
			last=new InputState(0,0,0,new bool[3],new System.Collections.Generic.List<Key>());
		}
		InputState last;
		void OnUpdate(	Action<int,int,int> mousepos=null,
		             	Action<bool,bool,bool> mousebuttondown=null,
		             	Action<bool,bool,bool> mousebuttonToClick=null,
		             	Action<bool,bool,bool> mousebuttonToRelease=null,
		             	Action<bool,bool,bool> mousebuttonKeepHold=null,
		             	Action<bool,bool,bool> mousedoubleclick=null,
		             	Action<System.Windows.Forms.Keys> multicallkeydown=null
		             ){
			InputState ins=input.Current;
			Terminal.WF("{0} {1} {2} {3} {4}\r\n",ins.MouseX,ins.MouseY,ins.Whell);
			
			if(mousepos!=null){mousepos(ins.MouseX,ins.MouseY,ins.Whell);}
			if(mousebuttondown!=null){mousebuttondown(ins.buttons[0],ins.buttons[1],ins.buttons[2]);}
			if(mousebuttonToClick!=null){mousebuttonToClick(cc(last.buttons[0],ins.buttons[0])==1,cc(last.buttons[1],ins.buttons[1])==1,cc(last.buttons[2],ins.buttons[2])==1);}
			if(mousebuttonToRelease!=null){mousebuttonToRelease(cc(last.buttons[0],ins.buttons[0])==2,cc(last.buttons[1],ins.buttons[1])==2,cc(last.buttons[2],ins.buttons[2])==2);}
			if(mousebuttonKeepHold!=null){mousebuttonKeepHold(cc(last.buttons[0],ins.buttons[0])==3,cc(last.buttons[1],ins.buttons[1])==3,cc(last.buttons[2],ins.buttons[2])==3);}
			#region doubleclick
			bool[] dbcbuffer=new bool[3];
			for(int i=0;i<3;i++){
				if(dbclick[i]>=1){dbclick[i]++;}if(dbclick[i]>20){dbclick[i]=0;}
			}
			for(int i=0;i<3;i++){
				if(ins.buttons[i]){
					if(dbclick[i]>8){dbcbuffer[i]=true;}
					dbclick[i]=1;}
			}
			if(mousedoubleclick!=null){mousedoubleclick(dbcbuffer[0],dbcbuffer[1],dbcbuffer[2]);}
			#endregion
			
			for(int i=0;i<ins.pressedkey.Count;i++){
				
			}
			
			
			
		}
		int[] dbclick=new int[3];
		
		
		Input input;
		
		/// <summary>
		/// ChangeChecker
		/// </summary>
		/// <returns>0 n-n  1 n-y  2 y-n  3 y-y</returns>
		int cc(bool last,bool now){
			if(!last&&!now) return 0;
			if(!last&&now) return 1;
			if(last&&!now) return 2;
			if(last&&now) return 3;
			return 0;
		}
		System.Windows.Forms.Keys kc(Key k){
			return (System.Windows.Forms.Keys)((int)k);
		}
	}
}
