using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolckControl : MonoBehaviour
{
    //����
    public Sprite[] BolckSprite;//��0��1��2��3��4
    private SpriteRenderer sr;
    private BoxCollider2D bc;
    public float HowLongTime = 2;
    private bool PurpleCanKill = true;
    //��ȡϵͳ������Ⱦ��SpriteRenderer���
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Look();
        isBox();
        isTrigger();
    }

    //��ۣ����飩
    private void Look()
    {
        if (gameObject.tag == "Grey")
        {
            sr.sprite = BolckSprite[0];
        }
        else if (gameObject.tag == "Brown")
        {
            sr.sprite = BolckSprite[1];
        }
        else if (gameObject.tag == "Orange")
        {
            sr.sprite = BolckSprite[2];
        }
        else if (gameObject.tag == "Yellow")
        {
            sr.sprite = BolckSprite[3];
        }
        else if (gameObject.tag == "Rad")
        {
            sr.sprite = BolckSprite[4];
        }
        else if (gameObject.tag == "DeadLine")
        {
            sr.sprite = BolckSprite[6]; 
        }
        else if (gameObject.tag == "Purple")
        {
            sr.sprite = BolckSprite[5]; 
        }
    }
    //�Ƿ������ײ��
    private void isBox()
    {
        if (gameObject.tag == "Grey")
        {
            bc.enabled = false;
        }
        else if (gameObject.tag == "Brown")
        {
            bc.enabled = true;
        }
        else if (gameObject.tag == "Orange")
        {
            bc.enabled = true;
        }
        else if (gameObject.tag == "Yellow")
        {
            bc.enabled = true;
        }
        else if (gameObject.tag == "Rad")
        {
            bc.enabled = true;
        }
        else if (gameObject.tag == "DeadLine")
        {
            bc.enabled = true;
        }
        else if (gameObject.tag == "Purple")
        {
            bc.enabled = true; 
        }
    }

    //����Ƿ�Ϊ������
    private void isTrigger()
    {
        if (gameObject.tag == "Brown")
        {
            bc.isTrigger = false;
        }
        
        else if (gameObject.tag == "Orange")
        {
            bc.isTrigger = false;
        }
        else if (gameObject.tag == "Yellow")
        {
            bc.isTrigger = true;
        }
        else if (gameObject.tag == "Rad")
        {
            bc.isTrigger = true;
        }
        else if (gameObject.tag == "DeadLine")
        {
            bc.isTrigger = true;
        }
        else if (gameObject.tag == "Purple")
        {
            bc.isTrigger = true;
        }
    }
    //�������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(gameObject.tag== "Yellow")
            {
                Destroy(gameObject);
                GameObject.Find("player").SendMessage("AddScore");
            }
            else if (gameObject.tag == "Rad")
            {
                //���س���
            }
            else if (gameObject.tag == "DeadLine")
            {
                //���س���
            }
            else if (gameObject.tag == "Purple")
            {
                if (PurpleCanKill)
                {
                    //���س���
                }
            }
        }
    }
    //��ײ���
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(gameObject.tag== "Brown")
            {
                Invoke("Destroy", HowLongTime);
            }
        }
    }

    //�ݻ���鷽��
    private void Destroy()
    {
        Destroy(this.gameObject);
    }

    //Readme:
    //�֣��ƽӴ�player��ʧ�Ĺ�����ɣ�����ͨ���ı����BlockControl�ű������ú�ɫ����ӳ����ٳ�����
    //�����ӷֹ�����ɣ�����Score�洢�����ǽű�CharcterControler����������UI�ҽӼ��ɣ�
    //���deadline������ɣ�����ʱ�����ص�ǰ�����Ĵ��벹ȫ���ɣ�
    //δ��ɣ�
    //��ɫ��鹦��δ��ɣ��ƻ������ǽű����
    //��ɫ����˺�����δ��ɣ��ƻ�ͨ�����ǽű���ȡ��ɫ���ʱ��ı�PurpleCanKill�������Ƿ����˺�

}
