/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2021/2/14
 * 时间: 12:06
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using NAudio;
using SharpDX.DirectSound;
using SharpDX.Multimedia;
using System.Threading.Tasks;
namespace doticworks.GameFx.Module.Sound
{
	public class AudioDevice
	{
		static readonly Lazy<AudioDevice> defaultmng=new Lazy<AudioDevice>(()=>{
		     Terminal.WF("<Y>ModuleLoad	<B>Audio  		");
		     AudioDevice gd= new AudioDevice();
		     Terminal.WF("<G>{0}<W>\r\n","<G>Success!<w>");
		     return gd;
		     });
		public static AudioDevice Default{
			get{return defaultmng.Value;}
		}
		public void Cooper(IntPtr ih){
			DirectSound directSound = new DirectSound();

            // Set Cooperative Level to PRIORITY (priority level can call the SetFormat and Compact methods)
            //
            directSound.SetCooperativeLevel(ih, CooperativeLevel.Priority);

            // Create PrimarySoundBuffer
            var primaryBufferDesc = new SoundBufferDescription();
            primaryBufferDesc.Flags = BufferFlags.PrimaryBuffer;
            primaryBufferDesc.AlgorithmFor3D = Guid.Empty;

            var primarySoundBuffer = new PrimarySoundBuffer(directSound, primaryBufferDesc);

            // Play the PrimarySound Buffer
            primarySoundBuffer.Play(0, PlayFlags.Looping);

            // Default WaveFormat Stereo 44100 16 bit
            WaveFormat waveFormat = new WaveFormat();

            // Create SecondarySoundBuffer
            var secondaryBufferDesc = new SoundBufferDescription();
            secondaryBufferDesc.BufferBytes = waveFormat.ConvertLatencyToByteSize(60000);
            secondaryBufferDesc.Format = waveFormat;
            secondaryBufferDesc.Flags = BufferFlags.GetCurrentPosition2 | BufferFlags.ControlPositionNotify | BufferFlags.GlobalFocus |
                                        BufferFlags.ControlVolume | BufferFlags.StickyFocus;
            secondaryBufferDesc.AlgorithmFor3D = Guid.Empty;
            var secondarySoundBuffer = new SecondarySoundBuffer(directSound, secondaryBufferDesc);

            // Get Capabilties from secondary sound buffer
            var capabilities = secondarySoundBuffer.Capabilities;

            // Lock the buffer
            SharpDX.DataStream dataPart2;
            var dataPart1 =secondarySoundBuffer.Lock(0, capabilities.BufferBytes,  LockFlags.EntireBuffer, out dataPart2);
			
            // Fill the buffer with some sound
            int numberOfSamples = capabilities.BufferBytes/waveFormat.BlockAlign;
            for (int i = 0; i < numberOfSamples; i++)
            {
                double vibrato = Math.Cos(2 * Math.PI * 10.0 * i /waveFormat.SampleRate);
                short value = (short) (Math.Cos(2*Math.PI*(220.0 + 4.0 * vibrato)*i/waveFormat.SampleRate)*16384); // Not too loud
                dataPart1.Write(value);
            //    dataPart1.Write(value);
            }
			
            // Unlock the buffer
            secondarySoundBuffer.Unlock(dataPart1, dataPart2);

            // Play the song
            secondarySoundBuffer.Play(0, PlayFlags.Looping);
             secondarySoundBuffer.Play(0, PlayFlags.Looping);
              secondarySoundBuffer.Play(0, PlayFlags.Looping);
               secondarySoundBuffer.Play(0, PlayFlags.Looping);
		}
		
		AudioDevice()
		{
			

            
		}
		
	}
}
