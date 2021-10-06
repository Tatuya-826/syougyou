using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePatarn : MonoBehaviour
{
    [SerializeField] GameObject AttackHaniObject;
    public GameObject Effect;
    public int AttackType;
    public const float AttackDelay = 1.0f;
    public float DelayTime;

    PlayerGoScript moveScript;          //移動スクリプト
    public bool attackFrag = false;
    public bool Tuibi = false;
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

        switch (attackFrag) {
            case false:
                if (Tuibi)
                {
                    AttackHaniObject.SetActive(true);
                    moveScript.PlayerTuibi();
                }
                break;
            case true:
                if (DelayTime < 0)
                {
                    AttackHaniObject.SetActive(true);
                    Attack();
                }
                break;
        }
        if (DelayTime > 0)
            DelayTime -= 0.1f;
    }

    void Attack()
    {
        
        Instantiate(Effect, this.transform.position, Quaternion.identity);
        DelayTime = AttackDelay;
        AttackHaniObject.SetActive(false);
    }
}
