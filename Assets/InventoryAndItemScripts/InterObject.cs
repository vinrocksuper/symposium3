using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterObject : MonoBehaviour
{
    public bool inventory; //if true can be stored in inventory
    public bool farmable; //true if farmable

    public bool talks;

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
        Debug.Log(message);
    }

    public void Update()
    {

    }

}
