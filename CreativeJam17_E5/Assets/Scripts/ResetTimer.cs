using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResetTimer : MonoBehaviour
{
    public float resetTimer = 1200;
    public float tempsTotalDeJeu = 0;

    float tempsDeLaSession;

    public GameObject texte;

    public UnityEvent LaPresqueMortDuJoueur;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempsDeLaSession = Time.time - tempsTotalDeJeu;
        if (tempsDeLaSession > resetTimer)
        {
            LaPresqueMortDuJoueur.Invoke();
            tempsTotalDeJeu += tempsDeLaSession;
            tempsDeLaSession = 0;
        }

        // L'update du temps sur le UI
        afficherTempsRestant();
    }


    void afficherTempsRestant()
    {
        int secondes = Mathf.FloorToInt((resetTimer - tempsDeLaSession) % 60);
        int minutes = Mathf.FloorToInt((resetTimer - tempsDeLaSession) / 60);
        string tempsEnString = minutes.ToString() + ":" + secondes.ToString();
        texte.GetComponent<UnityEngine.UI.Text>().text = tempsEnString;
    }
}
