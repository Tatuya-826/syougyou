using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statusreset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerStatus.Status.reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
