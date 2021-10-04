using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{

    const int MAXHP = 10;
    int HP;
    const int BasicAtk = 1;
    const int BasicDef = 1;
    // Start is called before the first frame update
    void Start()
    {
        HP = MAXHP;
    }

    public void sethp(int HP)
    {
        this.HP = HP;
    }

    public int gethp()
    {
        return HP;
    }

    public int getmaxhp()
    {
        return MAXHP;
    }

    public int getAtk()
    {
        return BasicAtk;
    }

    public int getDef()
    {
        return BasicDef;
    }
}
