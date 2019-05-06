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
    public bool watered;
    private bool wither;
    public bool planted = false;
    public bool range = false;
    // Update is called once per frame
    void Update()
    {

        if(Input.GetButtonDown("Interact"))
        { 
            if(planted)
            {
                //water method here
                watered = true;
                Debug.Log("Plant watered");
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
        /**
        GameObject crop = new GameObject("");
        crop.AddComponent<InterObject>();
        crop.AddComponent<CircleCollider2D>();
        crop.AddComponent<Items>();
        crop.gameObject.GetComponent<SpriteRenderer>();
       **/
        Instantiate(sd.crop);
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
    public void OnCollisionEnter2D(Collision2D collision)
    {
        range = true;
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        range = false;
    }
}
