using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventory = new GameObject[7];
    public Image[] InventoryImages = new Image[7];


    public void AddItem(GameObject item)
    {
        bool itemAdded = false;

        //find first open slot in inventory
        for(int i = 0;i < inventory.Length;i++)
        {
            if(inventory[i] == null)
            {
                inventory[i] = item;
                //Update UI
                InventoryImages[i].overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
                Debug.Log(item.name + " was added");
                itemAdded = true;
                //Does something with the object
                item.SendMessage("DoInter");
                break;
            }
        }

        //inventory full
        if (!itemAdded)
        {
            Debug.Log("Inventory full - Item not added.");
        }
    }
}
