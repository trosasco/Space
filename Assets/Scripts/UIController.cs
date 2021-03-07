using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text gameOver;
    public Text restart;
    public Text win;
    public Text score;
    public Text table;
    public Text highScore;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(showPointsTable());
        gameOver.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        win.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showGameOver(bool x)
    {
        gameOver.gameObject.SetActive(x);
        restart.gameObject.SetActive(x);
    }

    public void showWin(bool x)
    {
        win.gameObject.SetActive(x);
        restart.gameObject.SetActive(x);
    }

    public void updateScore(int x)
    {
        string zeros = "";
        if (x < 10)
        {
            zeros = "000";
        } else if (x < 100)
        {
            zeros = "00";
        } else if (x < 1000)
        {
            zeros = "0";
        }
        score.text = zeros + x;
    }

    public void updateHighScore(int x)
    {
        string zeros = "";
        if (x < 10)
        {
            zeros = "000";
        } else if (x < 100)
        {
            zeros = "00";
        } else if (x < 1000)
        {
            zeros = "0";
        }
        highScore.text = zeros + x;
    }
    
    IEnumerator showPointsTable()
    {
        table.gameObject.SetActive(true);
        yield return new WaitForSeconds(8f);

        table.gameObject.SetActive(false);
    }
}
