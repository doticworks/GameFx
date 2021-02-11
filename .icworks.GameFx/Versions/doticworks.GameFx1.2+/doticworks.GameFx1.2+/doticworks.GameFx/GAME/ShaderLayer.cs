/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2020/11/28
 * 时间: 20:26
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using doticworks.GameFx.GAME;
using doticworks.GameFx.IO;
using doticworks.GameFx.COMMON;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Collections.Generic;
namespace doticworks.GameFx.GAME
{
	public class LightSource{
		public Point pos;
		public Color col;
		public float lightlength;
	}
	public class ShaderLayer
	{
		public ShaderLayer(int w,int h ,float wayopa,float hitopa)
		{_w=w;_h=h;
			rayhit=new Bitmap(w,h);
			rayway=new Bitmap(w,h);
			outimage=new Bitmap(w,h);
			gway=Graphics.FromImage(rayway);
			ghit=Graphics.FromImage(rayhit);
			gout=Graphics.FromImage(outimage);
			float[][] colorMatrixElements = {
							       	new float[]{1,0,0,0,0},
									new float[]{0,1,0,0,0},
									new float[]{0,0,1,0,0},
									new float[]{0,0,0,wayopa,0},
									new float[]{0,0,0,0,1}};
			wayia=new ImageAttributes();
			wayia.SetColorMatrix(new ColorMatrix(colorMatrixElements));
			float[][] colorMatrixElements2 = {
							       	new float[]{1,0,0,0,0},
									new float[]{0,1,0,0,0},
									new float[]{0,0,1,0,0},
									new float[]{0,0,0,hitopa,0},
									new float[]{0,0,0,0,1}};
			hitia=new ImageAttributes();
			hitia.SetColorMatrix(new ColorMatrix(colorMatrixElements2));

		}
		int _w;int _h; 
		float wayopacity=0.1f;
		float hitopacity=0.5f;
		ImageAttributes wayia;
		ImageAttributes hitia;
		Bitmap _barrierbmp;
		List<LightSource> lightsource=new List<LightSource>();
		List<Point> points=new List<Point>();
		void getpointsway(Point source,Point dest){
			points.Clear();
			Point temp1=new Point(1,1);
			float length=(float)Math.Sqrt((dest.X-source.X)*(dest.X-source.X)+(dest.Y-source.Y)*(dest.Y-source.Y));
			float tox=((int)(dest.X-source.X))/source.X;
			float toy=((int)(dest.Y-source.Y))/source.Y;
			for(int len=0;len<=length;len++){
				temp1.X=(int)(source.X+len*tox);temp1.Y=(int)(source.Y+len*toy);
				if(!points.Contains(temp1)){points.Add(temp1);}
			}
		}
		Bitmap rayway;
		Bitmap rayhit;
		Bitmap outimage;
		Graphics gout;
		Graphics gway;
		Graphics ghit;
		List<PointF> region=new List<PointF>();
		public Bitmap output(Bitmap barriermap){
			gway.Clear(Color.Transparent);
			GraphicsPath gp=new GraphicsPath();
			
			Point destpoint=new Point(1,1);
			Point hitedpoint=new Point(1,1);
			Pen xpen;
			foreach(var light in lightsource){
				float lightlen=light.lightlength;
				for(float toward=0f;toward<=360f;toward++){
					bool ishit=false;
					destpoint.X=(int)((float)Math.Sin(toward/180*Math.PI)*lightlen)+light.pos.X;
					destpoint.Y=(int)((float)Math.Cos(toward/180*Math.PI)*lightlen)+light.pos.Y;
					getpointsway(light.pos,destpoint);
					foreach(var poss in points){
						try{if(barriermap.GetPixel(poss.X,poss.Y)==Color.Black){
							ishit=true;
							hitedpoint=poss;
							break;
							}}catch{}
					}
					if(ishit){
						if(!region.Contains(new PointF(hitedpoint.X,hitedpoint.Y))){ region.Add(new PointF(hitedpoint.X,hitedpoint.Y));}
					}
					if(!ishit){
						if(!region.Contains(new PointF(destpoint.X,destpoint.Y))){ region.Add(new PointF(destpoint.X,destpoint.Y));}
					}
				}
				gway.FillClosedCurve(new SolidBrush(light.col),region.ToArray());
				region.Clear();
			}
			
			return outimage;
		}
		public Bitmap output(Bitmap barriermap,LightSource[] lights){
			lightsource.AddRange(lights);
			return output(barriermap);
		}
	}
}
/*
 * 
* Point destpoint=new Point(1,1);
			Point hitedpoint=new Point(1,1);
			Pen xpen;
			foreach(var light in lightsource){
				xpen=new Pen(light.col);
				float lightlen=light.lightlength;
				for(float toward=0f;toward<=360f;toward++){
					bool ishit=false;
					destpoint.X=(int)((float)Math.Sin(toward/180*Math.PI)*lightlen)+light.pos.X;
					destpoint.Y=(int)((float)Math.Cos(toward/180*Math.PI)*lightlen)+light.pos.Y;
					getpointsway(light.pos,destpoint);
					foreach(var poss in points){
						try{if(barriermap.GetPixel(poss.X,poss.Y)==Color.Black){
							ishit=true;
							hitedpoint=poss;
							break;
							}}catch{}
					}
					if(ishit){
						
					}
					if(!ishit){
						gway.DrawLine(xpen,light.pos,destpoint);
					}
				}
			}
			gout.Clear(Color.Transparent);
			gout.DrawImage(rayway,new Rectangle(0,0,_w,_h),0,0,_w,_h,GraphicsUnit.Pixel,wayia);
* 
* 
* 1、去色效果
private float[] colorArray=new float[]{
1.5f,1.5f,1.5f,0,-1,
1.5f,1.5f,1.5f,0,-1,
1.5f,1.5f,1.5f,0,-1,
0,0,0,1,0,
0,0,0,0,0
};

2、怀旧效果
private float[] colorArray=new float[]{
0.393,0.769,0.189,0,0,
0.349,0.686,0.168,0,0,
0.272,0.543,0.131,0,0,
0,0,0,1,0,
0,0,0,0,0
};

3、图片反转效果
private float[] colorArray=new float[]{
-1,0,0,1,1,
0,-1,0,1,1,
0,0,-1,1,1,
0,0,0,1,0,
0,0,0,0,0
};

4、灰度效果
private float[] colorArray=new float[]{
0.33,0.59,0.11,0,0,
0.33,0.59,0.11,0,0,
0.33,0.59,0.11,0,0,
0,0,0,1,0,
0,0,0,0,0
};

5、高饱和度效果
private float[] colorArray=new float[]{
1.438,-0.122,-0.016,0,-0.03,
-0.062,1.378,-0.016,0,0.05,
-0.062,-0.122,1.483,0,-0.02,
0,0,0,1,0,
0,0,0,0,0
};

6、低饱和度效果
private float[] colorArray=new float[]{
0.308,0.609,0.082,0,0,
0.308,0.609,0.082,0,0,
0.308,0.609,0.082,0,0,
0,0,0,1,0,
0,0,0,0,0
};

7、亮度调整
private float[] colorArray=new float[]{
1,0,0,0,0,
0,1,0,0,0,
0,0,1,0,0,
0,0,0,1,0,
light,light,light,0,0
};

8、对比度调整
private float[] colorArray=new float[]{
contrast ,0,0,0,0,
0,contrast ,0,0,0,
0,0,contrast ,0,0,
0,0,0,1,0,
0,0,0,0,0
};*/