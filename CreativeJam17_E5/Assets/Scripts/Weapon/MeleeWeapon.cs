using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] private GameObject meleeAttack;

    protected override void Attack(float modifier)
    {
        // Spawn attack! It'll do the rest itself.
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        GameObject attackObj = Instantiate(meleeAttack, position, transform.rotation);

        // Calculate attack offset and rotation based on player
        Vector2 realOffset = transform.right * attackOffset.x;
        realOffset += new Vector2((transform.up * attackOffset.y).x, (transform.up * attackOffset.y).y);

        MeleeAttack attack = attackObj.GetComponent<MeleeAttack>();
        attack.Damage = weaponData.AttackDamage * modifier;
        attack.OnAttackHit += OnAttackHit;
        attack.FollowObject(gameObject, realOffset);

        // Subscribe to the hit event!
        base.ResolveAttack();
    }

    protected void OnAttackHit()
    {
        currentDurability--;
        base.UpdateDurability();
    }
}
