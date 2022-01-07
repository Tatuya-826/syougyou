using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EnemyCSVReader : MonoBehaviour
{
    TextAsset EnemycsvFile; // CSVファイル
    List<string[]> EnemyCSVDatas = new List<string[]>(); // CSVの中身を入れるリスト;

    // Start is called before the first frame update
    void Start()
    {
        EnemycsvFile = Resources.Load("CSV/EnemyCSVtest") as TextAsset; // Resouces下のCSV読み込み
        StringReader reader = new StringReader(EnemycsvFile.text);

        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            EnemyCSVDatas.Add(line.Split(',')); // , 区切りでリストに追加
        }
    }

    public int maxhpGetter(int index)
    {
        return int.Parse(EnemyCSVDatas[index][2]);
    }

    public int atkGetter(int index)
    {
        return int.Parse(EnemyCSVDatas[index][3]);
    }

    public int dropGetter(int index)
    {
        return 1; //int.Parse(EnemyCSVDatas[index][4]);
    }
}
