using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonItemBox : MonoBehaviour,IPointerClickHandler
{

    public void OnButtonPressed()
    {
        Debug.Log("UI�̃{�^���������ꂽ��!");
    }

    public void OnPointerClick(PointerEventData pointerData)
    {
        Debug.Log(gameObject.name + " ���N���b�N���ꂽ!");
    }
}