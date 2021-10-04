using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitScript : MonoBehaviour
{
    //てきの当たり判定処理
    public const int MAXHP = 10;
    public int HP;
    GameObject oyaObject;

    void Start()
    {
        HP = MAXHP;
        oyaObject = transform.parent.gameObject;
    }

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "PlayerAttack")
        {
            HP--;
            Debug.Log(HP);
            if (HP <= 0)
                Destroy(oyaObject);
        }

    }
}
