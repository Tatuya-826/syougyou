using UnityEngine;
using System.Collections;

public class Trap11 : MonoBehaviour
{

    public GameObject enemy11;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            enemy11.SetActive(true);
        }
    }
}