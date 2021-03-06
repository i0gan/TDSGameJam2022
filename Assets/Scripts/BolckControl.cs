using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolckControl : MonoBehaviour
{
    //引用
    public Sprite[] BolckSprite;//灰0褐1橙2黄3红4
    private SpriteRenderer sr;
    private BoxCollider2D bc;
    public float HowLongTime = 2;
    public bool PurpleCanKill = true;
    public int yellowScore = 100;
    //获取系统精灵渲染器SpriteRenderer组件
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

    //外观（精灵）
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
        else if (gameObject.tag == "Stone")
        {
            sr.sprite = BolckSprite[7];
        }
    }
    //是否具有碰撞体
    private void isBox()
    {
        if (gameObject.tag == "Grey")
        {
            bc.enabled = true;
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
        else if (gameObject.tag == "Stone")
        {
            bc.enabled = true;
        }
    }

    //物块是否为触发器
    private void isTrigger()
    {
        
        if (gameObject.tag == "Brown")
        {
            bc.isTrigger = false;
        }

        else if (gameObject.tag == "Grey")
        {
            bc.isTrigger = true;
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
        else if (gameObject.tag == "Stone")
        {
            bc.isTrigger = false;
        }
    }
    //触发检测
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(gameObject.tag== "Yellow")
            {
                Destroy(gameObject);
                GameObject.Find("player").GetComponent<GameController>().addScore(yellowScore);
                AudioManager.GetInstance.PlayAudio(AudioManager.AudioType.GameGetScore);
            }
            else if (gameObject.tag == "Rad")
            {
                GameObject.Find("player").SendMessage("reStart");
            }
            else if (gameObject.tag == "DeadLine")
            {
                GameObject.Find("player").SendMessage("reStart");
            }
            else if (gameObject.tag == "Purple")
            {
                if (PurpleCanKill)
                {
                    GameObject.Find("player").SendMessage("reStart");
                }
            }
            else if (gameObject.tag == "GameVictory")
            {
                GameObject.Find("player").SendMessage("victory");
            }
        }
    }
    //碰撞检测
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

    //摧毁物块方法
    private void Destroy()
    {
        Destroy(this.gameObject);
    }

    //Readme:
    //褐，黄接触player消失的功能完成（可以通过改变物块BlockControl脚本来设置褐色物块延迟销毁场景）
    //黄物块加分功能完成（分数Score存储在主角脚本CharcterControler，接下来和UI挂接即可）
    //未完成：
    //蓝色物块功能未完成，计划在主角脚本完成
    //紫色物块伤害功能未完成，计划通过主角脚本吸取紫色物块时候改变PurpleCanKill来控制是否有伤害

}
