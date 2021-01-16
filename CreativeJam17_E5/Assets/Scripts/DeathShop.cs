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

    public Text xpText, dmgTxt, timerTxt, speedTxt, resistTxt;

    // Start is called before the first frame update
    void Start()
    {
        statisticsGestion.onXpChange += updateXp;
        statisticsGestion.onDmgUp += updateDmg;
        statisticsGestion.onResistUp += updateResist;
        statisticsGestion.onTimerUp += updateTimer;
        statisticsGestion.onSpeedUp += updateSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        statisticsGestion.onXpChange -= updateXp;
        statisticsGestion.onDmgUp -= updateDmg;
        statisticsGestion.onResistUp -= updateResist;
        statisticsGestion.onTimerUp -= updateTimer;
        statisticsGestion.onSpeedUp -= updateSpeed;
    }

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
