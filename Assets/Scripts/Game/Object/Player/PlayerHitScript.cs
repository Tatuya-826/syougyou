using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHitScript : MonoBehaviour
{
    public int HP ;
    GameObject oyaObject;
    //PlayerStatus playerStatus;
    //プレイヤーの当たり判定処理
    void Start()
    {
        oyaObject = transform.parent.gameObject;
        //playerStatus = oyaObject.GetComponent<PlayerStatus>();
    }

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "EnemyAttack" )
        {
            

            HP = PlayerStatus.Status.gethp();
            Debug.Log("HP="+HP);
            HP -= col.GetComponent<Damage>().hitDamage;
            PlayerStatus.Status.sethp(HP);

            Debug.Log("HP="+HP);
            if (HP <= 0)        //HPが0になった処理
            {
                oyaObject.SetActive(false); ;
                SceneManager.LoadScene("robi-");
            }
        }

    }
}
