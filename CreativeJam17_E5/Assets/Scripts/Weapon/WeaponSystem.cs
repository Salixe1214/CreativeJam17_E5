using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    // Current weapon!
    [SerializeField] private GameObject TestWeaponRef;
    private GameObject currentWeaponObj;
    private Weapon currentWeapon;

    // Hands are a melee weapon, after all.
    [SerializeField] private GameObject handsWeaponRef;
    private GameObject handsWeaponObj;
    private MeleeWeapon handsWeapon;

    public Action OnWeaponEquipped;

    private void Awake()
    {
        // Instantiate hands object
        handsWeaponObj = Instantiate(handsWeaponRef, this.transform);
        handsWeaponObj.transform.localPosition = new Vector3(0, 0, 0);
        handsWeapon = handsWeaponObj.GetComponent<MeleeWeapon>();

        // Instantiate hands object
        GameObject testweapon = Instantiate(TestWeaponRef, this.transform);
        testweapon.transform.localPosition = new Vector3(0, 0, 0);
        EquipWeapon(testweapon);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    public void EquipWeapon(GameObject newWeapon)
    {
        // Can only equip a weapon if it doesn't have one
        if (!currentWeaponObj)
        {
            currentWeaponObj = newWeapon;
            currentWeapon = currentWeaponObj.GetComponent<Weapon>();
            currentWeapon.OnWeaponBroken += WeaponBroken;

            if (OnWeaponEquipped != null) OnWeaponEquipped.Invoke();
        }
    }

    private void WeaponBroken()
    {
        Debug.Log("BOKEN");
        currentWeapon.OnWeaponBroken -= WeaponBroken;
        currentWeapon = null;
        currentWeaponObj = null;
    }

    public void Attack()
    {
        if (currentWeapon)
        {
            currentWeapon.AttemptAttack();
        }
        else
        {
            // Attack with your hands!
            handsWeapon.AttemptAttack();
        }
    }
}
