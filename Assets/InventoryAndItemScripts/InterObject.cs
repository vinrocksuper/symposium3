using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InterObject : MonoBehaviour
{
    public bool inventory; //if true can be stored in inventory
    public bool farmable; //true if farmable

    public bool talks;
    public Text t;
    public Canvas textbox;
    public string message;


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
        
    }

    public void Talk()
    {
        
        t.text = message;

    }

    public void Update()
    {

    }

   

}
