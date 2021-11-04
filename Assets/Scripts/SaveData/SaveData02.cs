using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;
using System;

public class SaveData02 : MonoBehaviour
{
    public Button01 Button;
    Button01 button_text01;

    SaveData saveData = new SaveData();

    [SerializeField] InputField inputArea;

    [System.Serializable]
    public class SaveData
    {
        public string player_Name;
        public int player_level;
        public string player_Body;
        public string player_Hand;
        public string player_Head;
    }

    public void Save(SaveData saveData)
    {
        StreamWriter writer;
        var player_Name = inputArea.text;
        saveData.player_Name = player_Name;


        string jsonstr = JsonUtility.ToJson(saveData);

        writer = new StreamWriter(Application.dataPath + "/savedata.json" + Button.getter() + ".json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }

    public SaveData Load()
    {
        string datastr = "";

        StreamReader reader;

        reader = new StreamReader(Application.dataPath + "/savedata.json" + Button.getter() + ".json");
        datastr = reader.ReadToEnd();
    reahttps://outlook.office.com/people/der.Close();

        return JsonUtility.FromJson<SaveData>(datastr);
        return saveData;
    }

    public void PushSaveButton()//èââÒ
    {
        SaveData saveData = new SaveData();
        saveData.player_Name = "";
        saveData.player_level = 1;
        Save(saveData);
    }

    public void PushSaveOverwriteButton()//è„èëÇ´
    {
        //SaveData saveData = new SaveData();
        saveData.player_level = 100;
        Save(saveData);
    }

    public void PushLoadButton()
    {
        SaveData saveData = Load();
        Debug.Log(saveData.player_Name);
        Debug.Log(saveData.player_level);
        Debug.Log(saveData.player_Body);
        Debug.Log(saveData.player_Hand);
        Debug.Log(saveData.player_Head);
    }

}
