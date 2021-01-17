using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteFlashOnHit : MonoBehaviour
{
    [SerializeField] private SpriteRenderer toFlash;
    [SerializeField] private float flashDuration;

    private DamageableEntity damageable;

    private float currentFlashTime = 0;
    private float endFlashTime = 0;
    private float startFlashTime = 0;
    private bool flashing;

    private void Awake()
    {
        toFlash.enabled = false;
        damageable = GetComponent<DamageableEntity>();
        damageable.OnHit += OnHit;
    }

    private void Update()
    {
        if (flashing)
        {
            currentFlashTime = Time.time;
            float flashPercent = (currentFlashTime - endFlashTime) / (startFlashTime - endFlashTime);

            Color flashColor = toFlash.color;
            flashColor.a = flashPercent;
            toFlash.color = flashColor;
            if (currentFlashTime > endFlashTime)
            {
                flashing = false;
                toFlash.enabled = false;
            }
        }
    }

    private void OnHit()
    {
        flashing = true;
        toFlash.enabled = true;

        startFlashTime = Time.time;
        endFlashTime = Time.time + flashDuration;
    }
}
