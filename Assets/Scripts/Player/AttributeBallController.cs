using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeBallController : MonoBehaviour{
    public GameObject target = null;
    public float speed = 40;
    public string ability = null;


    void Update(){
        if(target == null) return;

        //¾àÀë×ã¹»½Ó½üÊ±
        if (Vector3.Distance(transform.position, target.transform.position)<0.1){
            GameObject.Find("player").GetComponent<Animator>().SetInteger("state",0);
            if (target.tag == "Player")
            {
                target.GetComponent<RayGunController>().ownedAbility = ability;
                AudioManager.GetInstance.PlayAudio(AudioManager.AudioType.Magic);
            }
            else
            {
                target.tag = ability;
                AudioManager.GetInstance.PlayAudio(AudioManager.AudioType.BlockChange);
            }
            Destroy(transform.gameObject);
        }
            
        Vector3 direction = target.transform.position - transform.position;
        direction.Normalize();
        transform.position = transform.position + direction * speed * Time.deltaTime;
    }

    
}
