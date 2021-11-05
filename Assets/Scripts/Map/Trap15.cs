using UnityEngine;
using System.Collections;

public class Trap15 : MonoBehaviour
{

    public GameObject enemy15;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            enemy15.SetActive(true);
        }
    }
}