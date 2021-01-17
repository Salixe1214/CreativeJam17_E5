using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    [SerializeField] private float movementAcceleration;
    [SerializeField] private float velocityCap;

    private PlayerDetector playerDetector;
    private Rigidbody2D movementBody;
    private DamageableEntity damageable;

    private Vector2 respawnPoint;

    // Player object, unless we chase something else for some reason
    private GameObject toChase;

    private void Awake()
    {
        respawnPoint = transform.position;
        movementBody = GetComponent<Rigidbody2D>();
        damageable = GetComponentInChildren<DamageableEntity>();
        playerDetector = GetComponentInChildren<PlayerDetector>();

        damageable.OnRevive += Respawn;
        playerDetector.OnPlayerEnter += OnPlayerDetected;
    }

    private void OnDestroy()
    {
        playerDetector.OnPlayerEnter -= OnPlayerDetected;
    }

    // The player has entered our detection field
    private void OnPlayerDetected(GameObject player)
    {
        // Chase to death
        toChase = player;
    }

    private void Update()
    {
        // If we detected the player
        if (toChase)
        {
            // Move towards it faster and faster
            Vector2 force = (toChase.transform.position - transform.position).normalized;
            movementBody.AddForce(force * movementAcceleration * Time.deltaTime, ForceMode2D.Force);

            // Cap at a certain speed
            movementBody.velocity = Vector2.ClampMagnitude(movementBody.velocity, velocityCap);
        }
    }

    public void Respawn()
    {
        // Reset chase
        toChase = null;
        transform.position = respawnPoint;
    }
}
