using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MPver : MonoBehaviour
{
    Slider mpSlider;

    // Use this for initialization
    void Start()
    {

        mpSlider = GetComponent<Slider>();

        float maxMp = PlayerStatus.Status.getmaxmp();
        float nowMp = PlayerStatus.Status.getmp();


        //スライダーの最大値の設定
        mpSlider.maxValue = maxMp;

        //スライダーの現在値の設定
        mpSlider.value = nowMp;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
