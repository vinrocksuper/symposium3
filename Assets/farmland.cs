using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class farmland : MonoBehaviour
{
    public seed sd = null;
    public Inventory inventory;
    public String[] inventoryCopy;

    private GameObject host;
    private int firstPos;
    private bool watered;
    private bool wither;
    private bool planted = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interact"))
        { 
            if(planted)
            {
                //water method here

               
            }
            else
            {
                convertArray();
            
                bool result = false;
             //   bool result = inventor ; // Array.Exists(inventoryCopy, element => element.Contains("seed"));
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
                Remove();
 

            }
        }
    }
    private void Remove()
    {
        if (sd)
        {
            GameObject g = sd.gameObject;
            g.SetActive(false);
        }
    }

    private void die()
    {

    }

    public void onDayEnd()
    {

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
}
