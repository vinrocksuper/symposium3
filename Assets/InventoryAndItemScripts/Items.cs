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

    // Update is called once per frame
    void Update()
    {
        
    }

}
