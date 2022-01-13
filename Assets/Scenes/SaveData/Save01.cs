using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

public class Save01 : MonoBehaviour
{
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

    SaveData saveData = new SaveData();

    public void Save(SaveData saveData)
    {
        StreamWriter writer;
        var player_Name = inputArea.text;
        saveData.player_Name = player_Name;


        string jsonstr = JsonUtility.ToJson(saveData);

        writer = new StreamWriter(Application.dataPath + "/savedata.json" + player_Name + ".json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }

    public SaveData Load()
    {
        //if (File.Exists(Application.dataPath + "/savedata.json"))

        string datastr = "";
        var player_Name = inputArea.text;

        StreamReader reader;

        reader = new StreamReader(Application.dataPath + "/savedata.json" + player_Name + ".json");
        datastr = reader.ReadToEnd();
        reader.Close();

        return JsonUtility.FromJson<SaveData>(datastr);
        //SaveData saveData = new SaveData();

        //saveData.player_Name = "";
        //saveData.player_level = 10;
        return saveData;
    }

    public void PushSaveButton()
    {
        SaveData saveData = new SaveData();
        saveData.player_Name = "";
        saveData.player_level = 2;
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
