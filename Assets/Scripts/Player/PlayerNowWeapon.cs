using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNowWeapon : MonoBehaviour
{
    public readonly static PlayerNowWeapon PlayerEquipment = new PlayerNowWeapon();

    public int WeaponID=0;
    public string WeaponName = "��̌�";
    public int WeaponAtk=459;
    public string WeaponType = "��";
    public string WeaponProg = "��";

    public int ArmorID = 0;
    public string ArmorName = "�|�̊Z";
    public int ArmorDef=1059;
    public string ArmorType="�Z";
    public string ArmorProg = "��";
}
