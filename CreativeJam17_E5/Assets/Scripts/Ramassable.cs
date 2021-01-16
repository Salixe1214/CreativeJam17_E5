using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramassable : MonoBehaviour
{
    enum ramassables {bonusTemps, lance, epee, lancePierre};
    public float bonusTemps = 15;
    bool estSurUneEpee = false;
    bool estSurUnArc = false;
    bool estSurUnLancePierre = false;
    bool estSurUneLance = false;

    void Awake()
    {
        transform.GetComponent<PlayerDetector>().OnPlayerEnter += estSurUnObjet;
        transform.GetComponent<PlayerDetector>().OnPlayerExit += sortDeSurUnObjet;
    }

    // Update is called once per frame
    void Update()
    {
        while (estSurUneEpee)
        {
            if (Input.GetMouseButtonDown(0))
            {

            }
        }
        while (estSurUneLance)
        {
            if (Input.GetMouseButtonDown(0))
            {

            }
        }
        while (estSurUnLancePierre)
        {
            if (Input.GetMouseButtonDown(0))
            {

            }
        }
        while (estSurUnArc)
        {
            if (Input.GetMouseButtonDown(0))
            {

            }
        }
    }

    void estSurUnObjet(GameObject player)
    {
        if (transform.tag == "epee")
        {
            estSurUneEpee = true;
        }
        else if (transform.tag == "lancePierre")
        {
            estSurUnLancePierre = true;
        }
        else if (transform.tag == "lance")
        {
            estSurUneLance = true;
        }
        else if (transform.tag == "bonusTemps")
        {
            player.GetComponent<ResetTimer>().tempsAjouteEphemere += bonusTemps;
            Destroy(gameObject);
        }
        if (transform.tag == "epee")
        {
            estSurUneEpee = true;
        }
    }

    void sortDeSurUnObjet()
    {
        estSurUneEpee = false;
        estSurUnArc = false;
        estSurUnLancePierre = false;
        estSurUneLance = false;
    }
}
