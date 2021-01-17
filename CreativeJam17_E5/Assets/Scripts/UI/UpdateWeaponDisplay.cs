using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateWeaponDisplay : MonoBehaviour
{
    [SerializeField] private Image weaponImage;
    [SerializeField] private TMP_Text durabilityText;
    [SerializeField] private TMP_Text weaponNameText;

    [SerializeField] private WeaponData fistData;

    private WeaponSystem weaponSystem;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("MainCharacter");
        weaponSystem = player.GetComponent<WeaponSystem>();
    }

    private void Start()
    {
        WeaponChanged();
    }

    private void OnEnable()
    {
        weaponSystem.OnWeaponEquipped += WeaponChanged;
        weaponSystem.OnDurabilityUpdated += WeaponChanged;
    }

    private void OnDisable()
    {
        weaponSystem.OnWeaponEquipped -= WeaponChanged;
        weaponSystem.OnDurabilityUpdated -= WeaponChanged;
    }

    private void WeaponChanged()
    {
        Weapon currentWeapon = weaponSystem.GetCurrentWeapon();
        WeaponData data;
        // If we have a weapon
        if (currentWeapon != null)
        {
            data = currentWeapon.weaponData;
            durabilityText.text = currentWeapon.GetDurability().ToString();
        }
        // else, fist display
        else
        {
            data = fistData;
            durabilityText.text = "--";
        }

        weaponImage.sprite = data.UiImage;
        weaponNameText.text = data.Name;

    }
}
