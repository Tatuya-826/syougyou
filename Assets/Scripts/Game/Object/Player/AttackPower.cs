using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPower : MonoBehaviour
{
    public int AtkPower;
    GameObject oyaObject;
    PlayerStatus playerStatus;
    // Start is called before the first frame update
    void Start()
    {
        oyaObject = transform.parent.gameObject;
        playerStatus = oyaObject.GetComponent<PlayerStatus>();
        AttackPowerKeisan();
    }

    void AttackPowerKeisan()
    {
        AtkPower = playerStatus.getAtk();
        //Debug.Log(AtkPower);
    }
}
