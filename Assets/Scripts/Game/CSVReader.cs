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

    private StreamWriter sw;

    int bukisu;
    int bougusu;

    int ItemLimit = 100;

    void Start()
    {
        //武器
        WeaponcsvFile = Resources.Load("CSV/WeaponCSVtest") as TextAsset; // Resouces下のCSV読み込み
        StringReader reader = new StringReader(WeaponcsvFile.text);

        bukisu = 0;

        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        {
            bukisu++;
            string line = reader.ReadLine(); // 一行ずつ読み込み
            WeaponCSVDatas.Add(line.Split(',')); // , 区切りでリストに追加
        }

        //防具
        ArmorcsvFile = Resources.Load("CSV/ArmorCSVtest") as TextAsset; // Resouces下のCSV読み込み
        reader = new StringReader(ArmorcsvFile.text);

        bougusu = 0;

        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        {
            bougusu++;
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
        return WeaponCSVDatas[index][2];
    }

    public string WeaponPropGetter(int index)
    {
        index++;
        return WeaponCSVDatas[index][3];
    }

    public string WeaponPowGetter(int index)
    {
        index++;
        return WeaponCSVDatas[index][4];
    }


    public string ArmorNameGetter(int index)
    {
        index++;
        return ArmorCSVDatas[index][1];
    }

    public string ArmorTypeGetter(int index)
    {
        index++;
        return ArmorCSVDatas[index][2];
    }

    public string ArmorPropGetter(int index)
    {
        index++;
        return ArmorCSVDatas[index][3];
    }

    public string ArmorDefGetter(int index)
    {
        index++;
        return ArmorCSVDatas[index][4];
    }

    public void SaveItem(string ty, string na, int at, string wt, string pr)
    {

        if (ty == "W")
        {
            string[] Item = { bukisu.ToString(), na, wt, pr, at.ToString() };
            WeaponCSVDatas.Add(Item);//リストに追加
            bukisu++;
        }
        else
        {
            string[] Item = { bougusu.ToString(), na, wt, pr, at.ToString() };
            ArmorCSVDatas.Add(Item);//リストに追加
            bougusu++;
        }

        for (int i = 0; i < ItemLimit; i++)
        {
            if (WeaponCSVDatas[i][0] == null)//nullを探して
            {
                return;
            }
        }
    }
}
