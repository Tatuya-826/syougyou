using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;
using System;

public class savedata01 : MonoBehaviour
{
    public Button01 Button;
    Button01 button_text01;

    SaveData saveData = new SaveData();

    [SerializeField] InputField inputArea;

    [System.Serializable]
    public class SaveData
    {
        /*public string player_Name;
        public int player_level;
        public string player_Body;
        public string player_Hand;
        public string player_Head;
        */
        public int WeaponID;
        public string WeaponName;
        public int WeaponAtk;
        public string WeaponType;
        public string WeaponProg;

        public int ArmorID;
        public string ArmorName;
        public int ArmorDef;
        public string ArmorType;
        public string ArmorProg;
    }

    public void Save(SaveData saveData)
    {
        StreamWriter writer;
        //var player_Name = inputArea.text;
        //saveData.player_Name = player_Name;


        string jsonstr = JsonUtility.ToJson(saveData);

        writer = new StreamWriter(Application.dataPath + "/SaveData/savedata.json0" + ".json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }

    public SaveData Load()
    {
        string datastr = "";

        StreamReader reader;

        reader = new StreamReader(Application.dataPath + "/SaveData/savedata.json0"  + ".json");
        datastr = reader.ReadToEnd();
        reahttps://outlook.office.com/people/der.Close();

        return JsonUtility.FromJson<SaveData>(datastr);
        return saveData;
    }

    public void PushSaveButton()//èââÒ
    {
        SaveData saveData = new SaveData();
        //saveData.player_Name = "";
        //saveData.player_level = 1;
        Save(saveData);
    }

    public void PushSaveButton02()//èââÒ
    {
        SaveData saveData = new SaveData();
        /*saveData.player_Name        = "Taku";
        saveData.player_level       = 10;
        saveData.player_Body        = "IronArmor";
        saveData.player_Hand        = "IronSword";
            saveData.player_Head    = "IronHelmet";
                    public int WeaponID;
        public string WeaponName;
        public int WeaponAtk;
        public string WeaponType;
        public string WeaponProg;        public int ArmorID;
        public string ArmorName;
        public int ArmorDef;
        public string ArmorType;
        public string ArmorProg;
        */

        saveData.WeaponID = PlayerNowWeapon.PlayerEquipment.WeaponID;
        saveData.WeaponName = PlayerNowWeapon.PlayerEquipment.WeaponName;
        saveData.WeaponAtk = PlayerNowWeapon.PlayerEquipment.WeaponAtk;
        saveData.WeaponType = PlayerNowWeapon.PlayerEquipment.WeaponType;
        saveData.WeaponProg = PlayerNowWeapon.PlayerEquipment.WeaponProg;

        saveData.ArmorID = PlayerNowWeapon.PlayerEquipment.ArmorID;
        saveData.ArmorName = PlayerNowWeapon.PlayerEquipment.ArmorName;
        saveData.ArmorDef = PlayerNowWeapon.PlayerEquipment.ArmorDef;
        saveData.ArmorType = PlayerNowWeapon.PlayerEquipment.ArmorType;
        saveData.ArmorProg = PlayerNowWeapon.PlayerEquipment.ArmorProg;


        Save(saveData);
    }

    public void PushSaveOverwriteButton()//è„èëÇ´
    {
        //SaveData saveData = new SaveData();
        //saveData.player_level = 100;
        Save(saveData);
    }

    public void PushLoadButton()
    {
        SaveData saveData = Load();
         PlayerNowWeapon.PlayerEquipment.WeaponID = saveData.WeaponID;
       PlayerNowWeapon.PlayerEquipment.WeaponName = saveData.WeaponName;
         PlayerNowWeapon.PlayerEquipment.WeaponAtk = saveData.WeaponAtk;
        PlayerNowWeapon.PlayerEquipment.WeaponType = saveData.WeaponType;
        PlayerNowWeapon.PlayerEquipment.WeaponProg = saveData.WeaponProg;

        PlayerNowWeapon.PlayerEquipment.ArmorID = saveData.ArmorID;
         PlayerNowWeapon.PlayerEquipment.ArmorName = saveData.ArmorName;
        PlayerNowWeapon.PlayerEquipment.ArmorDef = saveData.ArmorDef;
        PlayerNowWeapon.PlayerEquipment.ArmorType= saveData.ArmorType;
        PlayerNowWeapon.PlayerEquipment.ArmorProg  = saveData.ArmorProg;



        Debug.Log(saveData.WeaponID);
        Debug.Log(saveData.WeaponName);
        Debug.Log(saveData.WeaponAtk);
        /*
        Debug.Log(saveData.player_level);
        Debug.Log(saveData.player_Body);
        Debug.Log(saveData.player_Hand);
        Debug.Log(saveData.player_Head);
    */
    }

}