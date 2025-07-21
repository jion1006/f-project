using System;
using System.Collections;
using System.Collections.Generic;
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
    public GameObject total;

    // Start is called before the first frame update
    void Start()
    {

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
}
