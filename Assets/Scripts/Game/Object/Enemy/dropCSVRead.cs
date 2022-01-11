using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class dropCSVRead : MonoBehaviour
{
    TextAsset DropcsvFile; // CSV�t�@�C��
    List<string[]> DropCSVDatas = new List<string[]>(); // CSV�̒��g�����郊�X�g;

    // Start is called before the first frame update
    void Start()
    {
        DropcsvFile = Resources.Load("CSV/dropWeapon") as TextAsset; // Resouces����CSV�ǂݍ���
        StringReader reader = new StringReader(DropcsvFile.text);

        // , �ŕ�������s���ǂݍ���
        // ���X�g�ɒǉ����Ă���
        while (reader.Peek() != -1) // reader.Peaek��-1�ɂȂ�܂�
        {
            string line = reader.ReadLine(); // ��s���ǂݍ���
            DropCSVDatas.Add(line.Split(',')); // , ��؂�Ń��X�g�ɒǉ�
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
