using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;
using TMPro;

public class ItemInfoUI : MonoBehaviour
{
    [Header("툴팁")]
    public GameObject tooltipPanel;
    public Image itemIcon;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI desctiptText;

    [Header("드래그")]
    public GameObject dragPanel;
    public Image dragImg;


    public void ShowTooltip(ItemData _item, Vector2 _postion)
    {
        tooltipPanel.SetActive(true);
        tooltipPanel.transform.position = _postion+new Vector2(200f,-100f);
        itemIcon.sprite = _item.icon;
        nameText.text = _item.itemName;
        desctiptText.text = _item.description;
    }

    public void HideToolTip()
    {
        tooltipPanel.SetActive(false);
    }

    public void ShowDragPanel(Sprite _sprite)
    {
        dragPanel.SetActive(true);
        dragImg.sprite = _sprite;
    }

    public void MoveDrag(Vector2 _postion)
    {
        dragPanel.transform.position = _postion;
    }

    public void HideDrag()
    {
        dragPanel.SetActive(false);
    }
}
