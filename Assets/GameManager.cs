using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public DigitalClock dc;
    public Text date;
    public Text moneyDisplay;
    public int money = 1000;
    public OptionsMenu OptionsMenu;
    public GameObject InventoryBar;
    public GameObject ShippingBin;
    public ShopList bin;
    void Update()
    {
        if(OptionsMenu.GameIsPaused || ShippingBin.activeSelf)
        {
            InventoryBar.SetActive(false);
        }
        else
        {
            InventoryBar.SetActive(true);
        }
        if(ShippingBin.activeSelf)
        {
            moneyDisplay.text = "";
        }
        else
        {
            FixedUpdate();
        }
        if (dc.hours == 12 && dc.am && dc.minutes == 0)
        {
            if(dc.day< 10)
            {
                date.text = dc.season + "/0" + dc.day;
                money += bin.dayClear();
                bin.gold = 0;
            }
            else
            {
                date.text = dc.season + "/" + dc.day;
                money += bin.dayClear();
                bin.gold = 0;
            }
            
        }
    }
    private void FixedUpdate()
    {
        moneyDisplay.text = money + "G";
    }
    public void UpdateTime()
    {
        if (dc.day < 10)
        {
            date.text = dc.season + "/0" + dc.day;
        }
        else
        {
            date.text = dc.season + "/" + dc.day;
        }
    }
}
