using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitScript : MonoBehaviour
{
    //ƒvƒŒƒCƒ„[‚Ì“–‚½‚è”»’èˆ—

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "EnemyAttack" )
        {
            Debug.Log("PlayerHit");
        }

    }
}
