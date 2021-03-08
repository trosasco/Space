using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    public GameController gc;
    public GameObject crab;
    public GameObject octopus;
    public GameObject squid;
    public GameObject mothership;

    private int alienCount;
    private int alienSize;
    private int dir = 1;
    private float speed;

    private List<GameObject> aliens = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        
        Vector3 position = new Vector3(-4, 4, 0);
        for (var i = 0; i <= 31; i++)
        {
            GameObject spawn;
            position.x += 1;

            //Set x and y position for each row
            if (i % 8 == 0)
            {
                position.y -= 1;
                position.x = -4;
            }

            //Spawn type of alien based on rows of 8
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
            
            //Sets the alien behind the current alien as the follower
            if (i > 7)
            {
                int behind = i - (8 * (i / 8));
                spawn.GetComponent<AlienController>().setFollower(aliens[behind]);
            }

            //Sets the front row of aliens to be able to shoot
            if (i > 23)
            {
                spawn.GetComponent<AlienController>().shoot = true;
            }
            
            aliens.Add(spawn);
            
            //Sets the aliens as children 
            spawn.transform.parent = transform;
        }
        
        alienSize = transform.childCount;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var pos = transform.position;
        alienCount = transform.childCount;
        if (alienCount > 0)
        {
            if (pos.x >= 3 || pos.x <= -3)
            {
                dir *= -1;
                pos.y -= 0.25f;
                transform.position = pos;
            }

            speed = 1 + (0.1f * (alienSize - alienCount));
            transform.Translate(((Vector3.right * dir) * speed) * Time.deltaTime);
        }
        else
        {
            gc.win();
        }
    }
}
