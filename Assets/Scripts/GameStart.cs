using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 加载游戏菜单
        Invoke("LoadGameMenuScene", 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadGameMenuScene()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex * 2);
        AsyncOperation op = SceneManager.LoadSceneAsync("Scenes/GameMenu");
        op.allowSceneActivation = true;
    }
}
