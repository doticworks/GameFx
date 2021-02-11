/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2020/4/10
 * 时间: 13:34
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Drawing.Imaging;
namespace Deadcellx
{
	/// <summary>
	/// Description of GraphBehavior.
	/// </summary>
	public class GraphBehavior
	{
		public GraphBehavior()
		{
		}
		public unsafe static GraphicsPath GetGraphicsPath(Image image)
        {
            if (image == null)
                return null;
 
            // 声明GraphicsPath类以便计算位图路径
            GraphicsPath graphicsPath = new GraphicsPath(FillMode.Alternate);
            Bitmap bitmap = new Bitmap(image);
 
            int picWidth = bitmap.Width;
            int picHeight = bitmap.Height;
 
            BitmapData bitmapdata = bitmap.LockBits(new Rectangle(0, 0, picWidth, picHeight), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
 
            byte* point = (byte*)bitmapdata.Scan0;
            int offset = bitmapdata.Stride - picWidth * 3;
            int p0, p1, p2;
            p0 = point[0];
            p1 = point[1];
            p2 = point[2];
            int start = -1;
 
            for (int h = 0; h < picHeight; h++)
            {
                for (int x = 0; x < picWidth; x++)
                {
                    // 如果之前的点没有不透明且不透明   
                    if (start == -1 && (point[0] != p0 || point[1] != p1 || point[2] != p2))
                    {
                        start = x; 
                    }
                    else if (start > -1 && (point[0] == p0 && point[1] == p1 && point[2] == p2))
                    {
                        // 如果之前的点是不透明
                        graphicsPath.AddRectangle(new Rectangle(start, h, x - start - 1, 1));
                        start = -1;
                    }
 
                    // 如果之前的点是不透明且是最后一个点  
                    if (x == picWidth - 1 && start > -1)
                    {
                        graphicsPath.AddRectangle(new Rectangle(start, h, x - start + 1, 1));
                        start = -1;
                    }
 
                    point += 3;
                }
 
                point += offset;
            }
 
            bitmap.UnlockBits(bitmapdata);
            bitmap.Dispose();
 
            return graphicsPath;
        }
 
	}
}
