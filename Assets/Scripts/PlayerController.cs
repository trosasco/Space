using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private GameController gc;
    private Transform player;
    private Rigidbody2D rb;
    private float speed = 7;
    private float fired;
    public float fireDelay = 0.25f;

    public bool allowInput = false;
    public float maxBoundary, minBoundary;
    public GameObject bullet;
    public Transform parentTransform;

    // Start is called before the first frame update
    void Start()
    {
        
        player = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        gc = GetComponent<GameController>();
    }

    private void FixedUpdate()
    {
        //Change velocity of player based on left and right arrows
        // Also add boundaries to player movement
        if (allowInput)
        {
            if (player.position.x < maxBoundary && Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity = new Vector2(speed, 0);
            }
            else if (player.position.x > minBoundary && Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity = new Vector2(-speed, 0);
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Delays the input check to reduce spamming the keys
        if (Time.time > fired)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && allowInput)
            {
                spawnBullet();
                fired = Time.time + fireDelay;
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            gc.restart();
        }
    }

    void spawnBullet()
    {
        GameObject bul;
        bul = Instantiate(bullet, parentTransform.position, parentTransform.rotation);
        bul.GetComponent<BulletController>().dir = true;
    }
    
    //If Player hit with Enemy or bullet
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" || 
            other.gameObject.tag == "Crab" || 
            other.gameObject.tag == "Octopus" || 
            other.gameObject.tag == "Squid")
        {
            gc.gameOver();
            allowInput = false;
        }
    }
    
}
