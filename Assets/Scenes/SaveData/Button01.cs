using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Text;

public class Button01 : MonoBehaviour
{
    public int suuzi;

    [SerializeField] private Text button_text;

    public int getter()
    {
        return suuzi;
    }

    public void Push_Button(int number)
    {
        suuzi = number;
    }
}
