using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    public GameObject crab;
    public GameObject octopus;
    public GameObject squid;
    public GameObject mothership;

    private int alienCount;
    private int alienSize;
    private int dir = 1;
    private float speed;

    private List<GameObject> aliens;
    
    // Start is called before the first frame update
    void Start()
    {

        Vector3 position = new Vector3(-4, 4, 0);
        for (var i = 0; i <= 31; i++)
        {
            GameObject spawn;
            position.x += 1;

            if (i % 8 == 0)
            {
                position.y -= 1;
                position.x = -4;
            }

            if (i <= 15)
            {
                spawn = Instantiate(squid, position, Quaternion.identity);
            } else if (i >= 16 && i <= 23)
            {
                spawn = Instantiate(crab, position, Quaternion.identity);
            }
            else
            {
                spawn = Instantiate(octopus, position, Quaternion.identity);
            }
            aliens.Add(spawn);
            spawn.transform.parent = transform;
        }
        
        alienSize = transform.childCount;
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        if (transform.childCount > 0)
        {
            alienCount = transform.childCount;
            
        }

        if (pos.x >= 3 || pos.x <= -3)
        {
            dir *= -1;
            pos.y -= 0.25f;
            transform.position = pos;
        }
        speed = 1 + (0.1f * (alienSize - alienCount));
        transform.Translate(Vector3.right * Time.deltaTime * speed * dir);
    }
}
