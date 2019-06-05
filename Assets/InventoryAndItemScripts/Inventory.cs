using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventory = new GameObject[7];
    public Image[] InventoryImages = new Image[7];

    private GameObject nameSomething;
    private bool ns;
    private void Start()
    {
        nameSomething = GameObject.Find("Inventory-bin UI");
        nameSomething.SetActive(false);

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            nameSomething.SetActive(ns);
            ns = !ns;
        }
    }
    public void AddItem(GameObject item)
    {

        //find first open slot in inventory
        for(int i = 0;i < inventory.Length;i++)
        {
            if(inventory[i] == null)
            {
                inventory[i] = item;
                //Update UI
                InventoryImages[i].overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
                

                //Does something with the object
                item.SendMessage("DoInter");
                break;
            }
        }
    }
    
    public void removeItem(int pos)
    {
        inventory[pos] = null;
        InventoryImages[pos] = Resources.Load<Image>("Assets/Sprites/backgroundImage");
    }
    public void AddItem(Item a)
    {
        for(int i=0;i<inventory.Length;i++)
        {
            if(inventory[i] == null)
            {
                inventory[i] = new GameObject();
                InventoryImages[i].overrideSprite = a.icon;
                break;
            }
        }
    }
}
