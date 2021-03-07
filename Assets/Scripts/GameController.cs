using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public UIController ui;

    public static bool playerDead = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (playerDead)
            {
                Time.timeScale = 0;
                ui.showGameOver(true);
            }
        }
        catch (NullReferenceException e)
        {
            Debug.Log("Nullreference");
        }

    }

}
