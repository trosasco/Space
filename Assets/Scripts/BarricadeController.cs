using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls each individual barricade
public class BarricadeController : MonoBehaviour
{
    public float health = 3;
    private Vector3 scale;
    
    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        transform.localScale = scale;
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            health -= 0.5f;
            scale.x -= 1f;
            scale.y -= 1f;
            Destroy(other.gameObject);
        }
    }
}
