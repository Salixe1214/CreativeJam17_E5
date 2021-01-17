using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarreDeTemps : MonoBehaviour
{
    public GameObject player;
    Image barreDeTemps;
    // Start is called before the first frame update
    void Start()
    {
        barreDeTemps = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        float resetTimer = player.GetComponent<ResetTimer>().resetTimer;
        float tempsAjouteEphemere = player.GetComponent<ResetTimer>().tempsAjouteEphemere;
        float tempsDeLaSession = player.GetComponent<ResetTimer>().tempsDeLaSession;
        Debug.Log(1-(resetTimer/tempsDeLaSession));

        if (tempsDeLaSession < resetTimer * player.GetComponent<statisticsGestion>().getTimerModif()
                                                                                    + tempsAjouteEphemere)
        {
            Debug.Log("ici");
            barreDeTemps.fillAmount = (1-(tempsDeLaSession / resetTimer * player.GetComponent<statisticsGestion>().getTimerModif() + tempsAjouteEphemere)+0.087f);
        }
    }
}
