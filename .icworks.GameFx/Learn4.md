手机上打的 以下为转义表
 go~gameobject
配置一个gameobj 并把它加入gameworld这个gameobject就会被执行
它的各个组件就会按照配置好的运行

gameobject是一个具体的单位
component实现具体的功能 如画图 输入等
component基本分为以下几类
画图类
comrender 所有绘图组件的基类
comrenderkeynode 关键节点  把子节点画入缓存 再以此缓存画给母节点
          其中根结点的画图组件就是这个 只不过是画在屏幕上
comrendernormal  标准的绘图组件 相当于原来的render 但坐标原点是在gameobject的位置坐标

comnode  节点组件  保存子gameobject
cominput  输入组件  键盘的press release hold   鼠标的press release hold double
comevent  事件组件  每帧的事件  等

为了方便使用 无需每次搞gameobject都要从0开始配组件
于是有了prefabgameobject  里面有些已经配置好的gameobject
可以clone出来再进行细节配置

##gameworld
gameworld把gameobject树中的各个组件与对应的功能模块连接 以实现具体的功能
这样子就不用直面各个杂乱的模块 可以直接通过配置组件来达到具体的功能

gameworld要先load游戏 配置好初始场景 再通过调用startgame来开始游戏
在还没startgame前 窗口上可以显示一张图片可以是游戏的主题画面什么的   
而开始游戏后假如要丝滑的效果 就也先显示主题画
