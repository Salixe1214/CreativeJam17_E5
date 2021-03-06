﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicMaster : MonoBehaviour
{
    [SerializeField] private AudioSource sourceFX, sourceUI;
    [SerializeField] AudioSource music;

    // UI
    public AudioClip[] hitSoulSound;
    public AudioClip[] stoneSound;
    public AudioClip[] meleeAtkSound;
    public AudioClip[] meleeEquipSound;
    public AudioClip[] meleeHitSound;
    public AudioClip[] arrowHitSound;
    public AudioClip[] rangeEquipSound;
    public AudioClip[] pickUpSound;

    // SFX
    public AudioClip[] SFXLvlUp;
    public AudioClip[] UIHoverSound;
    public AudioClip[] itemBreakSound;
    public AudioClip[] healthDownSound;
    public AudioClip[] HealthUpSound;
    public AudioClip[] UIQuitSound;
    public AudioClip[] UISelectSound;
    public AudioClip[] UITimeLowSound;
    public AudioClip[] unlockDoorSound;

    // Music
    public AudioClip[] musicsLevels;
    public AudioClip shopMusic;
    int lvl = 0;

    public DeathShop deathShop;

    bool sonJou;

    // Start is called before the first frame update
    void Awake()
    {
        if(sourceFX == null || sourceUI == null || music == null)
        {
            Debug.Log("Pas de source audio");
        }

        music.clip = musicsLevels[0];
        music.loop = true;
        music.Play();
    }

    private void OnEnable()
    {
        /// Abonnements pour UI ///

        statisticsGestion.lvlUp += levelUp;

        button.buttunHover += UIHover;

        LingeringAttack.onHit += hitSoul;
        MeleeAttack.onHit += meleeHit;
        ProjectileBehavior.onHit += arrowHit;

        /// Abonnements pour sfx ///
        statisticsGestion.gainExp += pickUpXp;

        Ramassable.onPickUp += pickUpWeapon;

        LevelLogic.onUnlockDoor += unlockDoor;

        // Abonnements pour music
        LevelManager.nextLevel += changeLevel;
        LevelManager.restart += restartLevels;
        MortDuJoueur.openShop += shopOpen;
    }

    private void OnDisable()
    {
        /// Abonnements pour UI ///

        statisticsGestion.lvlUp -= levelUp;

        button.buttunHover -= UIHover;

        LingeringAttack.onHit -= hitSoul;
        MeleeAttack.onHit -= meleeHit;
        ProjectileBehavior.onHit -= arrowHit;

        /// Abonnements pour sfx ///
        statisticsGestion.gainExp -= pickUpXp;

        Ramassable.onPickUp -= pickUpWeapon;

        // Abonnements pour music
        LevelManager.nextLevel -= changeLevel;
        LevelManager.restart -= restartLevels;
        MortDuJoueur.openShop -= shopOpen;
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
    /// 

    void unlockDoor()
    {
        Debug.Log("Door 1");

        playSFXSound(unlockDoorSound);
        Debug.Log("Door 2");
    }

    void hitSoul(GameObject obj)
    {
        Debug.Log("Soul hit");
        playSFXSound(hitSoulSound);
    }

    void stone()
    {
        playSFXSound(stoneSound);
    }

    void meleeAtk()
    {
        playSFXSound(meleeAtkSound);
    }

    void meleeEquip()
    {
        playSFXSound(meleeEquipSound);
    }

    void meleeHit(GameObject obj)
    {
        if(obj.tag == "ghost")
        {
            playSFXSound(hitSoulSound);
        }

        playSFXSound(meleeHitSound);
    }

    void arrowHit(GameObject obj)
    {
        if (obj.tag == "ghost")
        {
            playSFXSound(hitSoulSound);
        }

        playSFXSound(arrowHitSound);
    }

    void rangeEquip()
    {
        playSFXSound(rangeEquipSound);
    }

    void pickUpXp()
    {
        playSFXSound(pickUpSound);
    }

    void pickUpWeapon(string weapon)
    {
        if (weapon == "sword" || weapon == "spear")
            meleeEquip();
        if (weapon == "bow" || weapon == "slingShot")
            rangeEquip();
    }

    /// Music ///
    void changeLevel(int newLvl)
    {
        lvl = newLvl;
        music.clip = musicsLevels[lvl];
        music.Play();
    }

    void restartLevels()
    {
        lvl = 0;
        music.clip = musicsLevels[0];
        music.Play();
    }

    void shopOpen()
    {
        music.clip = shopMusic;
        music.Play();
    }

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
        AudioClip son = clip[(int)Random.Range(0, clip.Length)];
        if(sourceFX != null)
        {
            Debug.Log("Door 4");
            sourceFX.PlayOneShot(son);
            Debug.Log("Door 5");
        }
    }
}
