using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{

    //ここをプレイヤーのものに変える

    int maxHp = 1000;
    int currentHp;

    //sliderを入れる
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        //slider
        slider.value = 1;

        currentHp = maxHp;
        Debug.Log("Stert currentHp : " + currentHp);
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            //ダメージ
            int damage = Random.Range(1, 100);
            Debug.Log("damage : " + damage);

            //ダメージ　引く
            currentHp = currentHp - damage;
            Debug.Log("After currentHp : " + currentHp);

            //最大HPをsliderに反映
            //(float)を付けてfloatの変数としてあつかう
            slider.value = (float)currentHp / (float)maxHp;
            Debug.Log("slider.value : " + slider.value);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
