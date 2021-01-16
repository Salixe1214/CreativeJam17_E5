﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramassable : MonoBehaviour
{

    enum ramassables {bonusTemps, lance, epee, lancePierre};

    public float bonusTemps = 15;

    public GameObject joueur;

    bool estSurUneEpee = false;
    bool estSurUnArc = false;
    bool estSurUnLancePierre = false;
    bool estSurUneLance = false;

    private void Start()
    {
        joueur = GameObject.FindGameObjectWithTag("MainCharacter");
    }
    void Awake()
    {
        transform.GetComponent<PlayerDetector>().OnPlayerEnter += estSurUnObjet;
        transform.GetComponent<PlayerDetector>().OnPlayerExit += sortDeSurUnObjet;
    }

    // Update is called once per frame
    void Update()
    {
        if(estSurUneEpee)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if(joueur.GetComponent<WeaponSystem>().GetCurrentWeapon() != null)
                {
                    joueur.GetComponent<WeaponSystem>().DropCurrentWeapon();
                }
                joueur.GetComponent<WeaponSystem>().EquipNewSword();
            }
        }
        if(estSurUneLance)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (joueur.GetComponent<WeaponSystem>().GetCurrentWeapon() != null)
                {
                    joueur.GetComponent<WeaponSystem>().DropCurrentWeapon();
                }
                joueur.GetComponent<WeaponSystem>().EquipNewSpear();
            }
        }
        if(estSurUnLancePierre)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (joueur.GetComponent<WeaponSystem>().GetCurrentWeapon() != null)
                {
                    joueur.GetComponent<WeaponSystem>().DropCurrentWeapon();
                }
                joueur.GetComponent<WeaponSystem>().EquipNewSlingshot();
            }
        }
        if(estSurUnArc)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (joueur.GetComponent<WeaponSystem>().GetCurrentWeapon() != null)
                {
                    joueur.GetComponent<WeaponSystem>().DropCurrentWeapon();
                }
                joueur.GetComponent<WeaponSystem>().EquipNewBow();
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