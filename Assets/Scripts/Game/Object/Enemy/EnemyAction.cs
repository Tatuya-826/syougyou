using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class EnemyAction : MonoBehaviourPunCallbacks//, IPunObservable
{
    [SerializeField] GameObject AttackHaniObject;
    public GameObject Effect;
    public int AttackType;
    public const float AttackDelay = 100.0f;
    public float DelayTime;

    PlayerGoScript moveScript;          //移動スクリプト
    public bool attackFrag = false;
    public bool Tuibi = false;

    public GameObject bulletObject;
    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        moveScript = this.gameObject.GetComponent<PlayerGoScript>();
        DelayTime = 0f;
        AttackHaniObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (attackFrag)
        {
            case false:
                if (Tuibi)
                {
                    AttackHaniObject.SetActive(true);
                    moveScript.PlayerTuibi();
                }
                break;
            case true:
                
                if (DelayTime <= 0)
                {
                    AttackHaniObject.SetActive(true);
                    //photonView.RPC(nameof(Attack), RpcTarget.All, );
                    Attack();
                }
                break;
        }
        if (DelayTime > 0)
            DelayTime -= 0.1f;
    }

    //[PunRPC]
    void Attack()
    {
        
        switch (AttackType)
        {
            case 0:
                //Instantiate(Effect, this.transform.position, Quaternion.identity);
                break;
            case 1:
                var Bullet = Instantiate(bulletObject, this.transform.position, this.transform.rotation);
                break;
        }

        DelayTime = AttackDelay;
        AttackHaniObject.SetActive(false);
        attackFrag = false;
    }
}
