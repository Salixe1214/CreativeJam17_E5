using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    [SerializeField] Canvas menu;

    // Start is called before the first frame update
    void Awake()
    {
        menu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.enabled = true;
            Time.timeScale = 0f;
        }
    }

    public void onRepprendre()
    {
        Time.timeScale = 1f;
        menu.enabled = false;
    }

    public void onQuitter()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }

    public void onMenuPrincipale()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
