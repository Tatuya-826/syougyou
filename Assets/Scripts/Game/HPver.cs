using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPver : MonoBehaviour
{
    Slider hpSlider;

    // Use this for initialization
    void Start()
    {

        hpSlider = GetComponent<Slider>();

        float maxHp = PlayerStatus.Status.getmaxhp();
        float nowHp = PlayerStatus.Status.gethp(); ;


        //�X���C�_�[�̍ő�l�̐ݒ�
        hpSlider.maxValue = maxHp;

        //�X���C�_�[�̌��ݒl�̐ݒ�
        hpSlider.value = nowHp;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
