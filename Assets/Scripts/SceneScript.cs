using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{

    //���C�����j���[�V�[����ǂݍ���
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //�X�e�[�W�V�[����ǂݍ���
    public void LoadStage()
    {
        SceneManager.LoadScene("Stage");
    }

    //���U���g�V�[����ǂݍ���
    public void LoadResult()
    {
        SceneManager.LoadScene("Result");
    }

    //�Q�[�����I��炷
    public void GameEnd()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
           Application.Quit();
        #endif
    }
}
