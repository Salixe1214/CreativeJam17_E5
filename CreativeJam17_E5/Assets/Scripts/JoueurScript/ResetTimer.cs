using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResetTimer : MonoBehaviour
{
    public float resetTimer = 1200;
    public float tempsTotalDeJeu = 0;

    public float tempsAjouteEphemere = 0;
    public float tempsDeLaSession;

    public GameObject texte;

    public DeathShop deathShop;

    public float tempsMaximal;

    // Start is called before the first frame update
    void Awake()
    {
        tempsDeLaSession = 0;
        tempsTotalDeJeu = 0;
        deathShop.ConfirmBuy += resetTempsApresShop;
    }

    private void OnEnable()
    {
        LevelManager.onEndGame += endGame;
    }

    private void OnDisable()
    {
        LevelManager.onEndGame -= endGame;
    }

    // Update is called once per frame
    void Update()
    {
        tempsDeLaSession += Time.deltaTime;
        tempsMaximal = resetTimer * transform.GetComponent<statisticsGestion>().getTimerModif() + tempsAjouteEphemere;
        if (tempsDeLaSession > tempsMaximal)
        {
            float dommage = transform.GetComponentInChildren<DamageableEntity>().GetMaxHealth();
            transform.GetComponentInChildren<DamageableEntity>().TakeDamage(dommage);
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

    void endGame()
    {
        Debug.Log(tempsTotalDeJeu + tempsDeLaSession);
        PlayerPrefs.SetFloat("timeGame", tempsTotalDeJeu + tempsDeLaSession);
    }
}
