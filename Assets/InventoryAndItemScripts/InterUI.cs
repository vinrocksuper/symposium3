using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterUI : MonoBehaviour
{

    public bool bin;


    public DigitalClock dc = null;
    public GameManager gm = null;
    public GameObject UI = null;
    public GameObject UI2 = null;

    public void DoInter()
    {
        if (dc && gm)
        {
            dc.restart();
            gm.UpdateTime();
        }
        else if (bin)
        {
            UI.SetActive(true);
            UI2.SetActive(true);
        }
    }


    public void Update()
    {
        if (Input.GetButtonDown("Cancel") && UI2)
        {
            if (UI.activeSelf)
            {
                UI.SetActive(false);
                UI2.SetActive(false);
            }
        }
    }

}
