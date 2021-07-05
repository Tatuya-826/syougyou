using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{

    //メインメニューシーンを読み込む
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //ステージシーンを読み込む
    public void LoadStage()
    {
        SceneManager.LoadScene("Stage");
    }

    //リザルトシーンを読み込む
    public void LoadResult()
    {
        SceneManager.LoadScene("Result");
    }

    //ゲームを終わらす
    public void GameEnd()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
           Application.Quit();
        #endif
    }
}
