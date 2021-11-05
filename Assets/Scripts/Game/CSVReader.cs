using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReader : MonoBehaviour
{
    TextAsset csvFile; // CSV�t�@�C��
    List<string[]> WeaponCSVDatas = new List<string[]>(); // CSV�̒��g�����郊�X�g;

    void Start()
    {
        csvFile = Resources.Load("CSV/WeaponCSVtest") as TextAsset; // Resouces����CSV�ǂݍ���
        StringReader reader = new StringReader(csvFile.text);

        // , �ŕ�������s���ǂݍ���
        // ���X�g�ɒǉ����Ă���
        while (reader.Peek() != -1) // reader.Peaek��-1�ɂȂ�܂�
        {
            string line = reader.ReadLine(); // ��s���ǂݍ���
            WeaponCSVDatas.Add(line.Split(',')); // , ��؂�Ń��X�g�ɒǉ�
        }

        // csvDatas[�s][��]���w�肵�Ēl�����R�Ɏ��o����
        Debug.Log(WeaponCSVDatas[1][0]);

    }

    public string WeaponNameGetter(int index)
    {
        index++;
        return WeaponCSVDatas[index][1];
    }
}
