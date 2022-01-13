using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�J��������l���ɒǏ]���邽�߂̃v���O����
public class CameraScript : MonoBehaviour//, IPunObservable
{
    [SerializeField] public GameObject player;   //�v���C���[���i�[�p
    [SerializeField] private Vector3 offset;    //�J�����ƃv���C���̋���

    void Start()
    {
        player = transform.parent.gameObject;
        player.gameObject.GetComponent<Transform>();
    }
    void Update()
    {

        transform.position = player.transform.position + offset;
        Transform myTransform = this.transform;

        // ���[���h���W����ɁA��]���擾
        Vector3 worldAngle = myTransform.eulerAngles;
        worldAngle.x = 90.0f; // ���[���h���W����ɁAx�������ɂ�����]��10�x�ɕύX
        worldAngle.y = 0.0f; // ���[���h���W����ɁAy�������ɂ�����]��10�x�ɕύX
        worldAngle.z = 0.0f; // ���[���h���W����ɁAz�������ɂ�����]��10�x�ɕύX
        myTransform.eulerAngles = worldAngle; // ��]�p�x��ݒ�


    }

    

}

