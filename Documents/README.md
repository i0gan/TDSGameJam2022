# GameJam文档



## 主题公布

 “变化”（Change）。变化，可以是单位/角色的移动、也可以是游戏机制的改变、可以是人物/肖像/地图（场景）/剧情（故事）的变化、甚至是对象/物体的特征转变，更有甚者是游戏氛围等相关因素的变化……

希望大家不要被“传统的”理念和认知所束缚，这一主题有着无限的灵感源泉和创作可能，请同学们尽情发挥自己的思维，用自己的作品来诠释自己的“变化”。





## 关卡选择图片替换

### 图片要求：

关卡截图 + 美化

图片尺寸： 1000 x 600

图片格式： png

图片命名： Level_1_bg.png （代表关卡1的背景图）,  Level_2_bg.png （关卡2的背景图）， 总的需要5张。



程序要求：

Assets/Resources/UI/GameMenu/Level_xxxx.png 替换一下。


## Unity游戏启动场景入口

Scenes/GameStart 




## 音频播放

音频播放脚本： Scripts/AudioManager.cs

如何播放：

```c#
// 在自己的代码中加入 一句话播放音频代码，增加音频特效请看代码
AudioManager.GetInstance.PlayAudio(AudioManager.AudioType.Fired); //通过枚举播放
```

加入完毕后，还需要从GameStart场景中运行，不然音频会未初始化报错。



## UI函数如何调用

在自己的代码中加入

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // 需加入
    public GameObject uiObj; // 先从界面将Canvas/GameLevelUI 对象赋予到该变量
    // Start is called before the first frame update
    void Start()
    {
        //调用方式：
        uiObj.GetComponent<LevelUI>().SetScoresNumber(13434); // 设定UI显示分数。
    }
}

```

UI API

```
void SetScoresNumber(int score);       // 传入分数值
void ShowGamePass(int score, int time); //显示游戏过关UI， 传入分数以及用时，用时单位为秒
```

例子：进入场景后，3秒后自动过关：

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject t;
    void Start()
    {
        Invoke("GamePass", 3.0f);
    }
    void GamePass()
    {
        t.GetComponent<LevelUI>().ShowGamePass(1, 2); // 调用显示过关UI
    }
}

```

  
