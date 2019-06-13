using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite icon;
    public int price = 1;

}
public class Items : MonoBehaviour {
    public int price;
    public Sprite icon;
    public string name;
    public ShopList sl;
    private bool added =false;

    private GameObject g = null;
    private Item a;

   public void addButtons()
    {

        if (!added)
        {
            sl.AddItem(a, sl);
            sl.AddButtons();
        }
        added = true;
    }
    private void Awake()
    {
        Debug.Log("woke");
        a = new Item();
        a.itemName = name;
        a.icon = icon;
        a.price = price;
        g = GameObject.FindGameObjectWithTag("findme");
        sl = g.GetComponent<ShopList>();
    }

}
