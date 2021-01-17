using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endOfGameUI : MonoBehaviour
{
    [SerializeField] Text nbDeathUI;
    [SerializeField] Text timeText;
    float timeFloat;

    // Start is called before the first frame update
    void Awake()
    {
        nbDeathUI.text = PlayerPrefs.GetInt("nbDeath").ToString();
        timeFloat = PlayerPrefs.GetFloat("timeGame");

        timeText.text = ((int)timeFloat).ToString() + "s";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
