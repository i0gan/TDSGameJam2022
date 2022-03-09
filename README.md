# TDSGameJam2022
TDS GameJam 2022

策划文档链接：

[2022招新gj《Change the world》策划案 - Feishu Docs](https://thinkdifferent.feishu.cn/docs/doccnutJecW08ftEopMfVFUznMg)



## Unity启动场景

Scenes/GameStart //里面包含了音频单例实例，可用来管理音频。若需使用，只需在代码中加入以下代码。

```c#
AudioManager.GetInstance.PlayAudio(AudioManager.AudioType.BGM_MainScene); // 播放主音乐

// 其中音乐播放类型有
public enum AudioType
    {
        BGM_MainScene, // 主界面音乐
        BGM_GameScene, // 游戏音乐
        Clicked,       // 点击音效
        Hover,         // 鼠标Hover音效
        LevelStart,    // 关卡点击开始音效
        gameStart,     // 游戏关卡音效
        GamePass,      // 关卡通过音效
        GameFail,      // 关卡失败音效
        GameGetScore,  // 得分音效

    }
```



## 主题公布

 “变化”（Change）。变化，可以是单位/角色的移动、也可以是游戏机制的改变、可以是人物/肖像/地图（场景）/剧情（故事）的变化、甚至是对象/物体的特征转变，更有甚者是游戏氛围等相关因素的变化……

希望大家不要被“传统的”理念和认知所束缚，这一主题有着无限的灵感源泉和创作可能，请同学们尽情发挥自己的思维，用自己的作品来诠释自己的“变化”。  



## 队伍信息

队伍名称： 你说的都队

队长	辜恒洋	程序	15719414739

队员	温建林	程序	xxx

队员	徐绿国	程序	15718077762

队员	周欣悦	策划	18582980330

队员	叶卓成	美术	18328306601





## 仓库结构信息

包含了文档以及客户端代码。

Assets: Unity3d项目代码

Documents: 项目文档





