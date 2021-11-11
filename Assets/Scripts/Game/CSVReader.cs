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

    void Start()
    {
        //����
        WeaponcsvFile = Resources.Load("CSV/WeaponCSVtest") as TextAsset; // Resouces����CSV�ǂݍ���
        StringReader reader = new StringReader(WeaponcsvFile.text);

        // , �ŕ�������s���ǂݍ���
        // ���X�g�ɒǉ����Ă���
        while (reader.Peek() != -1) // reader.Peaek��-1�ɂȂ�܂�
        {
            string line = reader.ReadLine(); // ��s���ǂݍ���
            WeaponCSVDatas.Add(line.Split(',')); // , ��؂�Ń��X�g�ɒǉ�
        }

        //�h��
        ArmorcsvFile = Resources.Load("CSV/ArmorCSVtest") as TextAsset; // Resouces����CSV�ǂݍ���
        reader = new StringReader(ArmorcsvFile.text);

        // , �ŕ�������s���ǂݍ���
        // ���X�g�ɒǉ����Ă���
        while (reader.Peek() != -1) // reader.Peaek��-1�ɂȂ�܂�
        {
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
