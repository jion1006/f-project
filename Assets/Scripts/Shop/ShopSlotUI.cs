using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ShopSlotUI : MonoBehaviour
{
    public TMP_Text itemName;
    public TMP_Text itemPrice;

    public ShopItem shopItem;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BuyShopItem()
    {
        if (shopItem.price <= PlayerController.Instance.playerStat.coin)
        {

        }
    }

    public void SetItem(ShopItem _shopItem)
    {
        shopItem = _shopItem;
        itemName.text = _shopItem.item.itemName;
        itemPrice.text = _shopItem.price.ToString();
    }
}
