using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�J��������l���ɒǏ]���邽�߂̃v���O����
public class searchAura : MonoBehaviour
{
    //public static CameraScript instance;
    void Update()
    {


            //���b�h
            //�C���X�^���e�B�G�C�g�@�I�[���[
            //�y�A�����g�I�u�W�F �t�@�C���h�^�O �I�[��
            //�I�[���̍��W�̓v���C���[�ɂ���
            

            Transform myRAuraTransform = this.transform;

            // ���[���h���W����ɁA��]���擾
            Vector3 rauraPos = myRAuraTransform.localPosition;
            rauraPos.x = 0.0f; // ���[���h���W����ɁAx�������ɂ�����]��10�x�ɕύX
            rauraPos.y = 0.0f; // ���[���h���W����ɁAy�������ɂ�����]��10�x�ɕύX
            rauraPos.z = -1.0f; // ���[���h���W����ɁAz�������ɂ�����]��10�x�ɕύX
            myRAuraTransform.localPosition = rauraPos; // ��]�p�x��ݒ�

    }
}
