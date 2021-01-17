using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    [SerializeField] private string SceneName;

    public Canvas control, hud;

    private void Awake()
    {
        if(control != null)
        {
            control.enabled = false;
        }
        if(hud != null)
        {
            hud.enabled = false;
        }
    }

    public void OnClick()
    {
        SceneManager.LoadScene(SceneName);
    }
    
    public void QuitterJeu()
    {
        Application.Quit();
    }

    public void onTuto(int step)
    {
        if(step == 0)
        {
            control.enabled = true;
        }
        if(step == 1)
        {
            control.enabled = false;
            hud.enabled = true;
        }
        if(step == 2)
        {
            hud.enabled = false;
        }
    }

}
