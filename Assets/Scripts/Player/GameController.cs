using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController{
    public static int score = 0;
    void Update(){
        
    }
    public static void addScore(int point){
        score += point;
    }

    public static void gameOver(){
        score = 0;
    }

    public static void reStart(){

    }
    public static void victory(){

    }
}
