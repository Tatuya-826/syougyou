using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MapGenerator : MonoBehaviour
{

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

    // ランダム生成
    public GameObject cube;             // キャラクターのランダム生成
    public GameObject kaidan;           // 次のフロアへ階段

    //敵のスポナー
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
    //private NavMeshSurface _surface;

    //道の集合点を増やしたいならこれを増やす
    const int meetPointCount = 2;

    void Start()
    {
        Random.InitState(100);

        ResetMapData();

        CreateSpaceData();

        CreateDangeon();

        RandomSpawn();          // キャラクターのランダム生成

        RandomSpawn2();         // 階段

        EnmSpawner01();         // 敵のスポナー1
        EnmSpawner02();         // 敵のスポナー2
        EnmSpawner03();         // 敵のスポナー3
        EnmSpawner04();         // 敵のスポナー4
        EnmSpawner05();         // 敵のスポナー5
        EnmSpawner06();         // 敵のスポナー6
        EnmSpawner07();         // 敵のスポナー7
        EnmSpawner08();         // 敵のスポナー8
        EnmSpawner09();         // 敵のスポナー9
        EnmSpawner10();         // 敵のスポナー10
        EnmSpawner11();         // 敵のスポナー11
        EnmSpawner12();         // 敵のスポナー12
        EnmSpawner13();         // 敵のスポナー13
        EnmSpawner14();         // 敵のスポナー14
        EnmSpawner15();         // 敵のスポナー15

    }

    // Update is called once per frame
    void Update()
    {
        //_surface.BuildNavMesh();
    }

    /// <summary>
    /// Mapの二次元配列の初期化
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
    /// 空白部分のデータを変更
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
    /// 部屋データを生成。すでに部屋がある場合はtrueを返し、道を作らないようにする
    /// </summary>
    /// <param name="roomHeight">部屋の高さ</param>
    /// <param name="roomWidth">部屋の横幅</param>
    /// <param name="roomPointX">部屋の始点(x)</param>
    /// <param name="roomPointY">部屋の始点(y)</param>
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
    /// 道データを生成
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
    /// マップデータをもとにダンジョンを生成
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
        // NavMeshをビルドする
        // Debug.Log("なび");
        //_surface.BuildNavMesh();動かん

    }

    // キャラクターのランダム生成
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

    // 次のフロアへ階段
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


    // 敵のスポナー01
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

    // 敵のスポナー02
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

    // 敵のスポナー03
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

    // 敵のスポナー04
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


    // 敵のスポナー05
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

    // 敵のスポナー06
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

    // 敵のスポナー07
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

    // 敵のスポナー08
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

    // 敵のスポナー09
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

    // 敵のスポナー10
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

    // 敵のスポナー11
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

    // 敵のスポナー12
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

    // 敵のスポナー13
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

    // 敵のスポナー14
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
    // 敵のスポナー15
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



}