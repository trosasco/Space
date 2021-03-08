using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AlienController : MonoBehaviour
{
    private GameController gc;
    public int value = 10;
    private GameObject follower;
    private float shot;
    public GameObject bullet;
    public bool shoot;
    
    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("Player").GetComponent<GameController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shoot && Time.time > shot)
        {
            shot = Time.time + Random.Range(1, 5);
            StartCoroutine(spawnBullet());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            //Sets the dead aliens follower to be able to shoot
            if (follower != null)
            {
                follower.GetComponent<AlienController>().shoot = true;
            }
            
            gc.addScore(value);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    public void setFollower(GameObject f)
    {
        follower = f;
    }

    IEnumerator spawnBullet()
    {
        yield return new WaitForSeconds(Random.Range(3f, 15f));
        Vector3 v = transform.position + Vector3.down;
        Instantiate(bullet, v, transform.rotation).tag = "Enemy";

    }
}
