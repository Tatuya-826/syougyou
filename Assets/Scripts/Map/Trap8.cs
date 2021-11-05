using UnityEngine;
using System.Collections;

public class Trap8 : MonoBehaviour
{

    public GameObject enemy8;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            enemy8.SetActive(true);
        }
    }
}