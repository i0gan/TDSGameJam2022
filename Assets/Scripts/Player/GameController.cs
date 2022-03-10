using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(score>30) victory();
    }

    public void gameOver(){
        score = 0;
    }

    public void reStart(){

    }
    public void victory(){
        ui.ShowGamePass(score, (int)time);
    }
}
