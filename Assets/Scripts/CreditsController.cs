using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startMenu());
    }

    IEnumerator startMenu()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("StartMenuScene");
    }
}
