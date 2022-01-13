using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonGate : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Õ“Ë‚µ‚½‘Šè‚ÉPlayerƒ^ƒO‚ª•t‚¢‚Ä‚¢‚é‚Æ‚«
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Map");
        }
    }


}
