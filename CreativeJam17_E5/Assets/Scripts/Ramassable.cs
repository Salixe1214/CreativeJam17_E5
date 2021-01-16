using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramassable : MonoBehaviour
{
    enum ramassables {bonusTemps, lance, epee, lancePierre};
    public float bonusTemps = 15;

    void Awake()
    {
        transform.GetComponent<PlayerDetector>().OnPlayerEnter += ramasserObjet;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ramasserObjet(GameObject player)
    {
        if (transform.tag == "epee")
        {

            Destroy(gameObject);
        }
        else if (transform.tag == "lancePierre")
        {

            Destroy(gameObject);
        }
        else if (transform.tag == "lance")
        {

            Destroy(gameObject);
        }
        else if (transform.tag == "bonusTemps")
        {
            player.GetComponent<ResetTimer>().tempsAjouteEphemere += bonusTemps;
            Destroy(gameObject);
        }
        else if (transform.tag == "arc")
        {
            Destroy(gameObject);
        }
        else
        {

        }
    }
}
