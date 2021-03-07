using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text gameOver;
    public Text restart;
    public Text win;
    
    // Start is called before the first frame update
    void Start()
    {
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
}
