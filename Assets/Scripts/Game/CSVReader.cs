using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class CSVReader : MonoBehaviour
{
    TextAsset WeaponcsvFile; // CSV�t�@�C��
    TextAsset ArmorcsvFile; // CSV�t�@�C��
    List<string[]> WeaponCSVDatas = new List<string[]>(); // CSV�̒��g�����郊�X�g;
    List<string[]> ArmorCSVDatas = new List<string[]>(); // CSV�̒��g�����郊�X�g;

    private StreamWriter swWeapon;
    private StreamWriter swArmor;

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
            string line = reader.ReadLine(); // ��s���ǂݍ���
            WeaponCSVDatas.Add(line.Split(',')); // , ��؂�Ń��X�g�ɒǉ�
        }

        bukisu = WeaponCSVDatas.Count;

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
        bougusu = ArmorCSVDatas.Count;

        // csvDatas[�s][��]���w�肵�Ēl�����R�Ɏ��o����
        //Debug.Log(WeaponCSVDatas[1][0]);
        //SaveItem("A", "��낢��", 1111, "��낢��", "��낢����");
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
        print("���[�[�[�[�[�[�[�[�[�[�[�[��");
        if (ty == "W")
        {
            string[] Item = { bukisu.ToString(), na, wt, pr, at.ToString() };
            WeaponCSVDatas.Add(Item);//���X�g�ɒǉ�
            bukisu++;
            print("���[�[�[�[�[�[�[�[�[�[�[�[��2");
            //print(bukisu);
            //Debug.Log(WeaponCSVDatas[bukisu-1][1]+ WeaponCSVDatas[bukisu - 1][4]);
        }
        else
        {
            string[] Item = { bougusu.ToString(), na, wt, pr, at.ToString() };
            ArmorCSVDatas.Add(Item);//���X�g�ɒǉ�
            bougusu++;
            print("���[�[�[�[�[�[�[�[�[�[�[�[��2");
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
            print("���[�[�[�[�[�[�[�[�[�[�[�[�Ԃ��Ă��܂�" );
        }
        swWeapon.Close();
        swArmor = new StreamWriter("Assets/Resources/CSV/ArmorCSVtest.csv", false, Encoding.GetEncoding("UTF-8"));
        for (int i = 0; i < bougusu; i++)
        {
            string[] s1 = { ArmorCSVDatas[i][0], ArmorCSVDatas[i][1], ArmorCSVDatas[i][2], ArmorCSVDatas[i][3], ArmorCSVDatas[i][4] };
            string s2 = string.Join(",", s1);
            swArmor.WriteLine(s2);
            print("���[�[�[�[�[�[�[�[�[�[�[�[�Ԃ��Ă��܂�");
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
