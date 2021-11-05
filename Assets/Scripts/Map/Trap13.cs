using UnityEngine;
using System.Collections;

public class Trap13 : MonoBehaviour
{

    public GameObject enemy13;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            enemy13.SetActive(true);
        }
    }
}