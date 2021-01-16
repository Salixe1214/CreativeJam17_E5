using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResetTimer : MonoBehaviour
{
    public float resetTimer = 1200;
    public float tempsTotalDeJeu = 0;

    float tempsAjouteEphemere = 0;
    float tempsDeLaSession;

    public GameObject texte;

    public DeathShop deathShop;
    // Start is called before the first frame update
    void Start()
    {
        deathShop.ConfirmBuy += resetTempsApresShop;
    }

    // Update is called once per frame
    void Update()
    {
        tempsDeLaSession = Time.time - tempsTotalDeJeu;
        if (tempsDeLaSession > resetTimer * transform.GetComponent<statisticsGestion>().getTimerModif()
                                                                                + tempsAjouteEphemere)
        {
            float dommage = transform.GetComponent<DamageableEntity>().GetMaxHealth();
            transform.GetComponent<DamageableEntity>().TakeDamage(dommage);
        }

        // L'update du temps sur le UI
        afficherTempsRestant();
    }



    void afficherTempsRestant()
    {
        int secondes = Mathf.FloorToInt((resetTimer * transform.GetComponent<statisticsGestion>().getTimerModif()
                                                                    +   tempsAjouteEphemere - tempsDeLaSession) % 60);
        int minutes = Mathf.FloorToInt((resetTimer * transform.GetComponent<statisticsGestion>().getTimerModif()
                                                                    + tempsAjouteEphemere - tempsDeLaSession) / 60);
        string tempsEnString;
        if (GetComponent<JoueurMouvement>().peutBouger)
        {
            tempsEnString = minutes.ToString() + ":" + secondes.ToString();
        }
        else 
        { 
            tempsEnString = "t'es mort\n maudit \npo bon";
        }
        texte.GetComponent<UnityEngine.UI.Text>().text = tempsEnString;
    }

    void resetTempsApresShop()
    {
        tempsTotalDeJeu += tempsDeLaSession;
        tempsDeLaSession = 0;
    }
}
