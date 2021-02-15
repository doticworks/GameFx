using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using doticworks.GameFx.Game.Components;
using doticworks.GameFx.Common;
namespace doticworks.GameFx.Game
{
    public partial class GameWorld
    {
        void Trace(){
            Stopwatch sw=new Stopwatch();
            while(true){
                sw.Start();
                InputUpdate();
                if(DebugMode){
                    sw.Stop();
                    TickInput=sw.ElapsedTicks;
                    sw.Start();}
                root.components.RI_ComNode.TreeInvoke((gx) =>
                {
                    gx.components.Onupdate(DeltaTime);
                //    gx.components.DoComponents<ComEvent>((ce) => { ce.OnUpdate(DeltaTime); });
                });
                if(DebugMode){
                    sw.Stop();
                    TickUpdate=sw.ElapsedTicks;
                    sw.Start();}
                
                if (needresize)
                {
                    needresize = false;
                    ClientResize(needrsw,needrsh);
                    
                }
                presenter.Draw();
                presenter.Present();
                sw.Stop();
                if(DebugMode){
                    TickPresent=sw.ElapsedTicks-TickInput-TickUpdate;}

                
                
                int MaxTickTime=(int)(1000/MaxFps);
                float allms=(float)sw.ElapsedTicks/10000f;
                if(allms<MaxTickTime){
                    Thread.Sleep((int)(MaxTickTime-allms));
                    //	Thread.Sleep((int)(5));
                    NowFps=MaxFps;
                    CanFps=(int)(1000/allms);
                    DeltaTime = 0.025f;
                }else{
                    DeltaTime = sw.ElapsedTicks    / 10000f/1000f;
                    NowFps=(int)(1000/allms);
                    CanFps=(int)(1000/allms);
                }
                sw.Reset();
            }
        }
    //	MouseButtons btncv(int arg){if(arg==0){return MouseButtons.Left;}if(arg==1){return MouseButtons.Right;}if(arg==2){return MouseButtons.Middle;}return MouseButtons.None;}
    	void InputUpdate(){
    		ia.OnUpdate(
                mousepos:(x,y,z)=>{
    				root.components.RI_ComNode.TreeInvoke((g)=>{if(g.components.RI_ComInput==null){return;}g.components.RI_ComInput.MouseMove(new Vector2(x,y),z);});
    			},
             	mousebuttondown:(l,r,m)=>{/* 
    				if(l){root.components.RI_ComNode.TreeInvoke((g)=>{g.components.RI_ComInput.MouseDown(MouseButtons.Left);});}
    				if(r){root.components.RI_ComNode.TreeInvoke((g)=>{g.components.RI_ComInput.MouseDown(MouseButtons.Right);});}
    				if(m){root.components.RI_ComNode.TreeInvoke((g)=>{g.components.RI_ComInput.MouseDown(MouseButtons.Middle);});}
    			*/},
    			mousebuttonToClick:(l,r,m)=>{
	    			if(l){root.components.RI_ComNode.TreeInvoke((g)=>{if(g.components.RI_ComInput==null){return;}g.components.RI_ComInput.MouseDown(MouseButtons.Left);});}
	    			if(r){root.components.RI_ComNode.TreeInvoke((g)=>{if(g.components.RI_ComInput==null){return;}g.components.RI_ComInput.MouseDown(MouseButtons.Right);});}
	    			if(m){root.components.RI_ComNode.TreeInvoke((g)=>{if(g.components.RI_ComInput==null){return;}g.components.RI_ComInput.MouseDown(MouseButtons.Middle);});}
    			},
		    	mousebuttonToRelease:(l,r,m)=>{
	    			if(l){root.components.RI_ComNode.TreeInvoke((g)=>{if(g.components.RI_ComInput==null){return;}g.components.RI_ComInput.MouseUp(MouseButtons.Left);});}
	    			if(r){root.components.RI_ComNode.TreeInvoke((g)=>{if(g.components.RI_ComInput==null){return;}g.components.RI_ComInput.MouseUp(MouseButtons.Right);});}
	    			if(m){root.components.RI_ComNode.TreeInvoke((g)=>{if(g.components.RI_ComInput==null){return;}g.components.RI_ComInput.MouseUp(MouseButtons.Middle);});}
		    	},
    			mousebuttonKeepHold:(l,r,m)=>{
	    			if(l){root.components.RI_ComNode.TreeInvoke((g)=>{if(g.components.RI_ComInput==null){return;}g.components.RI_ComInput.MouseHold(MouseButtons.Left);});}
	    			if(r){root.components.RI_ComNode.TreeInvoke((g)=>{if(g.components.RI_ComInput==null){return;}g.components.RI_ComInput.MouseHold(MouseButtons.Right);});}
	    			if(m){root.components.RI_ComNode.TreeInvoke((g)=>{if(g.components.RI_ComInput==null){return;}g.components.RI_ComInput.MouseHold(MouseButtons.Middle);});}
		    	},
                mousedoubleclick:(l,r,m)=>{
	                if(l){root.components.RI_ComNode.TreeInvoke((g)=>{if(g.components.RI_ComInput==null){return;}g.components.RI_ComInput.MouseDouble(MouseButtons.Left);});}
	                if(r){root.components.RI_ComNode.TreeInvoke((g)=>{if(g.components.RI_ComInput==null){return;}g.components.RI_ComInput.MouseDouble(MouseButtons.Right);});}
	                if(m){root.components.RI_ComNode.TreeInvoke((g)=>{if(g.components.RI_ComInput==null){return;}g.components.RI_ComInput.MouseDouble(MouseButtons.Middle);});}
                },
    			multicallkeydown:(keys) =>{
    				root.components.RI_ComNode.TreeInvoke((g)=>{if(g.components.RI_ComInput==null){return;}g.components.RI_ComInput.KeyDown(keys);});
    			},
	    		multicallkeyToClick:(keys)=>{
	    			root.components.RI_ComNode.TreeInvoke((g)=>{if(g.components.RI_ComInput==null){return;}g.components.RI_ComInput.KeyDown(keys);});
	    		},
				multicallkeyToRelease:(keys)=>{
					root.components.RI_ComNode.TreeInvoke((g)=>{if(g.components.RI_ComInput==null){return;}g.components.RI_ComInput.KeyUp(keys);});
				},
				multicallkeyKeepHold:(keys)=>{
					root.components.RI_ComNode.TreeInvoke((g)=>{if(g.components.RI_ComInput==null){return;}g.components.RI_ComInput.KeyHold(keys);});
    		});
    		
    			
    		
                
    	}
    }
}