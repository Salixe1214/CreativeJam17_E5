using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testUi : MonoBehaviour
{
    const int nbStats = 4;

    public Text[] lvl;
    public Text[] dmg;
    public Text xp;

    statisticsGestion stats;

    // Start is called before the first frame update
    void Start()
    {
        stats = gameObject.GetComponent<statisticsGestion>();

        for(int i = 0; i < nbStats ; i++)
        {
            lvl[i].text = stats.getLvl(i).ToString();
            dmg[i].text = stats.getModifExternal(i).ToString();
        }

        xp.text = stats.getExp().ToString();
    }

    // Update is called once per frame
    void Update()
    {


        for (int i = 0; i < nbStats; i++)
        {
            lvl[i].text = stats.getLvl(i).ToString();
            dmg[i].text = stats.getModifExternal(i).ToString();
        }

        xp.text = stats.getExp().ToString();
    }
}
