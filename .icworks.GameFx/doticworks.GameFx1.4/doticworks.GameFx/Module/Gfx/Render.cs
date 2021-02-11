/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2021/1/16
 * 时间: 9:15
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;
using SharpDX;
using DG=SharpDX.DXGI;
using System.Collections.Generic;
using D31=SharpDX.Direct3D11;
using D3=SharpDX.Direct3D;
using doticworks.GameFx.Common;
namespace doticworks.GameFx.Module.Gfx
{
	public partial class Render:IRender
	{
		public Render(DeviceContext _dc,Game.GameObject _root)
		{
			root=_root;
			DC = _dc;
			dwFactory =new SharpDX.DirectWrite.Factory(SharpDX.DirectWrite.FactoryType.Shared);
			temp_brush_solid=new SolidColorBrush(_dc,temp_color);
			temp_textfmt=new SharpDX.DirectWrite.TextFormat(dwFactory,"微软雅黑",10);
			temp_textlay=new SharpDX.DirectWrite.TextLayout(dwFactory,"",temp_textfmt,10,10);
			temp_ell=new Ellipse(temp_vec2,1,1);
			temp_polygon=new PathGeometry(_dc.Factory);
		}
		public Bitmap1 Target{set{
				DC.Target=value;
			}
		}
		public Bitmap1 swapbuffer;
		Game.GameObject root;
		
		
		RawMatrix3x2 transformbuffer;
		public doticworks.GameFx.Common.TransformStack transformstack=new TransformStack();
		SharpDX.DirectWrite.Factory dwFactory;
		DeviceContext DC;
		public DeviceContext dc{
			get{return DC;}
		}
		public void Draw(){
			transformstack.Clear();
			root.components.RI_ComNode.TreeInvoke(after:(g)=>{
              	g.components.DoComponents<Game.Components.ComRenderKeyNode>((crkn)=>{
			    	crkn.DrawKeyNode(this);
              	});                              	
			});
			DC.Target = null;
		}
		public void Dispose(){
			temp_brush_solid.Dispose();
			temp_textfmt.Dispose();
			temp_textlay.Dispose();
			dwFactory.Dispose();
		}
	}
}
