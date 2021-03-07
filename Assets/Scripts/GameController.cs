using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text gameOver;
    public Text restart;
    public Text win;

    public static bool playerDead = false;
    
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
        if (playerDead)
        {
            Time.timeScale = 0;
            gameOver.gameObject.SetActive(true);
            restart.gameObject.SetActive(true);
        }
    }

}
