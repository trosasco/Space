using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rb;
    private float speed = 7;

    public float maxBoundary, minBoundary;
    public GameObject bullet;
    public Transform parentTransform;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Change velocity of player based on left and right arrows
        // Also add boundaries to player movement
        if (player.position.x < maxBoundary && Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(speed, 0);
        } else if (player.position.x > minBoundary && Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            spawnBullet();
        }
    }

    void spawnBullet()
    {
        Instantiate(bullet, parentTransform.position, parentTransform.rotation);
    }
    
    
}
