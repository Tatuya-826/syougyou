using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitScript : MonoBehaviour
{
    //�Ă��̓����蔻�菈��

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "PlayerAttack")
        {
            Debug.Log("EnemyHit");
        }

    }
}
