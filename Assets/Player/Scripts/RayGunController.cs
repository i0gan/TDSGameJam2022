using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGunController : MonoBehaviour{
    LineRenderer lineRenderer;
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

    //绘制射线
    void DrawRay()
    {
        //获取鼠标位置
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;

        //创建射线并获取打到的物体
        Ray2D ray = new Ray2D(transform.position, mousePos - transform.position);
        RaycastHit2D info = Physics2D.Raycast(ray.origin, ray.direction, 100, 1 << 7, -10);
        if (info.collider != null){
            GameObject obj = info.collider.gameObject;
            //Debug.Log(obj.name);
        }


        //绘制射线(绘制在最下层,所以z轴坐标加1)
        lineRenderer.SetPosition(0, transform.position + new Vector3(0,0,1));
        lineRenderer.SetPosition(1, mousePos + new Vector3(0, 0, 1));

        if (Input.GetMouseButtonDown(0)){
            Debug.Log(mousePos);
        }
    }

}
