using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject machine;
    bool isTrigger;
    bool isMachineWork;

    public Vector3 moveDirection;
    public float moveSpeed;
    public float moveTime;
    void Start(){
        isTrigger = false;
        isMachineWork = false;
    }
    void Update(){
        if (isMachineWork)
        {
            machine.transform.position = machine.transform.position + moveDirection * moveSpeed *Time.deltaTime;
        }
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision){
        if (isTrigger) return;
        isTrigger = true;
        isMachineWork = true;
        Invoke("stopMachine",moveTime);
    }
    private void stopMachine()
    {
        isMachineWork = false;
    }

}
