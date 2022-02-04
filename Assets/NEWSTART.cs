using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NEWSTART : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PushButton()
    {
        SceneManager.LoadScene("RoomMatchmaking");
        audioSource.PlayOneShot(sound1);
    }
}
