using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class ShopSlotUI : MonoBehaviour
{
    public TMP_Text itemName;
    public TMP_Text itemPrice;

    public Image itemImage;
    public ShopItem shopItem;
    public ShopUI shopUI;

    // Start is called before the first frame update
    void Start()
    {
        shopUI = GetComponentInParent<ShopUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BuyShopItem()
    {
        if (shopItem.price <= PlayerController.Instance.playerStat.coin)
        {
            PlayerController.Instance.playerStat.coin -= shopItem.price;
            InvenManager.Instance.Add(shopItem.item);
        }
        else
        {
            shopUI.OnErrorPanel();
        }
    }

    public void SetItem(ShopItem _shopItem)
    {
        shopItem = _shopItem;
        itemName.text = _shopItem.item.itemName;
        itemPrice.text = _shopItem.price.ToString();
        itemImage.sprite = _shopItem.item.icon;
    }
}
