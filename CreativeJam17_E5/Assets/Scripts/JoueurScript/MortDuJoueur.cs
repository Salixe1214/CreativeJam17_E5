using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortDuJoueur : MonoBehaviour
{
    Vector3 positionInitiale;
    bool pause = false;
    public DeathShop deathShop;

    public System.Action openShop;

    // Start is called before the first frame update
    void Start()
    {
        positionInitiale = transform.position;
        transform.GetComponentInChildren<DamageableEntity>().OnDeath += joueurMeurt;
        deathShop.ConfirmBuy += joueurRevivu;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void joueurMeurt()
    {   
        transform.GetComponent<JoueurMouvement>().peutBouger = false;
        StartCoroutine(attendreTroisSecondes());
    }

    void joueurRevivu()
    {
        transform.GetComponent<JoueurMouvement>().peutBouger = true;
        GetComponentInChildren<DamageableEntity>().Revive();
    }

    IEnumerator attendreTroisSecondes()
    {
        yield return new WaitForSeconds(3);
        transform.position = positionInitiale;
        if(openShop != null)
        {
            openShop.Invoke();
        }
    }
}
