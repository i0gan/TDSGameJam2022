using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolckControl : MonoBehaviour
{
    //����
    public Sprite[] BolckSprite;//��0��1��2��3��4
    private SpriteRenderer sr;
    private BoxCollider2D bc;
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
    }

    //���
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
    }
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
    }
    private void SelfDestroy()
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
    }
}
 