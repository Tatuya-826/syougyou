using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Vector3 forward;
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        var rid = GetComponent<Rigidbody>();
        rid.velocity = this.forward * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        forward = this.transform.forward;
    }
}
