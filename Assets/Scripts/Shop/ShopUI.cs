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

public class ShopUI : MonoBehaviour
{
    public List<ShopItem> shopItems;
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
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            OnCloseButton();
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
}
