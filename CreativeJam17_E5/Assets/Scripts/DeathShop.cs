using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathShop : MonoBehaviour
{
    public System.Action BuyDmg;
    public System.Action BuyTimer;
    public System.Action BuySpeed;
    public System.Action BuyResist;
    public System.Action ConfirmBuy;

    public GameObject player;
    statisticsGestion stats;
    DamageableEntity playerDmgEntity;

    public Text xpText, dmgTxt, timerTxt, speedTxt, resistTxt;

    // Start is called before the first frame update
    void Start()
    {
        if (player != null)
        {
            stats = player.GetComponent<statisticsGestion>();
            playerDmgEntity = player.GetComponent<DamageableEntity>();
        }
        else
            Debug.Log("Tu dois passer un player au shop pour qu'il fonctionne! >:(");

        if (stats != null)
        {
            stats.onXpChange += updateXp;
            stats.onDmgUp += updateDmg;
            stats.onResistUp += updateResist;
            stats.onTimerUp += updateTimer;
            stats.onSpeedUp += updateSpeed;
        }
        else
            Debug.Log("Le player n'as pas de statisticGestion.");

        if (playerDmgEntity != null)
        {
            playerDmgEntity.OnDeath += onPlayerDeath;
        }
        else
            Debug.Log("Ton player n'as pas de DamageableEntity!");

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        stats.onXpChange -= updateXp;
        stats.onDmgUp -= updateDmg;
        stats.onResistUp -= updateResist;
        stats.onTimerUp -= updateTimer;
        stats.onSpeedUp -= updateSpeed;

        playerDmgEntity.OnDeath -= onPlayerDeath;
    }

    // Evenements
    public void onBuyDmgClic()
    {
        if(BuyDmg != null)
            BuyDmg.Invoke();
    }

    public void onBuyTimerClic()
    {
        if (BuyTimer != null)
            BuyTimer.Invoke();
    }

    public void onBuySpeedClic()
    {
        if (BuySpeed != null)
            BuySpeed.Invoke();
    }

    public void onBuyResistClic()
    {
        if (BuyResist != null)
            BuyResist.Invoke();
    }

    public void onConfirm()
    {
        if (ConfirmBuy != null)
            ConfirmBuy.Invoke();
        gameObject.SetActive(false);
    }

    void onPlayerDeath()
    {
        gameObject.SetActive(true);
    }

    // Methodes pour updater l'information
    void updateXp(int xp)
    {
        xpText.text = xp.ToString();
    }

    void updateDmg(int lvl)
    {
        dmgTxt.text = lvl.ToString();
    }

    void updateTimer(int lvl)
    {
        timerTxt.text = lvl.ToString();
    }

    void updateSpeed(int lvl)
    {
        speedTxt.text = lvl.ToString();
    }

    void updateResist(int lvl)
    {
        resistTxt.text = lvl.ToString();
    }
}
