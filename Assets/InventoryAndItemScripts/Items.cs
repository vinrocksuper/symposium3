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
public class Items : MonoBehaviour
{
    public int price;
    public Sprite icon;
    public string name;
    public ShopList sl;
    // Update is called once per frame
    void Start()
    {
        Item a = new Item();
        a.itemName = name;
        a.icon = icon;
        a.price = price;
        sl.AddItem(a,sl);
        
    }

}
