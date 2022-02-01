using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NEWSTART : MonoBehaviour
{
    public void PushButton()
    {
        SceneManager.LoadScene("RoomMatchmaking");
    }
}
