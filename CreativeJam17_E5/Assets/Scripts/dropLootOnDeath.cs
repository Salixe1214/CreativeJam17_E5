using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropLootOnDeath : MonoBehaviour
{
    // l'entite qui va drop
    public DamageableEntity entity;

    // Prefab des objets a drop
    public GameObject timeBonus;
    public GameObject[] weapons; // liste contenant toutes les armes

    // definira le nombre de drops
    int nbrDrops;

    // contiendras l'objet à drop
    GameObject drop;

    static public System.Action<int> givePlayerXp;

    // Start is called before the first frame update
    void Awake()
    {
        entity.OnDeath += dropOnDeath;

        nbrDrops = weapons.Length + 1; // le nombre d'armes + le bonus de temps
    }

    // Update is called once per frame
    void Update()
    {
    }

    void dropOnDeath()
    {
        drop = chooseDrop();
        if(drop!=null)
            Instantiate(drop, transform.position, transform.rotation);
        if(givePlayerXp != null)
        {
            givePlayerXp.Invoke((int)Random.Range(1, 10));
        }
    }

    GameObject chooseDrop()
    {
        switch((int)Random.Range(0, 6))
        {
            case 1:
                return timeBonus;
            case 2:
                return weapons[(int)Random.Range(0, weapons.Length)];
            case 3:
                return weapons[(int)Random.Range(0, weapons.Length)];
            default:
                return null;
        }
    }
}
