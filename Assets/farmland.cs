using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class farmland : MonoBehaviour
{
    public seed sd = null;
    public Inventory inventory;
    public String[] inventoryCopy;
    public GameObject land;
    private GameObject host;
    private int firstPos;
    public bool watered;
    private bool wither;
    public bool planted = false;
    public bool range = false;
    private bool fullyGrown = false;

    // Update is called once per frame
    void Update()
    {

        if(Input.GetButtonDown("Interact") && range)
        { 
            if(planted)
            {
                //water method here
                watered = true;
                Debug.Log("Plant watered");
            }
            else if(wither)
            {
                planted = false;
                sd = null;
                watered = false;
            }
            else
            {
                convertArray();
            
                bool result = false;
             for(int i=0;i<inventoryCopy.Length;i++)
                {
                    if (inventoryCopy[i] != null && inventoryCopy[i].Contains("Seed"))
                    {
                        firstPos = i;
                        break;
                    }
                    
                }
                host = inventory.inventory.GetValue(firstPos) as GameObject;
                sd = host.GetComponent<seed>();
                Remove(firstPos);
                planted = true;

            }
        }
    }
    private void Remove(int a)
    {
        if (sd)
        {
            GameObject g = sd.gameObject;
            g.SetActive(false);
            this.inventory.inventory[a] = null;
            this.inventory.InventoryImages[a] = null;
        }
    }

    private void grow()
    { 
        Instantiate(sd.crop,transform.position + (transform.up), transform.rotation);
    }

    public void onDayEnd()
    {
        if(!watered && planted)
        {
            wither = true;
        }
        if(watered)
        {
            watered = false;
            this.sd.daysToGrow--;
            if(sd.daysToGrow==0)
            {
                grow();
            }
        }
    }
    public String[] convertArray()
    {
        inventoryCopy = new string[inventory.inventory.Length];
        for (int i=0;i<inventory.inventory.Length;i++)
        {
            if(inventory.inventory[i]!=null)
            {
                inventoryCopy[i] = inventory.inventory[i].ToString();
            }
        }
        return inventoryCopy;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        range = true;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        range = false;   
    }
}
