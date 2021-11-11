using UnityEngine;
using System.Collections;

public class Trap1 : MonoBehaviour
{

    public GameObject enemy1;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            enemy1.SetActive(true);
        }
    }
}