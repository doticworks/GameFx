

<font size=4 color=dodgerblue>.IC</font><font size=4 >WORKS</font>
------
# <font size=1000 color=Dodgerblue>GameFx Docs</font>

------

[TOC]

------

## Welcome!


> ### What's GameFx
>
> > A Low Thing
>
> ### Updates
>
> > Version 1.4.0 As the latest debug version
> >
> > Version 1.3.3 As the latest release version
>
> ### Logs
>
> > Effects and MultiCore Rendering is <font color=dodgerblue>developing</font>

## Summary

> A Link Lib with Managed DirectX11 and Physics for C# beginners

## Getting Start!

### IOMachine

> `*Namespace doticworks.GameFx.GAME*`
>
> New a IOMachine in global value
>
> ```c#
> IOMachine iom;
> void Shown(s,e){
> iom=new IOMachine(this.Handle);
> }
> ```
>
> and then you can add game input logic
>
> ```c#
> iom.InputMap.KeyPress(Keys.F2,()=>{
> 	iom.DebugMode=!iom.DebugMode;
> });
> iom.InputMap.MousePress(MouseButtons.Left,()=>{
> 	l2.Active=!l2.Active;
> });
> ```
>
> and render logic
>
> ```c#
> iom.Render.root.Add("L2",l2);
> l2.paint=rdx=>{
> 		rdx._Text(300,30,iom.CanFps.ToString()+""+the.ToString(),20,0.2f,0.4f,0.6f,1);
> 				rdx._Transform(new doticworks.GameFx.COMMON.Transform(iom.InputMap.Mousex,iom.InputMap.Mousey,the,1,1));
> 				rdx._Text(300,50,"F1:SetFps",20,0.2f,0.4f,0.6f,1);
> 				rdx._Text(300,70,"F2:SetDebug",20,0.2f,0.4f,0.6f,1);
> 				rdx._Rectangle_Fill(250,250,100,100,0.5f,0.5f,0.5f,1f);
> 				rdx._Transform(new doticworks.GameFx.COMMON.Transform(0,0,0,1,1));
> 			};
> ```
>
> finally you should invoke StartGame after all repair thing done
>
> ```C#
> iom.StartGame();
> ```
>
> 

### Assetor

>*`Namespace doticworks.GameFx.IO`*
>
>Assetor can help you get embed asset simplil
>define a value at global
>
>```C#
>Assetor asset=new Assetor();
>```
>
>then you can invoke it anywhere   but you had better done the asset-load work in the formShown
>
>(if there are many asset to load   you can run it in a indie thread to not delay the math thread speed)
>
>you can use it as this
>
>```c#
>Bitmap bmp=asset.GetBitmap("demo.assets.a.png");
>```
>
>the path is the internal path in the project    and plz remember **EMBED IT**!

## **Docs**

### Namespaces

#### Common

##### Texture

> A abstract class which defines the common interface of Texture



##### TransformRaw

> A matrix defines the transform of the screen or a GameObject's location

##### Transform : TransformRaw

> Translate X Y Theta Scalex Scaley To matrix
>
> ``` c#
> new doticworks.GameFx.COMMON.Transform(iom.InputMap.Mousex,iom.InputMap.Mousey,the,1,1)  //new a Transform
> ```
>

#### GAME

##### Canvas

> The class has not been used in the fx 
>
> but you can use it to output some temp images

##### InputMap

> A class defines the input processing logic
>
> You can regist a 
>
> ```c#
> Action
> ```
>
> for a keyevent(Such as "Keydown"in key"Space")
>
> demo
>
> ```c#
> iom.InputMap.KeyPress(Keys.F2,()=>{iom.DebugMode=!iom.DebugMode;});
> iom.InputMap.MousePress(MouseButtons.Left,()=>{l2.Active=!l2.Active;});
> iom.InputMap.MousePress(MouseButtons.Right,()=>{iom.FullScreen=!iom.FullScreen; });
> ```

##### IOMachine

> A Class



