using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite icon;
    public float price = 1;
 
}
public class ShopList : MonoBehaviour
{
    public List<Item> itemList;
    public Transform contentPanel;
    public ShopList otherShop;
    public Text myGoldDisplay;
    public ObjectPool buttonObjectPool;
    public Inventory inv;
    public float gold = 20f;


    // Use this for initialization
    void Start()
    {
        RefreshDisplay();
    }

    public void RefreshDisplay()
    {
        myGoldDisplay.text = "Gold: " + gold.ToString();
        Debug.Log(contentPanel.childCount);
        RemoveButtons();
        AddButtons();
    }

    private void RemoveButtons()
    {
        while (contentPanel.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            buttonObjectPool.ReturnObject(toRemove);
        }
    }

    private void AddButtons()
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            Item item = itemList[i];
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel);

            ButtonPrefab sampleButton = newButton.GetComponent<ButtonPrefab>();
            sampleButton.Setup(item, this);
        }
    }

    public void TryTransferItemToOtherShop(Item item)
    {
        if(otherShop == null)
        {
            return;
        }
        if (otherShop.gold >= item.price)
        {
            gold += item.price;
            otherShop.gold -= item.price;

            AddItem(item, otherShop);
            RemoveItem(item, this);

            RefreshDisplay();
            otherShop.RefreshDisplay();
        }
        
    }

    void AddItem(Item itemToAdd, ShopList shopList)
    {
        shopList.itemList.Add(itemToAdd);
    }

    private void RemoveItem(Item itemToRemove, ShopList shopList)
    {
        for (int i = shopList.itemList.Count - 1; i >= 0; i--)
        {
            if (shopList.itemList[i] == itemToRemove)
            {
                shopList.itemList.RemoveAt(i);
            }
        }
    }
    private Item convert(item it)
    {
        Item a = new Item();
        a.icon = it.sprite;
        a.price = it.price;
        a.itemName = it.name;
        return a;

    }
}

