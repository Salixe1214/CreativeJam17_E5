using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MortDuJoueur : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    private float fadeDuration = 3;

    Vector3 positionInitiale;
    public DeathShop deathShop;

    static public System.Action openShop;

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
        StartCoroutine(delaiMort());
    }

    void joueurRevivu()
    {
        StartCoroutine(revivu());
    }

    IEnumerator delaiMort()
    {
        // Fade to black
        float fadeStartTime = Time.time;
        float fadeEndTime = fadeStartTime + fadeDuration;
        while (Time.time < fadeEndTime)
        {
            Color fadeColor = fadeImage.color;
            fadeColor.a = (Time.time - fadeStartTime) / (fadeEndTime - fadeStartTime); 
            fadeImage.color = fadeColor;
            yield return new WaitForEndOfFrame();
        }

        transform.position = positionInitiale;
        if(openShop != null)
        {
            openShop.Invoke();
        }
        yield return null;
    }

    IEnumerator revivu()
    {
        GetComponentInChildren<DamageableEntity>().Revive();

        // Unfade from black
        float fadeStartTime = Time.time;
        float fadeEndTime = fadeStartTime + fadeDuration;
        while (Time.time < fadeEndTime)
        {
            Color fadeColor = fadeImage.color;
            fadeColor.a = 1 - ((Time.time - fadeStartTime) / (fadeEndTime - fadeStartTime));
            fadeImage.color = fadeColor;
            yield return new WaitForEndOfFrame();
        }

        transform.GetComponent<JoueurMouvement>().peutBouger = true;
        yield return null;
    }
}
