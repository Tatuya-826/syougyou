using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�J��������l���ɒǏ]���邽�߂̃v���O����
public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject player;   //�v���C���[���i�[�p
    [SerializeField] private Vector3 offset;    //�J�����ƃv���C���̋���
    
    void Start()
    {
       
    }

    void Update()
    {
        
        transform.position = player.transform.position + offset;

    }
}
