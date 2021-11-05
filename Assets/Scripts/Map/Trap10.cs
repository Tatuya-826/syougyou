using UnityEngine;
using System.Collections;

public class Trap10 : MonoBehaviour
{

    public GameObject enemy10;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            enemy10.SetActive(true);
        }
    }
}