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
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.GetInstance.PlayAudio(AudioManager.AudioType.BGM_MainScene);
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
        AsyncOperation op = SceneManager.LoadSceneAsync("Scenes/Level_I0gan");
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

    //刷新关卡显示字符串
    public void RefrashShowText()
    {
        levelText.text = "Level " + level.ToString();
    }

    public void OnClickLastChallLevel()
    {
        Debug.Log("点击上一关");
        if (level <= 1) return;
        selectLevelAnimator.Play("ChangeLevel");
        level -= 1;
        RefrashShowText();
    }
    public void OnClickNextChallLevel()
    {
        Debug.Log("点击下一关");
        if (level >= maxLevel) return;
        selectLevelAnimator.Play("ChangeLevel");
        level += 1;
        RefrashShowText();
    }

    public void StartGame()
    {

    }

}
