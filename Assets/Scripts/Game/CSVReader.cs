using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReader : MonoBehaviour
{
    TextAsset WeaponcsvFile; // CSVファイル
    TextAsset ArmorcsvFile; // CSVファイル
    List<string[]> WeaponCSVDatas = new List<string[]>(); // CSVの中身を入れるリスト;
    List<string[]> ArmorCSVDatas = new List<string[]>(); // CSVの中身を入れるリスト;

    void Start()
    {
        //武器
        WeaponcsvFile = Resources.Load("CSV/WeaponCSVtest") as TextAsset; // Resouces下のCSV読み込み
        StringReader reader = new StringReader(WeaponcsvFile.text);

        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            WeaponCSVDatas.Add(line.Split(',')); // , 区切りでリストに追加
        }

        //防具
        ArmorcsvFile = Resources.Load("CSV/ArmorCSVtest") as TextAsset; // Resouces下のCSV読み込み
        reader = new StringReader(ArmorcsvFile.text);

        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            ArmorCSVDatas.Add(line.Split(',')); // , 区切りでリストに追加
        }
        // csvDatas[行][列]を指定して値を自由に取り出せる
        //Debug.Log(WeaponCSVDatas[1][0]);

    }

    public string WeaponNameGetter(int index)
    {
        index++;
        return WeaponCSVDatas[index][1];
    }

    public string WeaponTypeGetter(int index)
    {
        index++;
        return WeaponCSVDatas[index][3];
    }

    public string WeaponPropGetter(int index)
    {
        index++;
        return WeaponCSVDatas[index][4];
    }

    public string WeaponPowGetter(int index)
    {
        index++;
        return WeaponCSVDatas[index][5];
    }


    public string ArmorNameGetter(int index)
    {
        index++;
        return ArmorCSVDatas[index][1];
    }

    public string ArmorTypeGetter(int index)
    {
        index++;
        return ArmorCSVDatas[index][3];
    }

    public string ArmorPropGetter(int index)
    {
        index++;
        return ArmorCSVDatas[index][4];
    }

    public string ArmorDefGetter(int index)
    {
        index++;
        return ArmorCSVDatas[index][6];
    }
}
