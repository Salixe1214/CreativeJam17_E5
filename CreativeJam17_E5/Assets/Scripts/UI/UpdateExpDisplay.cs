using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateExpDisplay : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text xpText;
    private statisticsGestion stats;

    private void Awake()
    {
        stats = GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<statisticsGestion>();

        stats.onXpChange += ExpChanged;
        ExpChanged(stats.getExp());
    }

    private void ExpChanged(int obj)
    {
        xpText.text = obj.ToString();
    }
}
