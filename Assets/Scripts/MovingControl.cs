using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingControl : MonoBehaviour
{

    public bool CanMove = false;//�Ƿ�ɶ����ҽ�����̽�⣬����ʵ����Ҵ������أ�
    public float triggerHeight = 20;//���ش����ĸ߶�
    public float triggerWidth = 5;
    public float Bolckspeed;//�˶��ٶ�
    public bool vertical = true;//���鴹ֱ�˶�
    public float changeTime = 3.0f;//�����˶�����
    float timer;//��ʱ��
    int fangxiang = 1;//����
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

    //���Ʒ����˶��ķ���
    public void BolckMove()
    {
        Vector2 position = gameObject.transform.position;
        //y�����˶�
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
    //�˶����ش�������ͨ���������ߴ�����
}
