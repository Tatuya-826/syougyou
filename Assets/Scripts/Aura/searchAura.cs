using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//カメラが主人公に追従するためのプログラム
public class searchAura : MonoBehaviour
{
    //public static CameraScript instance;
    void Update()
    {


            //レッド
            //インスタンティエイト　オーラー
            //ペアレントオブジェ ファインドタグ オーラ
            //オーラの座標はプレイヤーにする
            

            Transform myRAuraTransform = this.transform;

            // ワールド座標を基準に、回転を取得
            Vector3 rauraPos = myRAuraTransform.localPosition;
            rauraPos.x = 0.0f; // ワールド座標を基準に、x軸を軸にした回転を10度に変更
            rauraPos.y = 0.0f; // ワールド座標を基準に、y軸を軸にした回転を10度に変更
            rauraPos.z = -1.0f; // ワールド座標を基準に、z軸を軸にした回転を10度に変更
            myRAuraTransform.localPosition = rauraPos; // 回転角度を設定

    }
}
