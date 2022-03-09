using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGunController : MonoBehaviour{
    private LineRenderer lineRenderer;
    private GameObject targetObj;
    public string ownedAbility = null;

    void Start(){
        targetObj = (GameObject)Instantiate(Resources.Load("Player/Prefabs/target"), new Vector3(-99,0,0), transform.rotation);
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.08f;
        lineRenderer.endWidth = 0.08f;
        lineRenderer.positionCount = 2;
    }

    // Update is called once per frame
    void Update(){
        DrawRay();
    }

    //��������
    void DrawRay(){
        //��ȡ���λ��
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        
        //���߼�⵽��λ�úͼ�⵽������
        Vector3 hitPos;
        GameObject hitObj = null;

        //�������߲���ȡ�򵽵�����
        Ray2D ray = new Ray2D(transform.position, mousePos - transform.position);
        RaycastHit2D info = Physics2D.Raycast(ray.origin, ray.direction, 100, 1 << 7, -10);

        if (info.collider != null){
            hitObj = info.collider.gameObject;
            hitPos = new Vector3(info.point.x, info.point.y, transform.position.z);
            //���ƿ�ѡЧ��
            targetObj.transform.position = hitObj.transform.position;

            //�������������
            if (Input.GetMouseButtonDown(1)) absorbAbility(hitObj);

            //������������
            if (Input.GetMouseButtonDown(0)) giveAbility(hitObj);
        }
        else hitPos = mousePos;


        //��������(���������²�,����z�������1)
        lineRenderer.SetPosition(0, transform.position + new Vector3(0,0,1));
        lineRenderer.SetPosition(1, hitPos + new Vector3(0, 0, 1));

    }

    void absorbAbility(GameObject obj){
        //ʵ����һ��������
        GameObject attributeBall = (GameObject)Instantiate(Resources.Load("Player/Prefabs/attributeBall"), obj.transform.position, transform.rotation);
        attributeBall.GetComponent<AttributeBallController>().target = transform.gameObject;
        attributeBall.GetComponent<AttributeBallController>().ability = obj.tag;
        attributeBall.GetComponent<SpriteRenderer>().sprite = obj.GetComponent<SpriteRenderer>().sprite;
        Debug.Log("absorb " + obj.name + " " + obj.tag);
    }

    void giveAbility(GameObject obj){
        if (ownedAbility == null) return;
        //ʵ����һ��������
        GameObject attributeBall = (GameObject)Instantiate(Resources.Load("Player/Prefabs/attributeBall"), transform.position, transform.rotation);
        attributeBall.GetComponent<AttributeBallController>().target = obj;
        attributeBall.GetComponent<AttributeBallController>().ability = ownedAbility;
        ownedAbility = null;
        Debug.Log("give " + obj.name + " " + ownedAbility);
    }

}