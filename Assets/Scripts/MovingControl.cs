using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingControl : MonoBehaviour
{

    public bool CanMove = false;//�Ƿ�ɶ����ҽ�����̽�⣬����ʵ����Ҵ������أ�
    public float Bolckspeed;//�˶��ٶ�
    public bool vertical = true;//���鴹ֱ�˶�
    public float changeTime = 3.0f;//�����˶�����
    float timer;//��ʱ��
    int fangxiang = 1;//����
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
    //���Ʒ����˶��ķ���
    public void BolckMove()
    {
        Vector2 position = gameObject.transform.position;
        //y�����˶�
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
    //�˶����ش�������ͨ���������ߴ�����
}
