using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfficherUI : MonoBehaviour
{

    public Action<GameObject> OnPlayerEnter;
    public Action OnPlayerExit;
    public GameObject afficherCeci;

    // Collides with the root collider
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Only the root object should be tagged like this
        if (collision.gameObject.tag == "MainCharacter")
        {
		afficherCeci.SetActive(true);
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
		afficherCeci.SetActive(false);
            if (OnPlayerExit != null) OnPlayerExit();
        }
    }

}
