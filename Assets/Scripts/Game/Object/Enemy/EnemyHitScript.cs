using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitScript : MonoBehaviour
{
    
    public const int MAXHP = 10;
    public int HP;
    //てきの当たり判定処理
    void Start()
    {
        HP = MAXHP;
    }

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "PlayerAttack")
        {
            Debug.Log("EnemyHit");
        }

    }
}
