using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
    public Slider settingsBGMVolmeSlider;
    public Slider settingsBGEMVolmeSlider;
    public Text coinText;
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
        //AudioManager.GetInstance.PlayAudio(AudioManager.AudioType.LevelStart);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex * 2);
        AsyncOperation op = SceneManager.LoadSceneAsync("Scenes/GameMenu");
        op.allowSceneActivation = true;
    }
    // 公共函数
    public void SetScoresNumber(int number) // 设置UI 金币数
    {
        Debug.Log("xxxxx");
        coinText.text = "Scores: " + number.ToString();
    }


}
