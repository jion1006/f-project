using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;
using TMPro;

public class InvenInfoUI : MonoBehaviour
{
    public ItemData currentItem;
    public Image itemIcon;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI desctiptText;

    public void SetInfo(ItemData _item)
    {
        currentItem = _item;
        itemIcon.sprite = currentItem.icon;
        nameText.text = currentItem.itemName;
        desctiptText.text = currentItem.description;
    }

    public void Show(Vector2 _postion)
    {
        gameObject.SetActive(true);
        transform.position = _postion;
    }


    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
