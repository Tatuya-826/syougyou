using UnityEngine;
using System.Collections;

public class Trap2 : MonoBehaviour
{

    public GameObject enemy2;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            enemy2.SetActive(true);
        }
    }
}