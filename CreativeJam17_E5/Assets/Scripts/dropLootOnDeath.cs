using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropLootOnDeath : MonoBehaviour
{
    public DamageableEntity entity;
    public GameObject drop;

    static public System.Action<int> givePlayerXp;

    // Start is called before the first frame update
    void Start()
    {
        entity.OnDeath += dropOnDeath;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void dropOnDeath()
    {
        Instantiate(drop, transform);
        if(givePlayerXp != null)
        {
            givePlayerXp.Invoke((int)Random.Range(1, 10));
        }
    }
}
