using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortDuJoueur : MonoBehaviour
{
    public ResetTimer timer;
    Vector3 positionInitiale;
    public bool estMort = false;
    // Start is called before the first frame update
    void Start()
    {
        positionInitiale = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        if(estMort && !transform.GetComponent<JoueurMouvement>().peutBouger)
        {
            transform.GetComponent<JoueurMouvement>().peutBouger = false;
        }

        if (!estMort && transform.GetComponent<JoueurMouvement>().peutBouger)
        {
            transform.GetComponent<JoueurMouvement>().peutBouger = true;
        }
    }
}
