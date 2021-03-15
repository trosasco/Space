using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public UIController ui;
    public GameObject alienSpawn;
    public GameObject player;
    private GlobalControl glb;

    private int score = 0;
    private int highScore = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        glb = GameObject.Find("Global Control").GetComponent<GlobalControl>();
        highScore = glb.highScore;
        StartCoroutine(startRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addScore(int x)
    {
        score += x;
        ui.updateScore(score);

        if (score > highScore)
        {
            highScore = score;
            glb.highScore = highScore;
            ui.updateHighScore(highScore);
        }
    }

    IEnumerator startRoutine()
    {
        yield return new WaitForSeconds(8f);
        if (alienSpawn != null)
        {
            alienSpawn.gameObject.SetActive(true);
        }

        player.GetComponent<PlayerController>().allowInput = true;
    }

    public void gameOver()
    {
        try
        {
            ui.showGameOver(true);
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }
    }

    public void win()
    {
        try
        {
            ui.showWin(true);
            
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }
    }

    public void restart()
    {
        try
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }
    }
}
