using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicMaster : MonoBehaviour
{
    AudioSource source;

    public AudioClip[] SFXLvlUp;
    public AudioClip[] UIHoverSound;

    public DeathShop deathShop;

    bool sonJou;

    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();

        if(source == null)
        {
            Debug.Log("Pas de source audio");
        }

        deathShop.BuyDmg += levelUp;
        deathShop.BuyResist += levelUp;
        deathShop.BuySpeed += levelUp;
        deathShop.BuyTimer += levelUp;

        button.buttunHover += UIHover;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void levelUp()
    {
        if(!sonJou)
        {
            StartCoroutine(playSound(SFXLvlUp[(int)Random.Range(0, SFXLvlUp.Length)]));
        }
    }

    void UIConfirm()
    {

    }

    void UIHover()
    {
        if (!sonJou)
        {
            StartCoroutine(playSound(UIHoverSound[(int)Random.Range(0, UIHoverSound.Length)]));
        }
    }

    void hit()
    {

    }

    IEnumerator playSound(AudioClip clip)
    {
        sonJou = true;
        source.PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length);
        sonJou = false;
    }
}
