using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Note : MonoBehaviour
{
    public string note;
    public float notetime=1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject.Find("player").GetComponent<GameController>().setSubtitle(note);
            //Invoke("offnte",notetime);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject.Find("player").GetComponent<GameController>().setSubtitle("");
    }

    //private void offnote()
    //{

    //    GameObject.Find("Player").GetComponent<GameController>().HideSubtitle();
    //}
}
