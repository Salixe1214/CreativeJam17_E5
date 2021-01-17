using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endOfGameUI : MonoBehaviour
{
    [SerializeField] Text nbDeathUI;
    [SerializeField] Text timeText;
    [SerializeField] Text niveauDegat;
    [SerializeField] Text niveauResistance;
    [SerializeField] Text niveauVitesse;
    [SerializeField] Text niveauTemps;
    float timeFloat;

    // Start is called before the first frame update
    void Awake()
    {
        nbDeathUI.text = PlayerPrefs.GetInt("nbDeath").ToString();
        timeFloat = PlayerPrefs.GetFloat("timeGame");
        niveauDegat.text = PlayerPrefs.GetInt("niveauDegat").ToString();
        niveauResistance.text = PlayerPrefs.GetInt("niveauResistance").ToString();
        niveauTemps.text = PlayerPrefs.GetInt("niveauTemps").ToString();
        niveauVitesse.text = PlayerPrefs.GetInt("niveauVitesse").ToString();

        timeText.text = ((int)timeFloat).ToString() + "s";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
