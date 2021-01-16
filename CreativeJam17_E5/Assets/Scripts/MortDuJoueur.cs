using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortDuJoueur : MonoBehaviour
{
    public ResetTimer timer;
    Vector3 positionInitiale;
    // Start is called before the first frame update
    void Start()
    {
        positionInitiale = transform.position;
        timer.LaMortDuJoueur.AddListener(laMortDuJoueur);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void laMortDuJoueur()
    {
        transform.position = positionInitiale;
    }
}
