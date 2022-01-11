using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReader : MonoBehaviour
{
    TextAsset WeaponcsvFile; // CSV�t�@�C��
    TextAsset ArmorcsvFile; // CSV�t�@�C��
    List<string[]> WeaponCSVDatas = new List<string[]>(); // CSV�̒��g�����郊�X�g;
    List<string[]> ArmorCSVDatas = new List<string[]>(); // CSV�̒��g�����郊�X�g;

    private StreamWriter sw;

    int bukisu;
    int bougusu;

    int ItemLimit = 100;

    void Start()
    {
        //����
        WeaponcsvFile = Resources.Load("CSV/WeaponCSVtest") as TextAsset; // Resouces����CSV�ǂݍ���
        StringReader reader = new StringReader(WeaponcsvFile.text);

        bukisu = 0;

        // , �ŕ�������s���ǂݍ���
        // ���X�g�ɒǉ����Ă���
        while (reader.Peek() != -1) // reader.Peaek��-1�ɂȂ�܂�
        {
            bukisu++;
            string line = reader.ReadLine(); // ��s���ǂݍ���
            WeaponCSVDatas.Add(line.Split(',')); // , ��؂�Ń��X�g�ɒǉ�
        }

        //�h��
        ArmorcsvFile = Resources.Load("CSV/ArmorCSVtest") as TextAsset; // Resouces����CSV�ǂݍ���
        reader = new StringReader(ArmorcsvFile.text);

        bougusu = 0;

        // , �ŕ�������s���ǂݍ���
        // ���X�g�ɒǉ����Ă���
        while (reader.Peek() != -1) // reader.Peaek��-1�ɂȂ�܂�
        {
            bougusu++;
            string line = reader.ReadLine(); // ��s���ǂݍ���
            ArmorCSVDatas.Add(line.Split(',')); // , ��؂�Ń��X�g�ɒǉ�
        }

        // csvDatas[�s][��]���w�肵�Ēl�����R�Ɏ��o����
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
            WeaponCSVDatas.Add(Item);//���X�g�ɒǉ�
            bukisu++;
        }
        else
        {
            string[] Item = { bougusu.ToString(), na, wt, pr, at.ToString() };
            ArmorCSVDatas.Add(Item);//���X�g�ɒǉ�
            bougusu++;
        }

        for (int i = 0; i < ItemLimit; i++)
        {
            if (WeaponCSVDatas[i][0] == null)//null��T����
            {
                return;
            }
        }
    }
}
