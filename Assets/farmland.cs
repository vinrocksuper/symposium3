﻿using System;
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
    public bool range = true;
    private bool fullyGrown = false;
    public changeSprite cs;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Interact") && range)
        {
            if (planted)
            {
                //water method here
                watered = true;
                cs.water();
            }
            else if (wither)
            {
                planted = false;
                sd = null;
                watered = false;
            }
            else
            {
                convertArray();

                bool result = false;
                for (int i = 0; i < inventoryCopy.Length; i++)
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
        
        GameObject a = Instantiate(sd.crop, transform.position + (transform.up), transform.rotation);
        a.GetComponent<Items>().enabled = true;
    }

    public void onDayEnd()
    {
        if (!watered && planted)
        {
            wither = true;
            cs.Dry();
        }
        if (watered && planted)
        {
            watered = false;
            this.sd.daysToGrow--;
            if (sd.daysToGrow == 0)
            {
                grow();
            }
        }
    }
    public String[] convertArray()
    {
        inventoryCopy = new string[inventory.inventory.Length];
        for (int i = 0; i < inventory.inventory.Length; i++)
        {
            if (inventory.inventory[i] != null)
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
