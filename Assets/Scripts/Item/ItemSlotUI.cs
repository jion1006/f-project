using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class ItemSlotUI : MonoBehaviour,
            IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler,
            IEndDragHandler, IDragHandler, IDropHandler, IPointerClickHandler

{
    public Image icon;
    public ItemData currentItem;
    public ItemType currentType;
    public int index;
    public IItemContainer itemContainer;

    public bool restrictByType = false;
    public ItemType alloweType;
    void Start()
    {

    }

    public void SetSlot(IItemContainer _itemContainer, ItemData _item, int _index)
    {
        itemContainer = _itemContainer;
        currentItem = _item;
        index = _index;
        icon.sprite = currentItem ? currentItem.icon : null;
    }

    public ItemData GetItem()
    {
        return itemContainer.GetItem(currentType, index);
    }
    public void SetItem(ItemData item)
    {
        itemContainer.SetItem(currentType, index, item);
    }

    public void Clear()
    {
        currentItem = null;
        icon.sprite = null;
    }

    public virtual bool IsAllow(ItemData item)
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
        icon.sprite = null;
    }

    public void OnDrag(PointerEventData eventData)
    {
        DragManager.Instance.UpdateDrag(Input.mousePosition);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerEnter == null ||
           eventData.pointerEnter.GetComponent<ItemSlotUI>() == null)
            DragManager.Instance.CancelDrag();
        else
            DragManager.Instance.EndDrag();
    }
    public void OnDrop(PointerEventData eventData)
    {
        DragManager.Instance.TrySwapSlot(this);
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        if (currentItem != null && !DragManager.Instance.isDrag)
        {
            UIManager.Instance.OnTooltipPanel(currentItem, transform.position);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.Instance.EndTooltip();
    }

    public void OnPointerClick(PointerEventData eventaData)
    {
        if (eventaData.button == PointerEventData.InputButton.Right && currentItem != null)
        {
            currentItem.Use(this);
            
        }
    }
}
