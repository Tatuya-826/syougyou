using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitScript : MonoBehaviour
{
    public const int MAXHP = 10000000;
    public int HP ;
    GameObject oyaObject;
    //プレイヤーの当たり判定処理
    void Start()
    {
        HP = MAXHP;
        oyaObject = transform.parent.gameObject;
    }

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "EnemyAttack" )
        {

            HP--;
            Debug.Log(HP);
            if (HP <= 0)
                Destroy(oyaObject);

        }

    }
}
