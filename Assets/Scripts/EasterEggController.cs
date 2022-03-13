using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject hideWall;
    void Start(){
        hideWall = GameObject.Find("Grid/hideWall").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Find("player").GetComponent<GameController>().setSubtitle("¹§Ï²Äã·¢ÏÖ²Êµ°");
            hideWall.SetActive(false);
            Invoke("Delete", 3);
        }
    }
    void Delete(){
        GameObject.Find("player").GetComponent<GameController>().setSubtitle(" ");
        Destroy(this);
    }
}
