using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject t;
    void Start()
    {
        Invoke("GamePass", 3.0f);
    }
    void GamePass()
    {
        t.GetComponent<LevelUI>().ShowGamePass(1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
