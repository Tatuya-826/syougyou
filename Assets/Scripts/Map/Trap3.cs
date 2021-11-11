using UnityEngine;
using System.Collections;

public class Trap3 : MonoBehaviour
{

    public GameObject enemy3;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            enemy3.SetActive(true);
        }
    }
}