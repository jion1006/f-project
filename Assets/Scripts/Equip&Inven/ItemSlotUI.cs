using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlotUI : MonoBehaviour,
            IPointerEnterHandler, IPointerExitHandler,IBeginDragHandler,
            IEndDragHandler,IDragHandler,IDropHandler

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

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (currentItem == null)
            return;
        DragManager.Instance.StartDrag(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        DragManager.Instance.UpdateDrag(eventData.position);
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
            theInfo.SetInfo(currentItem);
            theInfo.Show(Input.mousePosition);
        }
    }

    public void OnPointerExit(PointerEventData _eventData)
    {
        theInfo.Hide();
    }
}
