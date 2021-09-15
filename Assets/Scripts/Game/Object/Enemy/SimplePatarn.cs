using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePatarn : MonoBehaviour
{
    public GameObject Effect;
    public int AttackType;

    PlayerGoScript moveScript;          //移動スクリプト
    public bool attackFrag = false;
    public bool Tuibi = false;
    public GameObject bulletObject;
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        moveScript = this.gameObject.GetComponent<PlayerGoScript>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (attackFrag) {
            case false:
                if(Tuibi)
                    moveScript.PlayerTuibi();
                break;
            case true:
                Attack();
                break;
        }
    }

    void Attack()
    {
        Instantiate(Effect, new Vector3(1.0f, 0.0f, 0.0f), Quaternion.identity);
        GameObject Bullet = Instantiate(bulletObject) as GameObject;
        Bullet.transform.position = this.transform.position;

        //発射ベクトル
        Vector3 force;
        //発射の向きと速度を決定
        force = this.transform.forward * bulletSpeed;
        // Rigidbodyに力を加えて発射
        Bullet.GetComponent<Rigidbody>().AddForce(force);

        attackFrag = false;
    }
}
