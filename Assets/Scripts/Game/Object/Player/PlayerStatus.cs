using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    int MAXHP = 10;
    int HP;
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

}
