using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{

    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private Transform firingPoint;


    public float rocketSpeed = 10f;
    public Vector3 rocketRespawnCoords = new Vector3(0, 0, 0);

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.identity;
    }

    void Update()
    {
        Vector2 playerMovement = Vector2.zero;

        if (Input.GetKey(KeyCode.W)){
            playerMovement += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A)){
            playerMovement += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S)){
            playerMovement += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D)){
            playerMovement += Vector2.right;
        }
       
        rb.velocity = playerMovement * rocketSpeed;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;
        transform.up = direction;

        if (Input.GetKeyDown(KeyCode.Mouse0)){
            ShootLaser();
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Asteroid")){
            Debug.Log("You were hit!");
            transform.position = rocketRespawnCoords;
        }
    }


    private void ShootLaser(){
        Instantiate(laserPrefab, firingPoint.position, firingPoint.rotation);
    }
}
