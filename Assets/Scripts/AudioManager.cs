using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏音频管理 单例类
/// 负责播放游戏
/// 背景音乐
/// 特效音乐
/// 调整音乐大小等
/// </summary>
/// 
public class AudioManager : MonoBehaviour
{
    private static AudioManager m_Instance;
    public static AudioManager GetInstance
    {
        get { return m_Instance; }
    }

    //配置 音频文件
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

    [System.Serializable]
    public struct AudioStruct
    {
        public AudioType audioType;
        public AudioClip audioClip;
    }
    public AudioStruct[] audioManager;
    //public Dictionary<AudioType, AudioClip> dicAudio;
    private AudioClip mainBGM; // 主页面的bgm
    private AudioClip gameBGM; // 游戏中的BGM
    private AudioClip gameClickedAudio; // 游戏按钮点击音效
    private AudioClip gameHoverAudio; // 游戏按钮点击音效
    private AudioClip levelStartAudio; // 
    private AudioClip gameStartAudio;
    private AudioClip gamePassAudio;
    private AudioClip gameFailAudio;

    private AudioClip gameGetScoreAudio;


    //背景音乐播放器
    private AudioSource audioSource_BGM;
    //音效播放器
    private AudioSource audioSource_Sound;
    private AudioSource audioExternSource_Sound;

    public void Awake()
    {
        AudioManager[] audioManagers = GameObject.FindObjectsOfType<AudioManager>();
        if (audioManagers.Length == 1)
            DontDestroyOnLoad(this);
        m_Instance = this;
    }
    public void Start()
    {
        Init();
    }

    private void Init()
    {
        // //初始化音频字典
        // dicAudio = new Dictionary<AudioType, AudioClip>();
        for (int i = 0; i < audioManager.Length; i++)
        {
            switch (audioManager[i].audioType) {
                case AudioType.BGM_MainScene: {
                    mainBGM = audioManager[i].audioClip;
                } break;
                case AudioType.BGM_GameScene: {
                    gameBGM = audioManager[i].audioClip;
                } break;
                case AudioType.GamePass: {
                    gamePassAudio = audioManager[i].audioClip;
                } break;

                case AudioType.GameFail: {
                    gameFailAudio = audioManager[i].audioClip;
                } break;

                case AudioType.LevelStart: {
                    levelStartAudio = audioManager[i].audioClip;
                } break;

                case AudioType.Clicked: {
                    gameClickedAudio = audioManager[i].audioClip;
                } break;

                case AudioType.Hover:
                    {
                        gameHoverAudio = audioManager[i].audioClip;
                    }
                    break;

                default: break;
            }

            //dicAudio.Add(audioManager[i].audioType, audioManager[i].audioClip);
        }

        audioSource_BGM = gameObject.AddComponent<AudioSource>();
        audioSource_BGM.loop = true;
        audioSource_BGM.volume = 0.5f;

        audioSource_Sound = gameObject.AddComponent<AudioSource>();
        audioSource_Sound.loop = false;
        audioSource_Sound.volume = 1.0f;

        audioExternSource_Sound = gameObject.AddComponent<AudioSource>();
        audioExternSource_Sound.loop = false;
        audioExternSource_Sound.volume = 1.0f;
        

    }

    public void PlayAudio(AudioType audioType)
    {

        switch (audioType)
        {
            case AudioType.BGM_MainScene: {
                audioSource_BGM.clip = mainBGM;
                audioSource_BGM.Play();
            } break;
            case AudioType.BGM_GameScene: {
                audioSource_BGM.clip = gameBGM;
                audioSource_BGM.Play();
            } break;
            case AudioType.GamePass: {
                audioSource_Sound.clip = gamePassAudio;
                audioSource_Sound.Play();
            } break;

            case AudioType.GameFail: {
                audioSource_Sound.clip = gameFailAudio;
                audioSource_Sound.Play();
            } break;

            case AudioType.LevelStart: {
                audioSource_Sound.clip = levelStartAudio;
                audioSource_Sound.Play();
            } break;

            case AudioType.Clicked: {
                audioSource_Sound.clip = gameClickedAudio;
                audioSource_Sound.Play();
            } break;
            case AudioType.Hover:
                {
                    audioSource_Sound.clip = gameHoverAudio;
                    audioSource_Sound.Play();
                }
            break;

            default: break;
        }
    }

    public void AudioVolume(float value, bool isBGMAudioSourse)
    { 
        if (isBGMAudioSourse)
        {
            audioSource_BGM.volume = value;
        }
        else
        {
            audioSource_Sound.volume = value;
        }
    }

}
