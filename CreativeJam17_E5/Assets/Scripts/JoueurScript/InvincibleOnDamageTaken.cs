using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleOnDamageTaken : MonoBehaviour
{
    [SerializeField] private float invincibilityTime;
    [SerializeField] private Collider2D playerHurtbox;

    private SpriteRenderer spriteRenderer;
    private DamageableEntity damageableEntity;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        damageableEntity = GetComponentInChildren<DamageableEntity>();

        damageableEntity.OnHit += PlayerHit;
        damageableEntity.OnRevive += PlayerRevived;
    }

    private void PlayerRevived()
    {
        playerHurtbox.enabled = true;
    }

    private void PlayerHit()
    {
        StartCoroutine(InvincibleFlash());
    }

    private IEnumerator InvincibleFlash()
    {
        // Make invincible
        playerHurtbox.enabled = false;

        // Flash
        float startTime = Time.time;
        float endTime = Time.time + invincibilityTime;
        Color initialColor = Color.white;
        while (endTime > Time.time)
        {
            float current = Time.time - startTime;
            Color color = initialColor;
            float alphaValue = (0.3f * Mathf.Sin((float)(12.5f * (current + Mathf.PI)))) + 0.7f;
            float redValue = (0.3f * Mathf.Sin((float)(11.5f * (current + Mathf.PI)))) + 0.7f;
            Debug.Log(redValue);
            color.a = alphaValue;
            color.g = redValue;
            color.b = redValue;
            spriteRenderer.color = color;
            yield return new WaitForEndOfFrame();
        }
        spriteRenderer.color = initialColor;

        if (damageableEntity.IsAlive())
        {
            // Make un-invincible
            playerHurtbox.enabled = true;
        }

        yield return null;
    }

}
