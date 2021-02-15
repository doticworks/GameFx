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
		public InputAnalyzer()
		{
			input=Input.Default;
			last=new InputState(0,0,0,new bool[3],new System.Collections.Generic.List<Key>());
		}
		InputState last;
		public void OnUpdate(	Action<int,int,int> mousepos=null,
		             	Action<bool,bool,bool> mousebuttondown=null,
		             	Action<bool,bool,bool> mousebuttonToClick=null,
		             	Action<bool,bool,bool> mousebuttonToRelease=null,
		             	Action<bool,bool,bool> mousebuttonKeepHold=null,
		             	Action<bool,bool,bool> mousedoubleclick=null,
		             	Action<System.Windows.Forms.Keys> multicallkeydown=null,
		             	Action<System.Windows.Forms.Keys> multicallkeyToClick=null,
		             	Action<System.Windows.Forms.Keys> multicallkeyToRelease=null,
		             	Action<System.Windows.Forms.Keys> multicallkeyKeepHold=null
		             ){
			InputState ins=input.Current;
		//	Terminal.WF("{0} {1} {2} {3} {4}\r\n",ins.MouseX,ins.MouseY,ins.Whell);
			
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
				multicallkeydown(kc(ins.pressedkey[i]));
				if(last.pressedkey.Contains(ins.pressedkey[i])){
					multicallkeyKeepHold(kc(ins.pressedkey[i]));
				}else{
					multicallkeyToClick(kc(ins.pressedkey[i]));
				}
			}
			for(int i=0;i<last.pressedkey.Count;i++){
				if(ins.pressedkey.Contains(ins.pressedkey[i])){
					
				}else{
					multicallkeyToRelease(kc(ins.pressedkey[i]));
				}
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
			int x=(int)k;
			int t=1;
			if(x==1){t=27;}
			if(x>=2&&x<=11){t=x+46;}
			if(x==12){t=189;}
			if(x==13){t=226;}
			if(x==14){t=8;}
			if(x==15){t=9;}
			if(x>=16&&x<=58){
				switch(x){
						case 16:t=81;break;
						case 17:t=87;break;
						case 18:t=69;break;
						case 19:t=82;break;
						case 20:t=84;break;
						case 21:t=89;break;
						case 22:t=94;break;
						case 23:t=73;break;
						case 24:t=79;break;
						case 25:t=80;break;
						case 26:t=219;break;
						case 27:t=221;break;
						case 28:t=13;break;
						case 29:t=162;break;
						case 30:t=65;break;
						case 31:t=83;break;
						case 32:t=68;break;
						case 33:t=70;break;
						case 34:t=71;break;
						case 35:t=72;break;
						case 36:t=74;break;
						case 37:t=75;break;
						case 38:t=76;break;
						case 39:t=186;break;
						case 40:t=-123;break;//
						case 41:t=-123;break;//
						case 42:t=160;break;
						case 43:t=226;break;
						case 44:t=90;break;
						case 45:t=88;break;
						case 46:t=67;break;
						case 47:t=86;break;
						case 48:t=66;break;
						case 49:t=78;break;
						case 50:t=77;break;
						case 51:t=188;break;
						case 52:t=190;break;
						case 53:t=226;break;//
						case 54:t=161;break;
						case 55:t=106;break;
						case 56:t=262144;break;//
						case 57:t=32;break;
						case 58:t=20;break;
						default:t=-123;break;
				}
			}
			if(x>=59&&x<=68){t=x+61;}
			if(x>=69&&x<=83){
				switch(x){
					case 69:t=144;break;
					case 70:t=145;break;
					case 71:t=103;break;
					case 72:t=104;break;
					case 73:t=105;break;
					case 74:t=109;break;
					case 75:t=100;break;
					case 76:t=101;break;
					case 77:t=102;break;
					case 78:t=107;break;
					case 79:t=97;break;
					case 80:t=98;break;
					case 81:t=99;break;
					case 82:t=100;break;
					case 83:t=110;break;
				}
			}
			if(x>=84){Terminal.WF("\r\n\r\n<R>UNCONV{0} {1}",x.ToString(),k.ToString());}
			
			
			if(t==-123){throw new Exception("Undefined Key");}
			return (System.Windows.Forms.Keys)(t);
		}
	}
}
