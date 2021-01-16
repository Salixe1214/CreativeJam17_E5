using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public Action<GameObject> OnPlayerEnter;
    public Action OnPlayerExit;

    // Collides with the root collider
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Only the root object should be tagged like this
        if (collision.gameObject.tag == "MainCharacter")
        {
            Debug.Log("Detect!");
            if (OnPlayerEnter != null) OnPlayerEnter(collision.gameObject);
        }
    }

    // Collides with the root collider
    public void OnTriggerExit2D(Collider2D collision)
    {
        // Only the root object should be tagged like this
        if (collision.gameObject.tag == "MainCharacter")
        {
            if (OnPlayerExit != null) OnPlayerExit();
        }
    }
}
