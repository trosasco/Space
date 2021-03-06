using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Transform bullet;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        bullet.position += Vector3.up * speed;

        //Destroy bullet if offscreen
        if (bullet.position.y >= 10)
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
