using UnityEngine;
using System.Collections;

public class Trap9 : MonoBehaviour
{

    public GameObject enemy9;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            enemy9.SetActive(true);
        }
    }
}