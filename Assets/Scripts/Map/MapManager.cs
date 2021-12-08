using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject SeedScript;
    public GameObject MapGenerate;

    Vector3 pos = new Vector3(0f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(SeedScript, pos, Quaternion.identity);
        Instantiate(MapGenerate, pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
