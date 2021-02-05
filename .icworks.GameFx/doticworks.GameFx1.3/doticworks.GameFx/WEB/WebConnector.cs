/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/12/13
 * 时间: 11:38
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using doticworks.GameFx.IO;
using System.Collections.Generic;
namespace doticworks.GameFx.WEB
{
	/// <summary>
	/// Description of WebConnector.
	/// </summary>
	public partial class WebConnector:IDisposable
	{
		public WebID wid=new WebID();
		public Socket client;
		Thread th;
		Action clientdisconnected;
		Dictionary<WebID,WebConnector> connectlist=new Dictionary<WebID, WebConnector>();
		public WebConnector(Dictionary<WebID,WebConnector> connectlis,Socket remoteclient,Action clientdisc){
			connectlist=connectlis;
			client=remoteclient;
			clientdisconnected=clientdisc;
			th=new Thread(()=>{clientTrace();});
			th.IsBackground=true;
			th.Start();
		}
		
		void clientTrace(){
			byte[] buffer=new byte[4*1024];
			byte[] temp;
			byte[] temp2;
			int n=1;
			BytePool bp=new BytePool();
			WebMsg wmtemp;
			long pakl=500000000000L;
			while(true)
			{
				while(pakl<=bp.Len){
					temp=bp.Pop(pakl);
					if(temp==null){break;}
					wmtemp=Serializer.Unseria(temp) as WebMsg;
					if(connectlist.ContainsKey(wmtemp.To)){
						connectlist[wmtemp.To].Send(temp);
					}else{
						Send(temp);
					}
				}
				try{
					n=client.Receive(buffer);
					temp2=new byte[n];
					for(long i=0;i<n;i++){
						temp2[i]=buffer[i];
					}
					bp.Push(temp2);
				}catch(Exception){
					clientdisconnected();
					Dispose();
					return;
				}
			}
		}
		public void Send(byte[] buf){
			client.Send(buf);
		}
		public void Dispose(){
			th.Abort();
		}
	}
}
