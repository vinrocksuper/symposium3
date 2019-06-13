using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InterObject : MonoBehaviour
{
    public Items inventory; //if true can be stored in inventory
    public bool farmable; //true if farmable

    public bool talks;
    public Text t;
    public GameObject textbox;
    public string message;




    public void DoInter()
    {
        //Make item disappear
        if (inventory)
            {
            DestroyImmediate(this);
            inventory.addButtons();

        }  
    }

    public void Talk()
    {
        
        t.text = message;
        textbox.SetActive(true);
        
    }

    public void Update()
    {

    }
    
   

}
