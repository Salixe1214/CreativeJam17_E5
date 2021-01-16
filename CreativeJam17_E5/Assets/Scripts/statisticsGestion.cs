using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statisticsGestion : MonoBehaviour
{
    enum stats
    {
        Damage,
        Timer,
        Speed,
        Resistence
    }

    int exp;

    // Les stats du perso sont définies par son niveau de stats
    int niv_damages = 1;
    int niv_timer = 1;
    int niv_speed = 1;
    int niv_resistence = 1;

    // Le personnage a 4 statistiques qui modifient ses stats
    float modif_damages = 1;
    float modif_timer = 1;
    float modif_speed = 1;
    float modif_resistence = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Fonction de levelUp de base
    bool levelUp(stats stat)
    {
        int niv;

        switch (stat)
        {
            case stats.Damage:
                niv = niv_damages;
                break;
            case stats.Resistence:
                niv = niv_resistence;
                break;
            case stats.Speed:
                niv = niv_speed;
                break;
            case stats.Timer:
                niv = niv_timer;
                break;
            default:
                niv = 0;
                break;
        }

        if(exp > getLevUpExp(niv))
        {
            // Si le joueur a assé d'exp
            // On lui retire cet exp et augmente le niveau desire
            exp -= getLevUpExp(niv); 
            niv++;

            switch (stat)
            {
                case stats.Damage:
                    niv_damages = niv;
                    modif_damages = getModif(stats.Damage, niv);
                    break;
                case stats.Resistence:
                    niv_resistence = niv;
                    modif_resistence = getModif(stats.Resistence, niv);
                    break;
                case stats.Speed:
                    niv_speed = niv;
                    modif_speed = getModif(stats.Speed, niv);
                    break;
                case stats.Timer:
                    niv_speed = niv;
                    modif_speed = getModif(stats.Speed, niv);
                    break;
                default:
                    break;
            }

            return true;
        }
        else
        {
            Debug.Log("Pas assez d'exp");
            return false;
        }
    }

    int getLevUpExp(int lvl)
    {
        lvl = lvl + 1; // Car on veut L'exp pôur un niveau plus haut

        return (int) Mathf.Ceil((0.04f * (lvl ^ 3)) + (0.8f * (lvl ^ 2)) + (2 * lvl));
    }

    float getModif(stats stat, int niv)
    {
        switch (stat)
        {
            case stats.Damage:
                return niv;
            case stats.Resistence:
                return Mathf.Ceil(1.3f * niv) - 1;
            case stats.Speed:
                return Mathf.Log(niv) + 1;
            case stats.Timer:
                return Mathf.Log(niv ^ 2) + niv;
            default:
                return 0;
        }
    }

    // Getteurs des modificateurs
    public float getDamageModif()
    {
        return modif_damages;
    }

    public float gatTimerModif()
    {
        return modif_timer;
    }
    
    public float getSpeedModif()
    {
        return modif_speed;
    }
    
    public float getResistenceModif()
    {
        return modif_resistence;
    }

    // Getteurs des levels
    public float getDamageLevel()
    {
        return modif_damages;
    }

    public float gatTimerLevel()
    {
        return modif_timer;
    }

    public float getSpeedLevel()
    {
        return modif_speed;
    }

    public float getResistenceLevel()
    {
        return modif_resistence;
    }

    // Getteur de l'exp
    public int getExp()
    {
        return exp;
    }

    // Fonctions pour le UI
    public void onLevelUpDamage()
    {
        levelUp(stats.Damage);
    }

    public void onLevelUpTimer()
    {
        levelUp(stats.Timer);
    }

    public void onLevelUpSpeed()
    {
        levelUp(stats.Speed);
    }

    public void onLevelUpResistence()
    {
        levelUp(stats.Resistence);
    }
}
