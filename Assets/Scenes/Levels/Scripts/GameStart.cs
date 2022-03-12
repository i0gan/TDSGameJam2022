using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameStart : MonoBehaviour
{
    public Slider processSlider;
    // Start is called before the first frame update
    void Start()
    {
        // 加载游戏菜单
        //Invoke("LoadGameMenuScene", 3.0f);
        StartCoroutine("ShowLoading");

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

    IEnumerator ShowLoading()
    {
        int times = 30; //时长3s
        for (int i = 0; i < times; i++)
        {
            processSlider.value = (i / 30.0f); //设置进度条
            yield return new WaitForSeconds(0.1f);
        }
        LoadGameMenuScene(); // 加载主场景
    }
}
