using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInter : MonoBehaviour
{

    public GameObject curInterObj = null;
    public InterObject curInterObjScript = null;
    public Inventory inventory;

    private void Update()
    {
        if(Input.GetButtonDown("Interact") && curInterObj)
        {
            //Check to see if this object is to be stored in inventory
            if(curInterObjScript.inventory)
            {
                inventory.AddItem(curInterObj);
                curInterObj = null;
            }
            if (!curInterObjScript.inventory && !curInterObjScript.farmable)
            {
                curInterObjScript.DoInter();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("interObject"))
        {
            Debug.Log(other.name);
            curInterObj = other.gameObject;
            curInterObjScript = curInterObj.GetComponent<InterObject>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("interObject") && curInterObjScript.inventory)
        {
            if(other.gameObject == curInterObj)
            {
                curInterObj = null;
            }
        }
    }
}
