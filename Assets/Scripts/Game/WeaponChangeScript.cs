using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChangeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int ButtonNo;
    public GameObject ButtonPrefab;
    void Start()
    {
        // Grid Layout Group �R���|�[�l���g������GameObject
        GameObject list = GameObject.Find("WeaponList");
        for (int i = 0; i < ButtonNo; i++)
        {
            //�v���n�u����{�^���𐶐�
            GameObject listButton = Instantiate(ButtonPrefab) as GameObject;
            //Vertical Layout Group �̎q�ɂ���
            listButton.transform.parent = list.transform;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
