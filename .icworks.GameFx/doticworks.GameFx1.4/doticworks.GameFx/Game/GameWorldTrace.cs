using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using doticworks.GameFx.Game.Components;

namespace doticworks.GameFx.Game
{
    public partial class GameWorld
    {
        void Trace(){
            Stopwatch sw=new Stopwatch();
            while(true){
                sw.Start();
                inputUpdate();
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
    }
}