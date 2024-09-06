using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{

    private float bulletSpeed = 15f;
    private float bulletTime = 4f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, bulletTime);
    }


    private void FixedUpdate(){
        rb.velocity = transform.up * bulletSpeed;
    }
}
