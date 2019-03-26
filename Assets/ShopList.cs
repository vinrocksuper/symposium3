using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class ShopList : MonoBehaviour
{
    public List<Item> itemList;
    public Transform contentPanel;
    public ShopList otherShop;
    public Text myGoldDisplay;
    public ObjectPool buttonObjectPool;
    public int gold = 0;
    public GameManager gm;
    
    // Use this for initialization
    void Start()
    {
        RefreshDisplay();
    }

    public void RefreshDisplay()
    {
        
        RemoveButtons();
        AddButtons();
        UpdateValue();
        myGoldDisplay.text = gold.ToString();
    }

    public void RemoveButtons()
    {
        while (contentPanel.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            buttonObjectPool.ReturnObject(toRemove);
        }
    }

    public void AddButtons()
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

            AddItem(item, otherShop);
            RemoveItem(item, this);
            
            RefreshDisplay();
            otherShop.RefreshDisplay();
        
        
    }

    public void AddItem(Item itemToAdd, ShopList shopList)
    {
        shopList.itemList.Add(itemToAdd);
    }

    public void RemoveItem(Item itemToRemove, ShopList shopList)
    {
        for (int i = shopList.itemList.Count - 1; i >= 0; i--)
        {
            if (shopList.itemList[i] == itemToRemove)
            {
                shopList.itemList.RemoveAt(i);
            }
        }
    }

    public void UpdateValue()
    {
        int valueAdd = 0;
        Text[] textfields = GetComponentsInChildren<Text>();
        for(int i=1;i<textfields.Length;i+=2)
        {
            int a = int.Parse(textfields[i].text);
            valueAdd += a;
        }
        gold = valueAdd;
    }
    public void dayClear()
    {
        RemoveButtons();
        
    }
    public int addMoney()
    {

        return gold;
    }
    public void newDay()
    {
        myGoldDisplay.text = gold.ToString();
    }
}

