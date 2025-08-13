using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class ShopItem
{
    public ItemData item;

    public int price;

}
[Serializable]
public class ShopSet
{
    public int itemID;
    public int price;
}

public class ShopUI : MonoBehaviour
{
    public List<ShopSet> shopItems;
    public List<ShopSlotUI> shopSlotUIs;
    public GameObject total;
    public GameObject error;
    public TextMeshProUGUI coinText;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < shopItems.Count; ++i)
        {
            shopSlotUIs[i].SetItem(shopItems[i]);
            shopSlotUIs[i].OnBuy += RefreshUI;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            OnCloseButton();
    }

    void OnEnable()
    {
        RefreshUI();
    }
    public void OnCloseButton()
    {
        UIManager.Instance.CloseUI(total, () =>
        {
            PlayerController.Instance.thePS.ChangeState(PlayerStateType.Move);
        });
    }

    public void OnErrorPanel()
    {
        error.SetActive(true);
    }

    public void RefreshUI()
    {
        coinText.text = PlayerController.Instance.playerStat.coin.ToString();
    }
}
