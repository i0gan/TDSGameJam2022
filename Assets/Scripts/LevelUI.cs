using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
    public Slider settingsBGMVolmeSlider;
    public Slider settingsBGEMVolmeSlider;
    public GameObject gamePassPanel;
    public Text scoreText;
    public Text gamePassScoreText;
    public Text gamePassTimeText;

    // Start is called before the first frame update
    void Start()
    {
        SetScoresNumber(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SettingsBGMActive(bool a)
    {
        if (!a)
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


    public void ExitScene()
    {
        GameMenu.isShowSelectPanel = false; // 是否显示Select界面
        AsyncOperation op = SceneManager.LoadSceneAsync("Scenes/GameMenu");
        op.allowSceneActivation = true;
    }
    // 公共函数
    public void SetScoresNumber(int number) // 设置UI 金币数
    {
        scoreText.text = "Scores: " + number.ToString();
    }

    public void ShowGamePass(int score, int time)
    {
        gamePassPanel.SetActive(true);
        gamePassScoreText.text = "Scores: " + score.ToString();
        gamePassTimeText.text = "Time: " + time.ToString();
    }

    public void OnClickNextLevel()
    {
        // Next
        Debug.Log("OnClickNextLevel ");
        GameMenu.isShowSelectPanel = true;
        GameMenu.AddLevelNumber();
        AsyncOperation op = SceneManager.LoadSceneAsync("Scenes/GameMenu");
        op.allowSceneActivation = true;
    }

}
