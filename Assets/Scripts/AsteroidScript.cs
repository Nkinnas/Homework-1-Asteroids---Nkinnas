using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{

    public float asteroidSpeed = 2f; 
    public float changeDirectionInterval = 2f; 

    private Rigidbody2D rb;
    private Vector2 movementDirection;
  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetRandomDirection(); 
        InvokeRepeating("SetRandomDixrection", changeDirectionInterval, changeDirectionInterval);
    }

  
    void Update()
    {
        rb.velocity = movementDirection * asteroidSpeed;
    }

    void SetRandomDirection()
    {
        float randomAngle = Random.Range(0f, 360f);
        movementDirection = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle)).normalized;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Laser")){
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        SetRandomDirection();
    }

}
