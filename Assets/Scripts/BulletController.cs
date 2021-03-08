using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Transform bullet;
    public float speed;
    public bool dir = false;
    
    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if (dir)
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.up * speed;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.down * speed;
        }

        //Destroy bullet if offscreen
        if (bullet.position.y >= 10 || bullet.position.y <= -5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        /*if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        } else if (other.CompareTag("Barrier"))
        {
            Destroy(gameObject);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
