using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGunController : MonoBehaviour{
    private LineRenderer lineRenderer;
    public GameObject targetObj;
    void Start(){
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
        
        //����Ŀ��λ��
        Vector3 targetPos;

        //�������߲���ȡ�򵽵�����
        Ray2D ray = new Ray2D(transform.position, mousePos - transform.position);
        RaycastHit2D info = Physics2D.Raycast(ray.origin, ray.direction, 100, 1 << 7, -10);
        if (info.collider != null){
            GameObject obj = info.collider.gameObject;
            targetPos = new Vector3(info.point.x, info.point.y, transform.position.z);
            //���ƿ��
            targetObj.transform.position = obj.transform.position;
        }
        else targetPos = mousePos;


        //��������(���������²�,����z�������1)
        lineRenderer.SetPosition(0, transform.position + new Vector3(0,0,1));
        lineRenderer.SetPosition(1, targetPos + new Vector3(0, 0, 1));

        if (Input.GetMouseButtonDown(0)){
            Debug.Log(mousePos);
        }
    }


}
