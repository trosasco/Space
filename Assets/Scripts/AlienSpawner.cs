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
    private float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = new Vector3(-4, 4, 0);
        for (var i = 0; i <= 31; i++)
        {
            position.x += 1;

            if (i % 8 == 0)
            {
                position.y -= 1;
                position.x = -4;
            }

            if (i <= 15)
            {
                Instantiate(squid, position, Quaternion.identity);
            } else if (i >= 16 && i <= 23)
            {
                Instantiate(crab, position, Quaternion.identity);
            }
            else
            {
                Instantiate(octopus, position, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > 0)
        {
            alienCount = transform.childCount;
        }
        
    }
}
