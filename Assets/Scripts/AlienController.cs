using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    private GameController gc;
    public int value = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("Player").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            gc.addScore(value);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
