using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitScript : MonoBehaviour
{
    public int HP ;
    GameObject oyaObject;
    PlayerStatus playerStatus;
    //ƒvƒŒƒCƒ„[‚Ì“–‚½‚è”»’èˆ—
    void Start()
    {
        oyaObject = transform.parent.gameObject;
        playerStatus = oyaObject.GetComponent<PlayerStatus>();
    }

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "EnemyAttack" )
        {
            HP=playerStatus.gethp();
            HP-= col.GetComponent<Damage>().hitDamage;
            playerStatus.sethp(HP);

            Debug.Log(HP);
            if (HP <= 0)
                oyaObject.SetActive(false); ;

        }

    }
}
