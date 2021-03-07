using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls the barricades parent
public class BaseController : MonoBehaviour
{
    public Transform barricades;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //If all barricades are gone, game is lost
        if (barricades.childCount == 0)
        {
            GameController.playerDead = true;
        }
    }
    
}
