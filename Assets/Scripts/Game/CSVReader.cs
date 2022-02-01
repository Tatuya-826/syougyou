using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class CSVReader : MonoBehaviour
{
    TextAsset WeaponcsvFile; // CSVファイル
    TextAsset ArmorcsvFile; // CSVファイル
    List<string[]> WeaponCSVDatas = new List<string[]>(); // CSVの中身を入れるリスト;
    List<string[]> ArmorCSVDatas = new List<string[]>(); // CSVの中身を入れるリスト;

    private StreamWriter swWeapon;
    private StreamWriter swArmor;

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
            string line = reader.ReadLine(); // 一行ずつ読み込み
            WeaponCSVDatas.Add(line.Split(',')); // , 区切りでリストに追加
        }

        bukisu = WeaponCSVDatas.Count;

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
        bougusu = ArmorCSVDatas.Count;

        // csvDatas[行][列]を指定して値を自由に取り出せる
        //Debug.Log(WeaponCSVDatas[1][0]);
        //SaveItem("A", "よろいん", 1111, "よろいｓ", "よろいぞく");
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
       // Debug.Log("buki" + bukisu);
        print("せーーーーーーーーーーーーぶ");
        if (ty == "W")
        {
            string[] Item = { bukisu.ToString(), na, wt, pr, at.ToString() };
            WeaponCSVDatas.Add(Item);//リストに追加
            bukisu++;
            print("せーーーーーーーーーーーーぶ2");
            //print(bukisu);
            //Debug.Log(WeaponCSVDatas[bukisu-1][1]+ WeaponCSVDatas[bukisu - 1][4]);
        }
        else
        {
            string[] Item = { bougusu.ToString(), na, wt, pr, at.ToString() };
            ArmorCSVDatas.Add(Item);//リストに追加
            bougusu++;
            print("せーーーーーーーーーーーーぶ2");
        }
        CSVWrite();
    }

    public void CSVWrite()
    {
        swWeapon = new StreamWriter("Assets/Resources/CSV/WeaponCSVtest.csv", false, Encoding.GetEncoding("UTF-8"));
        //sw = new StreamWriter(Resources.Load("CSV/WeaponCSVtest") as TextAsset, true, Encoding.GetEncoding("Shift_JIS"));
        for (int i = 0; i < bukisu; i++)
        {
            //Debug.Log(i);
            //Debug.Log(WeaponCSVDatas[i][1]);
            string[] s1 = { WeaponCSVDatas[i][0], WeaponCSVDatas[i][1], WeaponCSVDatas[i][2], WeaponCSVDatas[i][3], WeaponCSVDatas[i][4] };
            string s2 = string.Join(",", s1);
            swWeapon.WriteLine(s2);
            print("せーーーーーーーーーーーーぶしています" );
        }
        swWeapon.Close();
        swArmor = new StreamWriter("Assets/Resources/CSV/ArmorCSVtest.csv", false, Encoding.GetEncoding("UTF-8"));
        for (int i = 0; i < bougusu; i++)
        {
            string[] s1 = { ArmorCSVDatas[i][0], ArmorCSVDatas[i][1], ArmorCSVDatas[i][2], ArmorCSVDatas[i][3], ArmorCSVDatas[i][4] };
            string s2 = string.Join(",", s1);
            swArmor.WriteLine(s2);
            print("せーーーーーーーーーーーーぶしています");
        }
        swArmor.Close();

    }

    public void WeaponCSVTrash(int index)
    {
        WeaponCSVDatas.RemoveAt(index);
        return;
    }

    public void ArmorCSVTrash(int index)
    {
        ArmorCSVDatas.RemoveAt(index);
        return;
    }
}
