using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeBallController : MonoBehaviour{
    public GameObject target = null;
    public float speed = 25;
    void Start(){

    }

    void Update(){
        if(target == null) return;

        //¾àÀë×ã¹»½Ó½üÊ±´Ý»Ù
        if (Vector3.Distance(transform.position, target.transform.position)<0.1) 
            Destroy(transform.gameObject);

        Vector3 direction = target.transform.position - transform.position;
        direction.Normalize();
        transform.position = transform.position + direction * speed * Time.deltaTime;
    }

    
}
