using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragManager : MonoBehaviour
{
    public static DragManager Instance;    
    public ItemSlotUI originSlot;

    public bool isDrag { get; private set; }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);

        

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    public void StartDrag(ItemSlotUI prevSlot)
    {
        originSlot = prevSlot;
        isDrag = true;
        UIManager.Instance.OnDragPanel(originSlot.currentItem.icon);
    }

    public void UpdateDrag(Vector2 mousePos)
    {
        UIManager.Instance.Draging(mousePos);
    }

    public void EndDrag()
    {
        if (!isDrag)
            return;
        UIManager.Instance.EndDrag();
        isDrag = false;
        originSlot = null;
    }
    public void CancelDrag()
    {
        UIManager.Instance.EndDrag();
        if (originSlot == null || originSlot.currentItem == null)
            return;
        isDrag = false;
        originSlot.icon.sprite = originSlot.currentItem.icon;
        originSlot = null;
    }
    public void TrySwapSlot(ItemSlotUI targetSlot)
    {

        if (originSlot == null)
            return;
        if (targetSlot == null || originSlot == targetSlot|| originSlot == null)
            {
                originSlot.icon.sprite = originSlot.currentItem ? originSlot.currentItem.icon : null;
                return;
            }
        var originItem = originSlot.GetItem();
        var targetItem = targetSlot.GetItem();

        if (!targetSlot.IsAllow(originItem) || !originSlot.IsAllow(targetItem))
        {
            originSlot.icon.sprite = originSlot.currentItem.icon;
            return;
        }


        Debug.Log("떨굼");

        originSlot.SetItem(targetItem);
        targetSlot.SetItem(originItem);

    }
}
