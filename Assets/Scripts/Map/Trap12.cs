using UnityEngine;
using System.Collections;

public class Trap12 : MonoBehaviour
{

    public GameObject enemy12;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            enemy12.SetActive(true);
        }
    }
}