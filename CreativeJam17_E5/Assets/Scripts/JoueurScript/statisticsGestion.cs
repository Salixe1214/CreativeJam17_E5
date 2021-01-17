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

    int exp = 1000;
    
    // Le deathShop auquel on abonne le levelUping
    public DeathShop deatShop;

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

    // Event lorsque l'exp est update
    public System.Action<int> onXpChange;
    public System.Action<int> onDmgUp;
    public System.Action<int> onTimerUp;
    public System.Action<int> onSpeedUp;
    public System.Action<int> onResistUp;

    static public System.Action lvlUp;
    static public System.Action gainExp;

    // Start is called before the first frame update
    void Start()
    {
        if (deatShop != null)
        {
            deatShop.BuyDmg += onLevelUpDamage;
            deatShop.BuyResist += onLevelUpResistence;
            deatShop.BuySpeed += onLevelUpSpeed;
            deatShop.BuyTimer += onLevelUpTimer;
        }
        else
            Debug.Log("T'as pas mis le deathShop dans ton player\n C'est pour ça ça marche pas :(");

        if (onXpChange != null)
            onXpChange.Invoke(exp);

        if (onDmgUp != null)
            onDmgUp.Invoke(niv_damages);
        if (onSpeedUp != null)
            onSpeedUp.Invoke(niv_speed);
        if (onTimerUp != null)
            onTimerUp.Invoke(niv_timer);
        if (onResistUp != null)
            onResistUp.Invoke(niv_resistence);

        dropLootOnDeath.givePlayerXp += onAddExp;
    }

    private void OnDestroy()
    {
        if(deatShop != null)
        {
            deatShop.BuyDmg -= onLevelUpDamage;
            deatShop.BuyResist -= onLevelUpResistence;
            deatShop.BuySpeed -= onLevelUpSpeed;
            deatShop.BuyTimer -= onLevelUpTimer;
        }
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
            if(lvlUp != null)
            {
                lvlUp.Invoke();
            }

            // Si le joueur a assé d'exp
            // On lui retire cet exp et augmente le niveau desire
            exp -= getLevUpExp(niv);
            if (onXpChange != null)
                onXpChange.Invoke(exp);
            niv++;

            switch (stat)
            {
                case stats.Damage:
                    niv_damages = niv;
                    modif_damages = getModif(stats.Damage, niv);
                    if (onDmgUp != null)
                        onDmgUp.Invoke(niv_damages);
                    break;
                case stats.Resistence:
                    niv_resistence = niv;
                    modif_resistence = getModif(stats.Resistence, niv);
                    if (onResistUp != null)
                        onResistUp.Invoke(niv_resistence);
                    break;
                case stats.Speed:
                    niv_speed = niv;
                    modif_speed = getModif(stats.Speed, niv);
                    if (onSpeedUp != null)
                        onSpeedUp.Invoke(niv_speed);
                    break;
                case stats.Timer:
                    niv_timer = niv;
                    modif_timer = getModif(stats.Timer, niv);
                    if (onTimerUp != null)
                        onTimerUp.Invoke(niv_timer);
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

    public int getLevUpExp(int lvl)
    {
        lvl = lvl + 1; // Car on veut l'exp pour un niveau plus haut
        if (lvl > 5)
            return 10000000;

        return (int) Mathf.Ceil((0.04f * (Mathf.Pow(lvl, 3))) + (0.8f * (Mathf.Pow(lvl, 2))) + (2 * lvl));
    }

    float getModif(stats stat, int niv)
    {
        switch (stat)
        {
            case stats.Damage:
                return niv;
            case stats.Resistence:
                return Mathf.Log10(Mathf.Pow(niv, 1.5f));
            case stats.Speed:
                return Mathf.Log10(niv) + 1;
            case stats.Timer:
                return Mathf.Ceil(1.3f * niv) - 1;
            default:
                return 0;
        }
    }

    // Getteurs des modificateurs
    public float getDamageModif()
    {
        return modif_damages;
    }

    public float getTimerModif()
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

    public float getModifExternal(int stat)
    {
        switch (stat)
        {
            case (int)stats.Damage:
                return getDamageModif();
            case (int)stats.Resistence:
                return getResistenceModif();
            case (int)stats.Speed:
                return getSpeedModif();
            case (int)stats.Timer:
                return getTimerModif();
            default:
                return 0f;
        }
    }

    // Getteurs des levels
    public float getDamageLevel()
    {
        return niv_damages;
    }

    public float getTimerLevel()
    {
        return niv_timer;
    }

    public float getSpeedLevel()
    {
        return niv_speed;
    }

    public float getResistenceLevel()
    {
        return niv_resistence;
    }

    public float getLvl(int stat)
    {
        switch (stat)
        {
            case (int) stats.Damage:
                return getDamageLevel();
            case (int) stats.Resistence:
                return getResistenceLevel();
            case (int) stats.Speed:
                return getSpeedLevel();
            case (int) stats.Timer:
                return getTimerLevel();
            default:
                return 0f;
        }
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


    public void onAddExp(int xp)
    {
        exp += xp;
        if (gainExp != null)
            gainExp.Invoke();
        if (onXpChange != null)
            onXpChange.Invoke(exp);
    }
}
