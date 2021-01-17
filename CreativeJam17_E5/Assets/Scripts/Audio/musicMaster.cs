using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicMaster : MonoBehaviour
{
    public AudioSource sourceFX, sourceUI, music;

    public AudioClip[] hitSoulSound;
    public AudioClip[] stoneSound;
    public AudioClip[] meleeAtkSound;
    public AudioClip[] meleeEquipSound;
    public AudioClip[] meleeHitSound;
    public AudioClip[] arrowHitSound;
    public AudioClip[] rangeEquipSound;
    public AudioClip[] pickUpSound;

    public AudioClip[] SFXLvlUp;
    public AudioClip[] UIHoverSound;
    public AudioClip[] itemBreakSound;
    public AudioClip[] healthDownSound;
    public AudioClip[] HealthUpSound;
    public AudioClip[] UIQuitSound;
    public AudioClip[] UISelectSound;
    public AudioClip[] UITimeLowSound;

    public DeathShop deathShop;

    bool sonJou;

    // Start is called before the first frame update
    void Awake()
    {
        if(sourceFX == null || sourceUI == null || music == null)
        {
            Debug.Log("Pas de source audio");
        }

        /// Abonnements pour UI ///
        
        statisticsGestion.lvlUp += levelUp;
        statisticsGestion.gainExp += pickUp;

        button.buttunHover += UIHover;

        LingeringAttack.onHit += hitSoul;
        MeleeAttack.onHit += meleeHit;
        ProjectileBehavior.onHit += arrowHit;

        /// Abonnements pour sfx ///
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// UI ///
    void levelUp()
    {
        if(!sonJou)
        {
            StartCoroutine(playUISound(SFXLvlUp));
        }
    }

    void UIConfirm()
    {
        if (!sonJou)
        {
            StartCoroutine(playUISound(UISelectSound));
        }
    }

    void UIHover()
    {
        if (!sonJou)
        {
            StartCoroutine(playUISound(UIHoverSound));
        }
    }

    void itemBreak()
    {
        if (!sonJou)
        {
            StartCoroutine(playUISound(itemBreakSound));
        }
    }

    void healthDown()
    {
        if (!sonJou)
        {
            StartCoroutine(playUISound(healthDownSound));
        }
    }

    void healthUp()
    {
        if (!sonJou)
        {
            StartCoroutine(playUISound(HealthUpSound));
        }
    }

    void UIQuit()
    {
        if (!sonJou)
        {
            StartCoroutine(playUISound(UIQuitSound));
        }
    }

    void UITimeLow()
    {
        if (!sonJou)
        {
            StartCoroutine(playUISound(UITimeLowSound));
        }
    }

    /// SFX ///

    void hitSoul(GameObject obj)
    {
        if (!sonJou)
        {
            StartCoroutine(playUISound(hitSoulSound));
        }
    }

    void stone()
    {
        if (!sonJou)
        {
            StartCoroutine(playUISound(stoneSound));
        }
    }

    void meleeAtk()
    {
        if (!sonJou)
        {
            StartCoroutine(playUISound(meleeAtkSound));
        }
    }

    void meleeEquip()
    {
        if (!sonJou)
        {
            StartCoroutine(playUISound(meleeEquipSound));
        }
    }

    void meleeHit(GameObject obj)
    {
        if (!sonJou)
        {
            StartCoroutine(playUISound(meleeHitSound));
        }
    }

    void arrowHit(GameObject obj)
    {
        if (!sonJou)
        {
            StartCoroutine(playUISound(arrowHitSound));
        }
    }

    void rangeEquip()
    {
        if (!sonJou)
        {
            StartCoroutine(playUISound(rangeEquipSound));
        }
    }

    void pickUp()
    {
        if (!sonJou)
        {
            StartCoroutine(playUISound(pickUpSound));
        }
    }

    /// Music ///


    /// PlaySound ///

    IEnumerator playUISound(AudioClip[] clip)
    {
        sonJou = true;
        AudioClip son = clip[(int)Random.Range(0, clip.Length)];
        sourceUI.PlayOneShot(son);
        yield return new WaitForSeconds(son.length);
        sonJou = false;
    }

    void playSFXSound(AudioClip[] clip)
    {
        sourceFX.PlayOneShot(clip[(int)Random.Range(0, meleeAtkSound.Length)]);
    }
}
