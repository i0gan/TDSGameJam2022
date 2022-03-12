using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingControl : MonoBehaviour
{

    public bool CanMove = false;//是否可动（挂接射线探测，可以实现玩家触发机关）
    public float triggerHeight = 20;//机关触发的高度
    public float triggerWidth = 5;
    public float Bolckspeed;//运动速度
    public bool vertical = true;//方块垂直运动
    public float changeTime = 3.0f;//往复运动周期
    float timer;//计时器
    int fangxiang = 1;//方向
    private GameObject player;
    void Start()
    {
        player = GameObject.Find("player");
    }
    void Update()
    {
        cheakTrigger();
        if (CanMove)
        {
            BolckMove();
            Timer();
        }
    }

    void cheakTrigger()
    {
        if ((uint)(transform.position.y - player.transform.position.y) < triggerHeight &&
                Mathf.Abs(transform.position.x - player.transform.position.x) < triggerWidth)
            CanMove = true;
    }

    //控制方块运动的方法
    public void BolckMove()
    {
        Vector2 position = gameObject.transform.position;
        //y方向运动
        if (vertical)
        {
            position.y = position.y + Time.deltaTime* Bolckspeed * fangxiang;
            if (gameObject.tag=="Rad")
            {
                gameObject.transform.Rotate(0, 0, 2);
            }

        }
        //x
        else
        {
            position.x = position.x + Time.deltaTime * Bolckspeed * fangxiang;
            if (gameObject.tag == "Rad")
            {
                gameObject.transform.Rotate(0, 0, 2);
                
            }

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
