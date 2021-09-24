using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitScript : MonoBehaviour
{
    //てきの当たり判定処理

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "PlayerAttack")
        {
            Debug.Log("EnemyHit");
        }

    }
}
