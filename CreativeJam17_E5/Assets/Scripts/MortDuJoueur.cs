using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortDuJoueur : MonoBehaviour
{
    public ResetTimer timer;
    Vector3 positionInitiale;
    bool pause = false;
    // Start is called before the first frame update
    void Start()
    {
        positionInitiale = transform.position;
        transform.GetComponent<DamageableEntity>().OnDeath += joueurMeurt;
        transform.GetComponent<DamageableEntity>().OnRevive += joueurRevivu;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void joueurMeurt()
    {
        Debug.Log("meurt");
        if (!transform.GetComponent<DamageableEntity>().IsAlive() && transform.GetComponent<JoueurMouvement>().peutBouger)
        {
            transform.GetComponent<JoueurMouvement>().peutBouger = false;
        }
        StartCoroutine(attendreTroisSecondes());
    }

    void joueurRevivu()
    {
        if (transform.GetComponent<DamageableEntity>().IsAlive() && !transform.GetComponent<JoueurMouvement>().peutBouger)
        {
            transform.GetComponent<JoueurMouvement>().peutBouger = true;
        }
    }

    IEnumerator attendreTroisSecondes()
    {
        yield return new WaitForSeconds(3);
        transform.position = positionInitiale;
    }
}
