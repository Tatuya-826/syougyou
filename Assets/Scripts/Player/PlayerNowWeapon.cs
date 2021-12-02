using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNowWeapon : MonoBehaviour
{
    public readonly static PlayerNowWeapon PlayerEquipment = new PlayerNowWeapon();

    public int WeaponID=0;
    public string WeaponName = "null–_";
    public int WeaponAtk=37564;
    public int ArmorID = 0;
    public string ArmorName = "null•ž";
    public int ArmorDef=906;
}
