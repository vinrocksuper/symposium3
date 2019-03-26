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


    private Item a;


    // Update is called once per frame
    void Start()
    {
        a = new Item();
        a.itemName = name;
        a.icon = icon;
        a.price = price;

    }
    public void addButtons()
    {

        if (!added)
        {
            sl.AddItem(a, sl);
            sl.AddButtons();
        }
        added = true;
    }
}
