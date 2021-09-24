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
        var Bullet = Instantiate(bulletObject,this.transform.position, this.transform.rotation);

        attackFrag = false;
    }
}
