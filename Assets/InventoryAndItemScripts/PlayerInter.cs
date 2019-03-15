using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInter : MonoBehaviour
{

    public GameObject curInterObj = null;
    public InterObject curInterObjScript = null;
    public InterUI curInterUIScript = null;
    public Inventory inventory;

    private void Update()
    {
        if (curInterObj == null)
        {
            curInterObjScript = null;
            curInterUIScript = null;
        }
        if(Input.GetButtonDown("Interact") && curInterObj)
        {
            if (curInterUIScript)
            {
                curInterUIScript.DoInter();
            }
            //Check to see if this object is to be stored in inventory


            else if (curInterObjScript)
            {
                if (curInterObjScript.inventory)
                {
                    inventory.AddItem(curInterObj);
                    curInterObj = null;
                }
                else if (curInterObjScript.talks)
                {
                    curInterObjScript.Talk();
                }
            }



        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("interObject") )
        {
            Debug.Log(other.name);
            curInterObj = other.gameObject;
            curInterObjScript = curInterObj.GetComponent<InterObject>();
        }
        if (other.CompareTag("interUI"))
        {
            curInterObj = other.gameObject;
            curInterUIScript = curInterObj.GetComponent<InterUI>();
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("interUI"))
        {
            if (other.gameObject == curInterObj)
            {
                curInterObj = null;
                curInterUIScript = null;
            }
        }
        if (other.CompareTag("interObject"))
        {
            if(other.gameObject == curInterObj)
            {
                curInterObj = null;
                curInterObjScript = null;
            }
        }
        

    }
}
