/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2020/11/21
 * 时间: 20:52
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Timers;
using System.Collections.Generic;
namespace doticworks.GameFx.GAME
{
	/// <summary>
	/// Description of InputMap.
	/// </summary>
	public partial class InputMap
	{
		Dictionary<string,System.Timers.Timer> _temptimers=new Dictionary<string, Timer>();
		public void TimerStart(string timerkey,int delay_ms,Action arg){
			Timer timer=new Timer();
			if(_temptimers.ContainsKey(timerkey)){throw new Exception("the timer name has been added\r\nplease change ");}
			_temptimers.Add(timerkey,timer);
			timer.Interval=(double)delay_ms;
			timer.Elapsed+=(s,e)=>{
				arg();
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
		public void TimerDelay(int delay_ms,Action arg){
			Timer timer=new Timer();
			timer.Interval=(double)delay_ms;
			timer.Elapsed+=(s,e)=>{
				timer.Enabled=false;
				arg();
				timer.Dispose();
			};
			timer.Enabled=true;
		}
		public void TimerCallCount(int delay_ms,int count,Action<int> arg){
			Timer timer=new Timer();
			timer.Interval=(double)delay_ms;
			int ccmax=count;
			int callcount=0;
			timer.Elapsed+=(s,e)=>{
				callcount++;
				if(callcount>=ccmax){timer.Enabled=false;timer.Dispose();}
				arg(callcount);
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
