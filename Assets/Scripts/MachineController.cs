using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineController : MonoBehaviour
{
    public Vector3 moveDirection;
    public float moveSpeed;
    public float moveTime;

    bool haveTrigger;
    bool isWork;
    GameObject block;
    void Start(){
        haveTrigger = false;
        isWork = false;
        block = transform.GetChild(0).gameObject;

    }

    // Update is called once per frame
    void Update(){
        if (isWork){
            block.transform.position = block.transform.position + moveDirection*moveSpeed*Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (haveTrigger) return;
        haveTrigger = true;
        isWork = true;
        Invoke("stopWork", moveTime);
    }
    void stopWork()
    {
        isWork = false;
        GetComponent<MachineController>().enabled = false;
    }
}
