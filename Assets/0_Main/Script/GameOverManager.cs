using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject UICanvas;
    public GameObject gameOverCanvas;

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("0_Menu");
    }


    public void GameOver()
    {
        Time.timeScale = 0f;
        UICanvas.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(true);
    }
}
