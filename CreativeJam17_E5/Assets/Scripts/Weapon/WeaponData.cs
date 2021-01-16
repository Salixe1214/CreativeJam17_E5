using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData : ScriptableObject
{
    [Header("UI properties")]
    public string Name;
    public Sprite UiImage;

    [Header("Weapon properties")]
    public int Durability; // Amount of attacks possible
    public bool Breakable = true;
    public int AttackDamage; // Damage per attack
    public float CooldownSeconds = 0.5f; // To prevent rapidfire, in seconds.
}
