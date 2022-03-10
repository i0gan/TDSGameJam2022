using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController{
    public static bool isInit;
    public static int score = 0;
    public static GameObject uiObj;

    public static void Init(){
        uiObj = GameObject.Find("Canvas/GameLevelUI");
    }

    public static void addScore(int point){
        if (isInit == false) Init();
        score += point;
        uiObj.GetComponent<LevelUI>().SetScoresNumber(score);
    }

    public static void gameOver(){
        score = 0;
    }

    public static void reStart(){

    }
    public static void victory(){

    }
}
