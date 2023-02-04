using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject titlePanel;
    public GameObject menuPanel;
    public GameObject creditsPanel;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //Hide title page and show menu
            titlePanel.gameObject.SetActive(false);
            menuPanel.gameObject.SetActive(true);
        }
    }

    public void Pause()
    {
        Debug.Log("Pause");
        Time.timeScale = 0f;
    }


    public void Play()
    {
        SceneManager.LoadScene("1_Main");
    }

    public void Credits()
    {
        menuPanel.gameObject.SetActive(false);
        creditsPanel.gameObject.SetActive(true);
    }

    public void Back()
    {
        creditsPanel.gameObject.SetActive(false);
        menuPanel.gameObject.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
