using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//カメラが主人公に追従するためのプログラム
public class CameraScript : MonoBehaviour//, IPunObservable
{
    [SerializeField] public GameObject player;   //プレイヤー情報格納用
    [SerializeField] private Vector3 offset;    //カメラとプレイヤの距離

    void Start()
    {
        player = transform.parent.gameObject;
        player.gameObject.GetComponent<Transform>();
    }
    void Update()
    {

        transform.position = player.transform.position + offset;
        Transform myTransform = this.transform;

        // ワールド座標を基準に、回転を取得
        Vector3 worldAngle = myTransform.eulerAngles;
        worldAngle.x = 90.0f; // ワールド座標を基準に、x軸を軸にした回転を10度に変更
        worldAngle.y = 0.0f; // ワールド座標を基準に、y軸を軸にした回転を10度に変更
        worldAngle.z = 0.0f; // ワールド座標を基準に、z軸を軸にした回転を10度に変更
        myTransform.eulerAngles = worldAngle; // 回転角度を設定


    }

    

}

