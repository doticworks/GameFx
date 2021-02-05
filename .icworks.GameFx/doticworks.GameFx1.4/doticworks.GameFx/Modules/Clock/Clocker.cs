using System;
using System.Collections.Generic;
using System.Timers;
namespace doticworks.GameFx.Modules.Clock
{
    public class Clocker
    {
        static readonly Lazy<Clocker> defaultmng=new Lazy<Clocker>(()=>{
            Terminal.WF("<Y>ModuleLoad	<B>Clocker  	");
            Clocker gd= new Clocker();
            Terminal.WF("<G>{0}<W>\r\n","<G>Success!<w>");
            return gd;
        });
        public static Clocker _{
            get{return defaultmng.Value;}
        }

        private Clocker()
        {
        }

        Dictionary<string,System.Timers.Timer> _temptimers=new Dictionary<string, Timer>();
        public void TimerStart(string timerkey,int delay_ms,Action arg,Func<bool> bindingEnable=null){
            Timer timer=new Timer();
            if(_temptimers.ContainsKey(timerkey)){throw new Exception("the timer name has been added\r\nplease change ");}
            _temptimers.Add(timerkey,timer);
            timer.Interval=(double)delay_ms;
            timer.Elapsed+=(s,e)=>{
                if (bindingEnable != null)
                {
                    if (bindingEnable())
                    {
                        arg();
                    }
                }else
                {
                    arg();
                }
            };
            timer.Enabled=true;
        }
        public void TimerSet(string timerkey,bool enabled){
            _temptimers[timerkey].Enabled=enabled;
        }
        public void TimerSet(string timerkey,int delay_ms){
            _temptimers[timerkey].Interval=(double)delay_ms;
        }
        public void TimerRemove(string timerkey){
            _temptimers[timerkey].Dispose();
            _temptimers.Remove(timerkey);
        }
        public void TimerDelay(int delay_ms,Action arg,Func<bool> bindingEnable=null){
            Timer timer=new Timer();
            timer.Interval=(double)delay_ms;
            timer.Elapsed+=(s,e)=>{
                timer.Enabled=false;
                if (bindingEnable != null)
                {
                    if (bindingEnable())
                    {
                        arg();
                    }
                }else
                {
                    arg();
                }
                timer.Dispose();
            };
            timer.Enabled=true;
        }
        public void TimerCallCount(int delay_ms,int count,Action<int> arg,Func<bool> bindingEnable=null){
            Timer timer=new Timer();
            timer.Interval=(double)delay_ms;
            int ccmax=count;
            int callcount=0;
            timer.Elapsed+=(s,e)=>{
                callcount++;
                if(callcount>=ccmax){timer.Enabled=false;timer.Dispose();}

                if (bindingEnable != null)
                {
                    if (bindingEnable())
                    {
                        arg(callcount);
                    }
                }
                else
                {
                    arg(callcount);
                }
                
            };
            timer.Enabled=true;
        }
        public void DisposeAllTimer(){
            foreach(var item in _temptimers){
                item.Value.Dispose();
            }
        }
    }
}