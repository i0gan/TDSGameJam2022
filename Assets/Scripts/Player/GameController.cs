using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController:MonoBehaviour{
    public int score = 0;
    public float time = 0;
    public LevelUI ui;
    public Text textUI;
    private GameObject textObj;
    
    public void Init(){
        textObj = (GameObject)Instantiate(Resources.Load("UI/Text"), new Vector3(1000,120,0), transform.rotation);
        textObj.transform.parent = GameObject.Find("Canvas").transform;
        ui = GameObject.Find("Canvas/GameLevelUI").GetComponent<LevelUI>();
        textUI = textObj.GetComponent<Text>();
        textUI.enabled = false;

        score = 0;
        time = 0;
    }

    void Start(){
        Init();
    }
    void Update(){
        time += Time.deltaTime;
    }

    public void addScore(int point){
        score += point;
        ui.SetScoresNumber(score);
    }

    public void reStart(){
        AudioManager.GetInstance.PlayAudio(AudioManager.AudioType.GameFail);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void victory(){
        ui.ShowGamePass(score, (int)time);
        AudioManager.GetInstance.PlayAudio(AudioManager.AudioType.Victory);
    }
    public void setSubtitle(string text){
        textUI.enabled = true;
        textUI.text = text;
    }
    public void HideSubtitle()
    {
        textUI.enabled = false;
    }
}
