using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
///  鼠标选中之后，图片激活
/// </summary>
public class SelectedHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("开始");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetImageOff()
    {
        RawImage t = transform.Find("Image").GetComponent<RawImage>();
        t.enabled = false;
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        //查找子对象，Image
        RawImage t = transform.Find("Image").GetComponent<RawImage>();
        t.enabled = true;
        //throw new System.NotImplementedException();
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        SetImageOff();
        //throw new System.NotImplementedException();
    }
}
