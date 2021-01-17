using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class button : MonoBehaviour, IPointerEnterHandler//, IPointerDownHandler
{
    static public System.Action buttunHover;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData ped)
    {
        Debug.Log("trorlrorel");
        if(buttunHover != null)
        {
            buttunHover.Invoke();
        }
    }
}
