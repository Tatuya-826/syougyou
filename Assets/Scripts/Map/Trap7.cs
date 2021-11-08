using UnityEngine;
using System.Collections;

public class Trap7 : MonoBehaviour
{

    public GameObject enemy7;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            enemy7.SetActive(true);
        }
    }
}