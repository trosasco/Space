using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public UIController ui;
    public GameObject alienSpawn;

    public static bool playerDead = false;

    private int score = 0;
    private int highScore = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startRoutine());
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
            Debug.Log(e);
        }

    }

    public void addScore(int x)
    {
        score += x;
        ui.updateScore(score);

        if (score > highScore)
        {
            highScore = score;
            ui.updateHighScore(highScore);
        }
    }

    IEnumerator startRoutine()
    {
        yield return new WaitForSeconds(8f);
        alienSpawn.gameObject.SetActive(true);
    }

}
