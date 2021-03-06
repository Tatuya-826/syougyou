using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitScript : MonoBehaviour
{
    //てきの当たり判定処理
    public int HP;
    GameObject oyaObject;
    EnemyStatus enemyStatus;

    void Start()
    {
        oyaObject = transform.parent.gameObject;
        enemyStatus= oyaObject.GetComponent<EnemyStatus>();
    }

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "PlayerAttack")
        {
            

            HP = enemyStatus.gethp();
            HP-=col.GetComponent<AttackPower > ().AtkPower;
            enemyStatus.sethp(HP);
            Debug.Log(HP);
            if (HP <= 0)
                Destroy(oyaObject);
        }

    }
}
