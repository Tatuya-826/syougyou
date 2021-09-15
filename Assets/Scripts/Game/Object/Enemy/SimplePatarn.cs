using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePatarn : MonoBehaviour
{
    public GameObject Effect;
    public int AttackType;

    PlayerGoScript moveScript;          //�ړ��X�N���v�g
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

        //���˃x�N�g��
        Vector3 force;
        //���˂̌����Ƒ��x������
        force = this.transform.forward * bulletSpeed;
        // Rigidbody�ɗ͂������Ĕ���
        Bullet.GetComponent<Rigidbody>().AddForce(force);

        attackFrag = false;
    }
}
