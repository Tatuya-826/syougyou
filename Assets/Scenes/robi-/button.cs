using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandlerTest : MonoBehaviour, IPointerClickHandler
{

    public void OnButtonPressed()
    {
        Debug.Log("UIのボタンが押されたよ!");
    }

    public void OnPointerClick(PointerEventData pointerData)
    {
        Debug.Log(gameObject.name + " がクリックされた!");
    }
}