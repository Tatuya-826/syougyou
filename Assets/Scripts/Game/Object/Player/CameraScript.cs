using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�J��������l���ɒǏ]���邽�߂̃v���O����
public class CameraScript : MonoBehaviour//, IPunObservable
{
    public static CameraScript instance;

    [SerializeField] private Transform player;   //�v���C���[���i�[�p
    [SerializeField] private Vector3 offset;     //�J�����ƃv���C���̋���

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlayerShutoku()//�v���C���[�̏����擾����
    {
        print("�v���C���[�擾�̊֐�");
        player = transform.parent.transform;
        player.gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = player.position + offset;
        Transform myTransform = this.transform;

        // ���[���h���W����ɁA��]���擾
        Vector3 worldAngle = myTransform.eulerAngles;
        worldAngle.x = 90.0f; // ���[���h���W����ɁAx�������ɂ�����]��10�x�ɕύX
        worldAngle.y = 0.0f; // ���[���h���W����ɁAy�������ɂ�����]��10�x�ɕύX
        worldAngle.z = 0.0f; // ���[���h���W����ɁAz�������ɂ�����]��10�x�ɕύX
        myTransform.eulerAngles = worldAngle; // ��]�p�x��ݒ�
    }
}

