using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramassable : MonoBehaviour
{
    public GameObject player;
    enum ramassables {bonusTemps, lance, epee, lancePierre};
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<PlayerDetector>().OnPlayerEnter += fonctionPasFaite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void fonctionPasFaite(GameObject player)
    {

    }
}
