using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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



    //道の集合点を増やしたいならこれを増やす
    const int meetPointCount = 2;

    void Start()
    {

        ResetMapData();

        CreateSpaceData();

        CreateDangeon();

        RandomSpawn();          // キャラクターのランダム生成

        RandomSpawn2();         // 階段

    }

    // Update is called once per frame
    void Update()
    {

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
        for (int i = 0; i < MapHeight; i++)
        {
            for (int j = 0; j < MapWidth; j++)
            {
                if (Map[i, j] == wall)
                {
                    Instantiate(WallObject, new Vector3(j - MapWidth / 2,0 , i - MapHeight / 2), Quaternion.identity);
                }
            }
        }
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

}