using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EnemyCSVReader : MonoBehaviour
{
    TextAsset EnemycsvFile; // CSV�t�@�C��
    List<string[]> EnemyCSVDatas = new List<string[]>(); // CSV�̒��g�����郊�X�g;

    // Start is called before the first frame update
    void Start()
    {
        EnemycsvFile = Resources.Load("CSV/EnemyCSVtest") as TextAsset; // Resouces����CSV�ǂݍ���
        StringReader reader = new StringReader(EnemycsvFile.text);

        // , �ŕ�������s���ǂݍ���
        // ���X�g�ɒǉ����Ă���
        while (reader.Peek() != -1) // reader.Peaek��-1�ɂȂ�܂�
        {
            string line = reader.ReadLine(); // ��s���ǂݍ���
            EnemyCSVDatas.Add(line.Split(',')); // , ��؂�Ń��X�g�ɒǉ�
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
