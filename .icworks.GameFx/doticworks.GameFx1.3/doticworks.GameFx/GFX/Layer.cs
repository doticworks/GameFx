/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/12/21
 * 时间: 11:52
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace doticworks.GameFx.GFX
{
	public class Layer
	{
		public Layer(float index)
		{
			paint=(r)=>{};
		}
		float x=0;
		float y=0;
		public Action<Render> paint;
		bool active=true;
		float index=1;
		public LayerNode parent=null;
		public bool hasparent=false;
		
		public float Index{
			get{
				return index;
			}set{
				index=value;layervaluechanged();
			}
		}
		public bool Active{
			get{
				return active;
			}set{
				active=value;layervaluechanged();
			}
		}
		
		void layervaluechanged(){
			if(hasparent){parent.ChildUpdated();}
		}
		public virtual void Draw(Render rd){
			paint(rd);
		}
	}
}
