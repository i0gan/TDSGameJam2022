using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGunController : MonoBehaviour{
    private LineRenderer lineRenderer;
    private GameObject targetObj;
    public GameController gameController;
    public string ownedAbility = null;

    void Start(){
        ownedAbility = null;
        gameController = GetComponent<GameController>();
        targetObj = (GameObject)Instantiate(Resources.Load("Player/Prefabs/target"), new Vector3(-99,0,-1), transform.rotation);
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.08f;
        lineRenderer.endWidth = 0.08f;
        lineRenderer.positionCount = 2;
    }

    // Update is called once per frame
    void Update(){
        DrawRay();
    }

    //绘制射线
    void DrawRay(){
        //获取鼠标位置
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        
        //射线检测到的位置和检测到的物体
        Vector3 hitPos;
        GameObject hitObj = null;

        //创建射线并获取打到的物体
        Ray2D ray = new Ray2D(transform.position, mousePos - transform.position);
        RaycastHit2D info = Physics2D.Raycast(ray.origin, ray.direction, 100, 1 << 7, -10);



        if (info.collider != null){
            hitObj = info.collider.gameObject;
            hitPos = new Vector3(info.point.x, info.point.y, transform.position.z);

            //绘制射线(绘制在最下层,所以z轴坐标加1)
            lineRenderer.SetPosition(0, transform.position + new Vector3(0, 0, 1));
            lineRenderer.SetPosition(1, hitPos + new Vector3(0, 0, 1));

            if (hitObj.tag != "Tile"){
                //绘制框选效果
                targetObj.transform.position = hitObj.transform.position;

                //吸收物体的属性
                if (Input.GetMouseButtonDown(1)) absorbAbility(hitObj);

                //赋予物体属性
                if (Input.GetMouseButtonDown(0)) giveAbility(hitObj);
            }

        }
        else hitPos = mousePos;

    }

    void absorbAbility(GameObject obj){
        if(obj.tag == null) return;

        //实例化一个属性球
        if(obj.tag == "Purple"){
            obj.GetComponent<BolckControl>().PurpleCanKill = false;
        }
        GameObject attributeBall = (GameObject)Instantiate(Resources.Load("Player/Prefabs/attributeBall"), obj.transform.position, transform.rotation);
        attributeBall.GetComponent<AttributeBallController>().target = transform.gameObject;
        attributeBall.GetComponent<AttributeBallController>().ability = obj.tag;
        attributeBall.GetComponent<SpriteRenderer>().sprite = obj.GetComponent<SpriteRenderer>().sprite;
        Debug.Log("absorb " + obj.name + " " + obj.tag);
        gameController.addScore(10);
    }

    void giveAbility(GameObject obj){
        if (ownedAbility == null) return;
        //如果是蓝色则赋予巨大的速度
        if (ownedAbility == "Blue"){
            if (obj.tag != "Blue") return;
            Rigidbody2D rb = transform.gameObject.GetComponent<Rigidbody2D>();
            CharacterController character = transform.gameObject.GetComponent<CharacterController>();

            Vector3 direction = transform.position - obj.transform.position;
            direction.Normalize();
            rb.velocity = direction * character.BlueSpeed;
            return;
        }
        //实例化一个属性球
        GameObject attributeBall = (GameObject)Instantiate(Resources.Load("Player/Prefabs/attributeBall"), transform.position, transform.rotation);
        attributeBall.GetComponent<AttributeBallController>().target = obj;
        attributeBall.GetComponent<AttributeBallController>().ability = ownedAbility;
        Debug.Log("give " + obj.name + " " + ownedAbility);
    }

}
