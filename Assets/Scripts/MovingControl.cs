using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingControl : MonoBehaviour
{

    public bool CanMove = false;//是否可动（挂接射线探测，可以实现玩家触发机关）
    public float Bolckspeed;//运动速度
    public bool vertical = true;//方块垂直运动
    public float changeTime = 3.0f;//往复运动周期
    float timer;//计时器
    int fangxiang = 1;//方向
    void Start()
    {

    }
    void Update()
    {
        if (CanMove)
        {
            BolckMove();
            Timer();
        }
    }
    //控制方块运动的方法
    public void BolckMove()
    {
        Vector2 position = gameObject.transform.position;
        //y方向运动
        if (vertical)
        {
            position.y = position.y + Time.deltaTime* Bolckspeed * fangxiang;

        }
        //x
        else
        {
            position.x = position.x + Time.deltaTime * Bolckspeed * fangxiang;

        }
        gameObject.transform.position = position;
    }
    public void Timer()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            fangxiang = -fangxiang;
            timer = changeTime;
        }
    }
    //运动机关触发可以通过主角射线触发。
}
