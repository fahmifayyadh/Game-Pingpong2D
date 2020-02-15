using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageManager : MonoBehaviour
{
    public bool isEscapeToExit;
    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeToExit)
            {
                Application.Quit();
            }
            else
            {
                BackToMenu();
            }
        }
    }
    public void MulaiMain()
    {
        SceneManager.LoadScene("main");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
