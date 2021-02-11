/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2020/11/7
 * 时间: 19:50
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Timers;
namespace doticworks.GameFx.COMMON
{
	
	public class Texture2T: Texture
	{
		public Texture2T(Texture2D[] t)
		{
			_bmps=new Bitmap[t.Length];
			for(int i=0;i<=t.Length-1;i++){_bmps[i]=t[i].Paint();}
			tim.Elapsed+=(s,e)=>{updateframe();};
		}
		public Texture2T(Texture2D t,int elementwidth)
		{
			Bitmap temp=t.Paint();
			int framecount=(int)temp.Width/elementwidth;
			_bmps=new Bitmap[framecount];
			for(int i=0;i<=framecount-1;i++){_bmps[i]=temp.Clone(new Rectangle(i*elementwidth,0,elementwidth,temp.Height),temp.PixelFormat);}
			tim.Elapsed+=(s,e)=>{updateframe();};
		}
		
		public Bitmap[] _bmps;
		public int nowframe=0;
		Timer tim=new Timer();
		bool isonce=false;
		public bool SetFrame(int frame){
			if(_bmps.Length<frame+1){return false;}
			else{
				nowframe=frame;
				return true;
			}
		}
		public void updateframe(){
			nowframe++;
			if(nowframe==_bmps.Length-2&&isonce){EndAnimat();isonce=false;}
			if(nowframe>_bmps.Length-1){nowframe=0;}
		}
		public void StartAnimat(float msperfr){
			tim.Interval=msperfr;
			tim.Start();
		}
		public void StartAnimatOnce(float msperfr){
			tim.Interval=msperfr;isonce=true;
			tim.Start();
		}
		public void EndAnimat(){
			tim.Stop();
		}
		public override Bitmap Paint()
		{
			return _bmps[nowframe];
		}
	}
}
