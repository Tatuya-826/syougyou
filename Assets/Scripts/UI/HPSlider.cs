using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{

    //�������v���C���[�̂��̂ɕς���

    int maxHp = 1000;
    int currentHp;

    //slider������
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
            //�_���[�W
            int damage = Random.Range(1, 100);
            Debug.Log("damage : " + damage);

            //�_���[�W�@����
            currentHp = currentHp - damage;
            Debug.Log("After currentHp : " + currentHp);

            //�ő�HP��slider�ɔ��f
            //(float)��t����float�̕ϐ��Ƃ��Ă�����
            slider.value = (float)currentHp / (float)maxHp;
            Debug.Log("slider.value : " + slider.value);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
