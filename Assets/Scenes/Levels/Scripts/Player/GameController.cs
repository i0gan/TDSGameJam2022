using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController:MonoBehaviour{
    public int score = 0;
    public float time = 0;
    public LevelUI ui;

    
    public void Init(){
        ui = GameObject.Find("Canvas/GameLevelUI").GetComponent<LevelUI>();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void victory(){
        ui.ShowGamePass(score, (int)time);
        AudioManager.GetInstance.PlayAudio(AudioManager.AudioType.Victory);
    }
}
