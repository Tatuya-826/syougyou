using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonGate : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Õ“Ë‚µ‚½‘Šè‚ÉPlayerƒ^ƒO‚ª•t‚¢‚Ä‚¢‚é‚Æ‚«
        if (collision.gameObject.tag == "Player")
        {
            PhotonNetwork.LeaveRoom();
            SceneManager.LoadScene("Map");
        }
    }


}
