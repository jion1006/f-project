using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ShopSlotUI : MonoBehaviour
{
    public TMP_Text itemName;
    public TMP_Text itemPrice;

    public Image itemImage;
    public ShopItem shopItem;
    public ShopUI shopUI;

    public event Action OnBuy;

    // Start is called before the first frame update
    void Start()
    {
        shopUI = GetComponentInParent<ShopUI>();
        
    }

   
    public void BuyShopItem()
    {
        if (shopItem.price <= PlayerController.Instance.playerStat.coin)
        {
            PlayerController.Instance.playerStat.coin -= shopItem.price;
            InvenManager.Instance.Add(shopItem.item);
            OnBuy?.Invoke();
        }
        else
        {
            shopUI.OnErrorPanel();
        }
    }

    public void SetItem(ShopSet _shopItem)
    {
        shopItem.item = DataManager.Instance.GetItem(_shopItem.itemID);
        shopItem.price = _shopItem.price;
        itemName.text = shopItem.item.itemName;
        itemPrice.text = shopItem.price.ToString();
        itemImage.sprite = shopItem.item.icon;
    }
}
