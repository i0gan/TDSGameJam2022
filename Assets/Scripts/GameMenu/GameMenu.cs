using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.GetInstance.PlayAudio(AudioManager.AudioType.BGM_MainScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Game Start
    public void LoadSelectLevelScene()
    {
        AudioManager.GetInstance.PlayAudio(AudioManager.AudioType.LevelStart);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex * 2);
        AsyncOperation op = SceneManager.LoadSceneAsync("Scenes/Level_1");
        op.allowSceneActivation = true;
    }

}
