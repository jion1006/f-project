using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class ItemSlotUI : MonoBehaviour,
            IPointerEnterHandler, IPointerExitHandler,IBeginDragHandler,
            IEndDragHandler,IDragHandler,IDropHandler

{
    public Image icon;
    public ItemData currentItem;
    

    public Action<ItemData> OnSlotChanged;

    public bool restrictByType = false;
    public ItemType alloweType;
    void Start()
    {
        
    }

    public void SetItem(ItemData _item)
    {
        currentItem = _item;
        icon.sprite = currentItem ? currentItem.icon : null;
        OnSlotChanged?.Invoke(_item);
    }

    public void Clear()
    {
        currentItem = null;
        icon.sprite = null;
    }

    public bool IsAllow(ItemData item)
    {
        if (item == null) return true;
        if (!restrictByType) return true;
        return item.itemType == alloweType;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

        if (currentItem == null)
            return;
        DragManager.Instance.StartDrag(this);
        Debug.Log("감지");
    }

    public void OnDrag(PointerEventData eventData)
    {
        DragManager.Instance.UpdateDrag(Input.mousePosition);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        DragManager.Instance.EndDrag();
    }
    public void OnDrop(PointerEventData eventData)
    {
        DragManager.Instance.TrySwapSlot(this);
    }



    public void OnPointerEnter(PointerEventData _eventData)
    {
        if (currentItem != null)
        {
            UIManager.Instance.OnTooltipPanel(currentItem,transform.position);
        }
    }

    public void OnPointerExit(PointerEventData _eventData)
    {
        UIManager.Instance.EndTooltip();
    }
}
