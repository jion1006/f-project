using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using Unity.PlasticSCM.Editor.WebApi;

public class InvenSlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image icon;
    public ItemData currentItem;
    public InvenInfoUI theInfo;

    void Start()
    {
        theInfo = InvenManager.Instance.theInfo;
    }

    public void SetItem(ItemData _item)
    {
        currentItem = _item;
        icon.sprite = currentItem ? currentItem.icon : null;
    }

    public void Clear()
    {
        currentItem = null;
        icon.sprite = null;
    }

    public void OnPointerEnter(PointerEventData _eventData)
    {
        if (currentItem != null)
        {
            theInfo.SetInfo(currentItem);
            theInfo.Show(Input.mousePosition);
        }
    }

    public void OnPointerExit(PointerEventData _eventData)
    {
        theInfo.Hide();
    }
}
