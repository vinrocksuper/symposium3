using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterObject : MonoBehaviour
{
    public bool inventory; //if true can be stored in inventory
    public bool farmable; //true if farmable
    public bool bin;
    public Inventory inv;
    public DigitalClock dc = null;
    public GameManager gm = null;
    public GameObject UI;
    public void DoInter()
    {
        //Make item disappear
        if (inventory)
        {
            gameObject.SetActive(false);
        }
        else if (farmable)
        {

        }
        else if (dc && gm)
        {
            dc.restart();
            gm.UpdateTime();
        }
        else if(bin)
        {
            UI.SetActive(true);

        }
    }
    public void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            if(UI.activeSelf)
            {
                UI.SetActive(false);
            }
        }
    }

}
