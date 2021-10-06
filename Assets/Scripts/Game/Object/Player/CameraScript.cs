using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//カメラが主人公に追従するためのプログラム
public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject player;   //プレイヤー情報格納用
    [SerializeField] private Vector3 offset;    //カメラとプレイヤの距離
    
    void Start()
    {
       
    }

    void Update()
    {
        
        transform.position = player.transform.position + offset;

    }
}
