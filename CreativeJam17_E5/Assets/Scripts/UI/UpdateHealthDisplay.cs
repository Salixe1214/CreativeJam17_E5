using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHealthDisplay : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private Image foreground;

    private DamageableEntity entity;

    private void Awake()
    {
        entity = GameObject.FindGameObjectWithTag("MainCharacter").GetComponentInChildren<DamageableEntity>();

        entity.OnHit += UpdateBar;
        entity.OnRevive += UpdateBar;
    }

    // Update is called once per frame
    private void UpdateBar()
    {
        float percent = entity.GetCurrentHealth() / entity.GetMaxHealth();
        Vector2 size = background.rectTransform.sizeDelta;

        float newWidth = size.x * percent;
        foreground.rectTransform.sizeDelta = new Vector2(newWidth, background.rectTransform.sizeDelta.y);
    }
}
