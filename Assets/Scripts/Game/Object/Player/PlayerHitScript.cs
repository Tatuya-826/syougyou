using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitScript : MonoBehaviour
{
    //�v���C���[�̓����蔻�菈��

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "EnemyAttack" )
        {
            Debug.Log("PlayerHit");
        }

    }
}
