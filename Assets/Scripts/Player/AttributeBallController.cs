using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeBallController : MonoBehaviour{
    public GameObject target = null;
    public float speed = 200;
    public string ability = null;


    void Update(){
        if(target == null) return;

        //¾àÀë×ã¹»½Ó½üÊ±
        if (Vector3.Distance(transform.position, target.transform.position)<0.1){
            if (target.tag == "Player") 
                target.GetComponent<RayGunController>().ownedAbility = ability;
            else target.tag = ability;
            Destroy(transform.gameObject);
        }
            
        Vector3 direction = target.transform.position - transform.position;
        direction.Normalize();
        transform.position = transform.position + direction * speed * Time.deltaTime;
    }

    
}
