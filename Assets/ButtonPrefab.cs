using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPrefab : MonoBehaviour
{
    public Button b;
    public Text name;
    public Text price;
    public Image icon;

    private Item item;
    private ShopList ShopList;
    // Start is called before the first frame update
    void Start()
    {
        b.onClick.AddListener(handleClick);

    }

    public void Setup(Item currentItem, ShopList sl)
    {
        item = currentItem;
        name.text = item.itemName;
        price.text = item.price.ToString();
        icon.sprite = item.icon;

        ShopList = sl;
    }
    public void handleClick()
    {
        ShopList.TryTransferItemToOtherShop(item);

    }
}
