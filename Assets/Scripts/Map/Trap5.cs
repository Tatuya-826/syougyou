using UnityEngine;
using System.Collections;

public class Trap5 : MonoBehaviour
{

    public GameObject enemy5;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            enemy5.SetActive(true);
        }
    }
}