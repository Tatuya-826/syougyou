using UnityEngine;
using System.Collections;

public class Trap4 : MonoBehaviour
{

    public GameObject enemy4;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            enemy4.SetActive(true);
        }
    }
}