using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class dropCSVRead : MonoBehaviour
{
    TextAsset DropcsvFile; // CSVファイル
    List<string[]> DropCSVDatas = new List<string[]>(); // CSVの中身を入れるリスト;

    // Start is called before the first frame update
    void Start()
    {
        DropcsvFile = Resources.Load("CSV/dropWeapon") as TextAsset; // Resouces下のCSV読み込み
        StringReader reader = new StringReader(DropcsvFile.text);

        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            DropCSVDatas.Add(line.Split(',')); // , 区切りでリストに追加
        }
    }

    public string typeGetter(int index)
    {
        return DropCSVDatas[index][1];
    }

    public string nameGetter(int index)
    {
        return DropCSVDatas[index][2];
    }

    public int atkGetter(int index)
    {
        int atk = Random.Range(int.Parse(DropCSVDatas[index][3]), int.Parse(DropCSVDatas[index][4]));
        return atk;
    }

    public string wtypeGetter(int index)
    {
        return DropCSVDatas[index][5];
    }

    public string progGetter(int index)
    {
        return DropCSVDatas[index][6];
    }
}
