using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endOfGameUI : MonoBehaviour
{
    [SerializeField] Text nbDeathUI;

    // Start is called before the first frame update
    void Awake()
    {
        nbDeathUI.text = PlayerPrefs.GetInt("nbDeath").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
