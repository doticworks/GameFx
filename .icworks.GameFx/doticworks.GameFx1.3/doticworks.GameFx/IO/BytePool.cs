/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2020/12/13
 * 时间: 13:32
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
namespace doticworks.GameFx.IO
{
	public class BytePool
	{
		byte[] temp;
		public void Push(byte[] b){
			byte[] pt=new byte[temp.LongLength+b.LongLength];
			long templ=temp.LongLength;long bl=b.LongLength;
			for(long i=0;i<templ;i++){
				pt[i]=temp[i];
			}for(long i=templ;i<templ+bl;i++){
				pt[i]=b[i-templ];
			}
			temp=pt;
		}
		public byte[] Pop(long llength){
			if(llength>temp.LongLength){
				return null;
			}
			byte[] rt=new byte[llength];
			for(long i=0;i<llength;i++){
				rt[i]=temp[i];
			}
			long templ=temp.LongLength;
			byte[] ntemp=new byte[templ-llength];
			for(long i=llength;i<templ;i++){
				ntemp[i-templ]=temp[i];
			}
			temp=ntemp;
			return rt;
		}
		public long Len{
			get{
				return temp.LongLength;
			}
		}
	}
}
