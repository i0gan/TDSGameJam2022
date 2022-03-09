using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameMenu : MonoBehaviour
{
    private int level = 1;
    private int maxLevel = 5;
    public Animator selectLevelAnimator; //选择关卡时，selectLevelPanel动画机
    public Text levelText;
    public Slider settingsBGMVolmeSlider;
    public Slider settingsBGEMVolmeSlider;


    public GameObject levelBtn;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.GetInstance.PlayAudio(AudioManager.AudioType.BGM_MainScene);
        RefrashUIShow();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Game Start
    public void LoadSelectLevelScene()
    {
        AudioManager.GetInstance.PlayAudio(AudioManager.AudioType.LevelStart);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex * 2);
        AsyncOperation op = SceneManager.LoadSceneAsync("Scenes/Levels/Level_" + level.ToString());
        op.allowSceneActivation = true;
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    public void NextLevel()
    {

    }

    //刷新UI显示
    public void RefrashUIShow()
    {
        levelText.text = "Level " + level.ToString();
        ChangeLevelImageByLevelNumber(level);
    }

    public void OnClickLastChallLevel()
    {
        Debug.Log("点击上一关");
        if (level <= 1) return;
        selectLevelAnimator.Play("ChangeLevel");
        level -= 1;
        RefrashUIShow();
    }
    public void OnClickNextChallLevel()
    {
        Debug.Log("点击下一关");
        if (level >= maxLevel) return;
        selectLevelAnimator.Play("ChangeLevel");
        level += 1;
        RefrashUIShow();
    }

    public void StartGame()
    {

    }
    public void SettingsBGMActive(bool a)
    {
        if(!a)
        {
            AudioManager.GetInstance.AudioVolume(0.0f, true);
        }
        else
        {
            AudioManager.GetInstance.AudioVolume(1.0f, true);
        }
    }

    public void SettingsAjustBGMVolme() //调整BGM音量
    {
        
        AudioManager.GetInstance.AudioVolume(settingsBGMVolmeSlider.value, true);
        //Debug.Log("i: " + i);
    }

    public void SettingsAjustBGEMVolme() //调整BGEM音量
    {

        AudioManager.GetInstance.AudioVolume(settingsBGMVolmeSlider.value, false);
        //Debug.Log("i: " + i);
    }

    void ChangeLevelImageByLevelNumber(int levelNumber) // 更换关卡背景
    {
        // 更换背景, 全路径为： Assets/Resources/UI/GameMenu/Level_1_bg.png
        levelBtn.GetComponent<Image>().sprite =  LoadSourceSprite("UI/GameMenu/Level_"+ level.ToString() + "_bg");
    }

    
    private Sprite LoadSourceSprite(string relativePath)
    {
        //Debug.Log("relativePath=" + relativePath);
        //把资源加载到内存中
        UnityEngine.Object Preb = Resources.Load(relativePath, typeof(Sprite));
        Sprite tmpsprite = null;
        try
        {
            tmpsprite = Instantiate(Preb) as Sprite;
        }
        catch (System.Exception ex)
        {
            Debug.Log("load sprite NULL: " + relativePath + ex);
        }
        //用加载得到的资源对象，实例化游戏对象，实现游戏物体的动态加载
        return tmpsprite;
    }

}
