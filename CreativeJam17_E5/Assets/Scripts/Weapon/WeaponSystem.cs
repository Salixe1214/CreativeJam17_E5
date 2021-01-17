using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [Header("Weapon Prefabs")]
    [SerializeField] private GameObject SwordRef;
    [SerializeField] private GameObject SpearRef;
    [SerializeField] private GameObject BowRef;
    [SerializeField] private GameObject SlingshotRef;

    // Current weapon!
    [SerializeField] private GameObject TestWeaponRef;
    private GameObject currentWeaponObj;
    private Weapon currentWeapon;

    // Hands are a melee weapon, after all.
    [SerializeField] private GameObject handsWeaponRef;
    private GameObject handsWeaponObj;
    private MeleeWeapon handsWeapon;

    [Header("Anims")]
    [SerializeField] private GameObject WeaponBreakAnim;

    public Action OnWeaponEquipped;

    public Animator animator;

    private DamageableEntity damageable;

    private void Awake()
    {
        // Instantiate hands object
        handsWeaponObj = Instantiate(handsWeaponRef, this.transform);
        handsWeaponObj.transform.localPosition = new Vector3(0, 0, 0);
        handsWeapon = handsWeaponObj.GetComponent<MeleeWeapon>();

        // Instantiate hands object
        if (TestWeaponRef)
        {
            GameObject testweapon = Instantiate(TestWeaponRef, this.transform);
            testweapon.transform.localPosition = new Vector3(0, 0, 0);
            EquipWeapon(testweapon);
        }

        damageable = GetComponentInChildren<DamageableEntity>();
        damageable.OnDeath += DropCurrentWeapon;
    }

    private void Update()
    {
        if (transform.GetComponent<JoueurMouvement>().peutBouger)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
            }
        }
    }

    public void EquipWeapon(GameObject newWeapon)
    {
        // Can only equip a weapon if it doesn't have one
        if (!currentWeaponObj)
        {
            currentWeaponObj = newWeapon;
            currentWeapon = currentWeaponObj.GetComponent<Weapon>();
            currentWeapon.OnWeaponBroken += BreakWeapon;

            if (OnWeaponEquipped != null) OnWeaponEquipped.Invoke();
        }
    }

    private void BreakWeapon()
    {
        Destroy(currentWeapon);
        Instantiate(WeaponBreakAnim, new Vector3(transform.position.x, transform.position.y, 0.9f), Quaternion.identity);

        currentWeapon = null;
        currentWeaponObj = null;
    }

    public void Attack()
    {
        if (currentWeapon)
        {
            currentWeapon.AttemptAttack();
            animator.SetBool("ZoeAttack", true);
            StartCoroutine(DeactivateAttackAnimation());
        }
        else
        {
            // Attack with your hands!
            handsWeapon.AttemptAttack();
            animator.SetBool("ZoeAttack", true);
            StartCoroutine(DeactivateAttackAnimation());
        }
    }

    public Weapon GetCurrentWeapon()
    {
        return currentWeapon;
    }

    // Destroys it
    public void DropCurrentWeapon()
    {
        BreakWeapon();
    }

    public void EquipNewSword()
    {
        // Instantiate hands object
        GameObject newWeapon = Instantiate(SwordRef, this.transform);
        newWeapon.transform.localPosition = new Vector3(0, 0, 0);
        EquipWeapon(newWeapon);
    }

    public void EquipNewSpear()
    {
        // Instantiate hands object
        GameObject newWeapon = Instantiate(SpearRef, this.transform);
        newWeapon.transform.localPosition = new Vector3(0, 0, 0);
        EquipWeapon(newWeapon);
    }

    public void EquipNewSlingshot()
    {
        // Instantiate hands object
        GameObject newWeapon = Instantiate(SlingshotRef, this.transform);
        newWeapon.transform.localPosition = new Vector3(0, 0, 0);
        EquipWeapon(newWeapon);
    }

    public void EquipNewBow()
    {
        // Instantiate hands object
        GameObject newWeapon = Instantiate(BowRef, this.transform);
        newWeapon.transform.localPosition = new Vector3(0, 0, 0);
        EquipWeapon(newWeapon);
    }

    private IEnumerator DeactivateAttackAnimation()
    {
        if (currentWeapon)
        {
            yield return new WaitForSeconds(currentWeapon.weaponData.CooldownSeconds);
        }
        else
        {
            yield return new WaitForSeconds(handsWeapon.weaponData.CooldownSeconds);
        }
        animator.SetBool("ZoeAttack", false);
    }
}
