using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MapGenerator : MonoBehaviourPunCallbacks//, IPunObservable
{
    bool pushFlag = false;
    public int mapStart = 0;

    public int MapWidth;
    public int MapHeight;

    int[,] Map;

    public int wall;
    public int road;

    public GameObject WallObject;

    public int roomMinHeight;
    public int roomMaxHeight;

    public int roomMinWidth;
    public int roomMaxWidth;

    public int RoomCountMin;
    public int RoomCountMax;

    public int roadWidth;

    // �����_������
    public GameObject cube;             // �L�����N�^�[�̃����_������
    public GameObject kaidan;           // ���̃t���A�֊K�i

    //�G�̃X�|�i�[
    public GameObject Enmspawner01;
    public GameObject Enmspawner02;
    public GameObject Enmspawner03;
    public GameObject Enmspawner04;
    public GameObject Enmspawner05;
    public GameObject Enmspawner06;
    public GameObject Enmspawner07;
    public GameObject Enmspawner08;
    public GameObject Enmspawner09;
    public GameObject Enmspawner10;
    public GameObject Enmspawner11;
    public GameObject Enmspawner12;
    public GameObject Enmspawner13;
    public GameObject Enmspawner14;
    public GameObject Enmspawner15;

    [SerializeField]

    //���̏W���_�𑝂₵�����Ȃ炱��𑝂₷
    const int meetPointCount = 2;




    public int seedNum;     //�V�[�h�l
    public int seed;
    GameObject seedObject;
    MapRandomSeed seedScript;


    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {

            mapStart = 1;



            seedObject = GameObject.Find("seedObject");
            seedScript = seedObject.GetComponent<MapRandomSeed>();

            //seedSetting();


            //Random.InitState(seed);
            Random.InitState(seedScript.seedNum);

            ResetMapData();

            CreateSpaceData();

            CreateDangeon();

            RandomSpawn();          // �L�����N�^�[�̃����_������

            RandomSpawn2();         // �K�i

            EnmSpawner01();         // �G�̃X�|�i�[1
            EnmSpawner02();         // �G�̃X�|�i�[2
            EnmSpawner03();         // �G�̃X�|�i�[3
            EnmSpawner04();         // �G�̃X�|�i�[4
            EnmSpawner05();         // �G�̃X�|�i�[5
            EnmSpawner06();         // �G�̃X�|�i�[6
            EnmSpawner07();         // �G�̃X�|�i�[7
            EnmSpawner08();         // �G�̃X�|�i�[8
            EnmSpawner09();         // �G�̃X�|�i�[9
            EnmSpawner10();         // �G�̃X�|�i�[10
            EnmSpawner11();         // �G�̃X�|�i�[11
            EnmSpawner12();         // �G�̃X�|�i�[12
            EnmSpawner13();         // �G�̃X�|�i�[13
            EnmSpawner14();         // �G�̃X�|�i�[14
            EnmSpawner15();         // �G�̃X�|�i�[15

            mapStart = 0;




            print("�L�[����M���m�F");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            PhotonNetwork.IsMessageQueueRunning = false;
            SceneManager.LoadScene("Kaihatuyou");
        }

    }
    

    void seedSetting()
    {
        seedNum = Random.Range(0, 100); //�V�[�h�l�𗐐��ŃZ�b�g����
        print("mapgenerater��� �����Z�b�g�̎��_��" + seedNum);
    }

    int setSeed()
    {
        int seed = Random.Range(0, 100);

        Random.InitState(seed);
        print("seed" + seed);

        return seed;
    }

    /// <summary>
    /// Map�̓񎟌��z��̏�����
    /// </summary>
    private void ResetMapData()
    {
        Map = new int[MapHeight, MapWidth];
        for (int i = 0; i < MapHeight; i++)
        {
            for (int j = 0; j < MapWidth; j++)
            {
                Map[i, j] = wall;
            }
        }
    }

    /// <summary>
    /// �󔒕����̃f�[�^��ύX
    /// </summary>
    private void CreateSpaceData()
    {
        int roomCount = Random.Range(RoomCountMin, RoomCountMax);

        int[] meetPointsX = new int[meetPointCount];
        int[] meetPointsY = new int[meetPointCount];
        for (int i = 0; i < meetPointsX.Length; i++)
        {
            meetPointsX[i] = Random.Range(MapWidth / 4, MapWidth * 3 / 4);
            meetPointsY[i] = Random.Range(MapHeight / 4, MapHeight * 3 / 4);
            Map[meetPointsY[i], meetPointsX[i]] = road;
        }

        for (int i = 0; i < roomCount; i++)
        {
            int roomHeight = Random.Range(roomMinHeight, roomMaxHeight);
            int roomWidth = Random.Range(roomMinWidth, roomMaxWidth);
            int roomPointX = Random.Range(2, MapWidth - roomMaxWidth - 2);
            int roomPointY = Random.Range(2, MapWidth - roomMaxWidth - 2);

            int roadStartPointX = Random.Range(roomPointX, roomPointX + roomWidth);
            int roadStartPointY = Random.Range(roomPointY, roomPointY + roomHeight);

            bool isRoad = CreateRoomData(roomHeight, roomWidth, roomPointX, roomPointY);

            if (isRoad == false)
            {
                CreateRoadData(roadStartPointX, roadStartPointY, meetPointsX[Random.Range(0, 0)], meetPointsY[Random.Range(0, 0)]);
            }
        }
    }

    /// <summary>
    /// �����f�[�^�𐶐��B���łɕ���������ꍇ��true��Ԃ��A�������Ȃ��悤�ɂ���
    /// </summary>
    /// <param name="roomHeight">�����̍���</param>
    /// <param name="roomWidth">�����̉���</param>
    /// <param name="roomPointX">�����̎n�_(x)</param>
    /// <param name="roomPointY">�����̎n�_(y)</param>
    /// <returns></returns>
    private bool CreateRoomData(int roomHeight, int roomWidth, int roomPointX, int roomPointY)
    {
        bool isRoad = false;
        for (int i = 0; i < roomHeight; i++)
        {
            for (int j = 0; j < roomWidth; j++)
            {
                if (Map[roomPointY + i, roomPointX + j] == road)
                {
                    isRoad = true;
                }
                else
                {
                    Map[roomPointY + i, roomPointX + j] = road;
                }
            }
        }
        return isRoad;
    }

    /// <summary>
    /// ���f�[�^�𐶐�
    /// </summary>
    /// <param name="roadStartPointX"></param>
    /// <param name="roadStartPointY"></param>
    /// <param name="meetPointX"></param>
    /// <param name="meetPointY"></param>
    private void CreateRoadData(int roadStartPointX, int roadStartPointY, int meetPointX, int meetPointY)
    {

        bool isRight;
        if (roadStartPointX > meetPointX)
        {
            isRight = true;
        }
        else
        {
            isRight = false;
        }
        bool isUnder;
        if (roadStartPointY > meetPointY)
        {
            isUnder = false;
        }
        else
        {
            isUnder = true;
        }

        if (Random.Range(0, 2) == 0)
        {

            while (roadStartPointX != meetPointX)
            {

                for (int i = 0; i < roadWidth; i++)
                {
                    Map[roadStartPointY + i, roadStartPointX] = road;
                }
                if (isRight == true)
                {
                    roadStartPointX--;
                }
                else
                {
                    roadStartPointX++;
                }

            }

            while (roadStartPointY != meetPointY)
            {

                for (int i = 0; i < roadWidth; i++)
                {
                    Map[roadStartPointY, roadStartPointX + i] = road;
                }
                if (isUnder == true)
                {
                    roadStartPointY++;
                }
                else
                {
                    roadStartPointY--;
                }
            }

        }
        else
        {

            while (roadStartPointY != meetPointY)
            {

                for (int i = 0; i < roadWidth; i++)
                {
                    Map[roadStartPointY, roadStartPointX + i] = road;
                }
                if (isUnder == true)
                {
                    roadStartPointY++;
                }
                else
                {
                    roadStartPointY--;
                }
            }

            while (roadStartPointX != meetPointX)
            {

                for (int i = 0; i < roadWidth; i++)
                {
                    Map[roadStartPointY + i, roadStartPointX] = road;
                }
                if (isRight == true)
                {
                    roadStartPointX--;
                }
                else
                {
                    roadStartPointX++;
                }
            }
        }
    }

    /// <summary>
    /// �}�b�v�f�[�^�����ƂɃ_���W�����𐶐�
    /// </summary>
    private void CreateDangeon()
    {
        for (int i = 0; i < MapHeight; i+=4)
        {
            for (int j = 0; j < MapWidth; j+=4)
            {
                if (Map[i, j] == wall)
                {
                    Instantiate(WallObject, new Vector3(j - MapWidth / 2,0 , i - MapHeight / 2), Quaternion.identity);
                }
            }
        }
        // NavMesh���r���h����
        // Debug.Log("�Ȃ�");
        //_surface.BuildNavMesh();������
    }

    // �L�����N�^�[�̃����_������
    private void RandomSpawn()
    {
        int x, y, z;
        do
        {
            x = Random.Range(0, MapWidth);
            y = Random.Range(-1, -1);
            z = Random.Range(0, MapHeight);
        }
        while (Map[z, x] != road);

        // Instantiate(cube, new Vector3(y - MapWidth / 2, x - MapHeight / 2, 0), Quaternion.identity);
        Instantiate(cube, new Vector3(x - MapWidth / 2,y, z - MapHeight/2), Quaternion.identity);

    }

    // ���̃t���A�֊K�i
    private void RandomSpawn2()
    {
        int x, y, z;
        do
        {
            x = Random.Range(0, MapWidth);
            y = Random.Range(-1, -1);
            z = Random.Range(0, MapHeight);
        }
        while (Map[z, x] != road);

        // Instantiate(cube, new Vector3(y - MapWidth / 2, x - MapHeight / 2, 0), Quaternion.identity);
        Instantiate(kaidan, new Vector3(x - MapWidth / 2, y, z - MapHeight / 2), Quaternion.identity);

    }


    // �G�̃X�|�i�[01
    private void EnmSpawner01()
    {
        int x, y, z;
        do
        {
            x = Random.Range(0, MapWidth);
            y = Random.Range(-1, -1);
            z = Random.Range(0, MapHeight);
        }
        while (Map[z, x] != road);

        Instantiate(Enmspawner01, new Vector3(x - MapWidth / 2, y, z - MapHeight / 2), Quaternion.identity);

    }

    // �G�̃X�|�i�[02
    private void EnmSpawner02()
    {
        int x, y, z;
        do
        {
            x = Random.Range(0, MapWidth);
            y = Random.Range(-1, -1);
            z = Random.Range(0, MapHeight);
        }
        while (Map[z, x] != road);

        Instantiate(Enmspawner02, new Vector3(x - MapWidth / 2, y, z - MapHeight / 2), Quaternion.identity);

    }

    // �G�̃X�|�i�[03
    private void EnmSpawner03()
    {
        int x, y, z;
        do
        {
            x = Random.Range(0, MapWidth);
            y = Random.Range(-1, -1);
            z = Random.Range(0, MapHeight);
        }
        while (Map[z, x] != road);

        Instantiate(Enmspawner03, new Vector3(x - MapWidth / 2, y, z - MapHeight / 2), Quaternion.identity);

    }

    // �G�̃X�|�i�[04
    private void EnmSpawner04()
    {
        int x, y, z;
        do
        {
            x = Random.Range(0, MapWidth);
            y = Random.Range(-1, -1);
            z = Random.Range(0, MapHeight);
        }
        while (Map[z, x] != road);

        Instantiate(Enmspawner04, new Vector3(x - MapWidth / 2, y, z - MapHeight / 2), Quaternion.identity);

    }


    // �G�̃X�|�i�[05
    private void EnmSpawner05()
    {
        int x, y, z;
        do
        {
            x = Random.Range(0, MapWidth);
            y = Random.Range(-1, -1);
            z = Random.Range(0, MapHeight);
        }
        while (Map[z, x] != road);

        Instantiate(Enmspawner05, new Vector3(x - MapWidth / 2, y, z - MapHeight / 2), Quaternion.identity);

    }

    // �G�̃X�|�i�[06
    private void EnmSpawner06()
    {
        int x, y, z;
        do
        {
            x = Random.Range(0, MapWidth);
            y = Random.Range(-1, -1);
            z = Random.Range(0, MapHeight);
        }
        while (Map[z, x] != road);

        Instantiate(Enmspawner06, new Vector3(x - MapWidth / 2, y, z - MapHeight / 2), Quaternion.identity);

    }

    // �G�̃X�|�i�[07
    private void EnmSpawner07()
    {
        int x, y, z;
        do
        {
            x = Random.Range(0, MapWidth);
            y = Random.Range(-1, -1);
            z = Random.Range(0, MapHeight);
        }
        while (Map[z, x] != road);

        Instantiate(Enmspawner07, new Vector3(x - MapWidth / 2, y, z - MapHeight / 2), Quaternion.identity);

    }

    // �G�̃X�|�i�[08
    private void EnmSpawner08()
    {
        int x, y, z;
        do
        {
            x = Random.Range(0, MapWidth);
            y = Random.Range(-1, -1);
            z = Random.Range(0, MapHeight);
        }
        while (Map[z, x] != road);

        Instantiate(Enmspawner08, new Vector3(x - MapWidth / 2, y, z - MapHeight / 2), Quaternion.identity);

    }

    // �G�̃X�|�i�[09
    private void EnmSpawner09()
    {
        int x, y, z;
        do
        {
            x = Random.Range(0, MapWidth);
            y = Random.Range(-1, -1);
            z = Random.Range(0, MapHeight);
        }
        while (Map[z, x] != road);

        Instantiate(Enmspawner09, new Vector3(x - MapWidth / 2, y, z - MapHeight / 2), Quaternion.identity);

    }

    // �G�̃X�|�i�[10
    private void EnmSpawner10()
    {
        int x, y, z;
        do
        {
            x = Random.Range(0, MapWidth);
            y = Random.Range(-1, -1);
            z = Random.Range(0, MapHeight);
        }
        while (Map[z, x] != road);

        Instantiate(Enmspawner10, new Vector3(x - MapWidth / 2, y, z - MapHeight / 2), Quaternion.identity);

    }

    // �G�̃X�|�i�[11
    private void EnmSpawner11()
    {
        int x, y, z;
        do
        {
            x = Random.Range(0, MapWidth);
            y = Random.Range(-1, -1);
            z = Random.Range(0, MapHeight);
        }
        while (Map[z, x] != road);

        Instantiate(Enmspawner11, new Vector3(x - MapWidth / 2, y, z - MapHeight / 2), Quaternion.identity);

    }

    // �G�̃X�|�i�[12
    private void EnmSpawner12()
    {
        int x, y, z;
        do
        {
            x = Random.Range(0, MapWidth);
            y = Random.Range(-1, -1);
            z = Random.Range(0, MapHeight);
        }
        while (Map[z, x] != road);

        Instantiate(Enmspawner12, new Vector3(x - MapWidth / 2, y, z - MapHeight / 2), Quaternion.identity);

    }

    // �G�̃X�|�i�[13
    private void EnmSpawner13()
    {
        int x, y, z;
        do
        {
            x = Random.Range(0, MapWidth);
            y = Random.Range(-1, -1);
            z = Random.Range(0, MapHeight);
        }
        while (Map[z, x] != road);

        Instantiate(Enmspawner13, new Vector3(x - MapWidth / 2, y, z - MapHeight / 2), Quaternion.identity);

    }

    // �G�̃X�|�i�[14
    private void EnmSpawner14()
    {
        int x, y, z;
        do
        {
            x = Random.Range(0, MapWidth);
            y = Random.Range(-1, -1);
            z = Random.Range(0, MapHeight);
        }
        while (Map[z, x] != road);

        Instantiate(Enmspawner14, new Vector3(x - MapWidth / 2, y, z - MapHeight / 2), Quaternion.identity);

    }
    // �G�̃X�|�i�[15
    private void EnmSpawner15()
    {
        int x, y, z;
        do
        {
            x = Random.Range(0, MapWidth);
            y = Random.Range(-1, -1);
            z = Random.Range(0, MapHeight);
        }
        while (Map[z, x] != road);

        Instantiate(Enmspawner15, new Vector3(x - MapWidth / 2, y, z - MapHeight / 2), Quaternion.identity);

    }
    /*
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(seedNum);
        }
        else
        {
            seedNum = (int)stream.ReceiveNext();
        }
    }
    */
}