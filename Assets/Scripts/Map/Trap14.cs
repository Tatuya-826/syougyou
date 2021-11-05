using UnityEngine;
using System.Collections;

public class Trap14 : MonoBehaviour
{

    public GameObject enemy14;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            enemy14.SetActive(true);
        }
    }
}