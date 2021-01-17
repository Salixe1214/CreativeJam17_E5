﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHudToggler : MonoBehaviour
{
    private DeathShop shop;
    private MortDuJoueur death;

    private void Awake()
    {
        shop = FindObjectOfType<DeathShop>();
        death = GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<MortDuJoueur>();

        shop.ConfirmBuy += OpenHud;
        death.openShop += CloseHud;
    }

    private void OpenHud()
    {
        ActivateHud(true);
    }

    private void CloseHud()
    {
        ActivateHud(false);
    }

    private void ActivateHud(bool shouldActive)
    {
        gameObject.SetActive(shouldActive);
    }
}
