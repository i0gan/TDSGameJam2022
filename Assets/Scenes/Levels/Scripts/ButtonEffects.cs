using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class ButtonEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(() => {
            AudioManager.GetInstance.PlayAudio(AudioManager.AudioType.Clicked);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.GetInstance.PlayAudio(AudioManager.AudioType.Hover);
        //transform.GetComponent<RectTransform>.scale = Vector3(0, )
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {

    }
}
