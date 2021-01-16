using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xpScript : MonoBehaviour
{
    public System.Action<int> onGatherXp;
    public int qtyXp;

    // Start is called before the first frame update
    void Awake()
    {
        qtyXp = (int)Random.Range(0f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MainCharacter")
        {
            if(onGatherXp != null)
            {
                onGatherXp.Invoke(qtyXp);
            }
            Destroy(gameObject);
        }
    }
}
