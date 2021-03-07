using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public float health = 3;
    private Transform barricades;
    
    // Start is called before the first frame update
    void Start()
    {
        barricades = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        //If all barricades are gone, game is lost
        if (barricades.childCount == 0)
        {
            GameController.playerDead = true;
        }
    }
}
