using UnityEngine;
using System.Collections;

public class Trap6 : MonoBehaviour
{

    public GameObject enemy6;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            enemy6.SetActive(true);
        }
    }
}