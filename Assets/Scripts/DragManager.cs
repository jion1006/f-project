using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragManager : MonoBehaviour
{
    public static DragManager Instance;

    
    
    public ItemSlotUI originSlot;

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
        UIManager.Instance.OnDragPanel(originSlot.currentItem.icon);
    }

    public void UpdateDrag(Vector2 mousePos)
    {
        UIManager.Instance.Draging(mousePos);
    }

    public void EndDrag()
    {
        UIManager.Instance.EndDrag();
        originSlot = null;
    }

    public void TrySwapSlot(ItemSlotUI targetSlot)
    {
        if (originSlot == null || targetSlot == null || originSlot == targetSlot)
            return;

        if (!targetSlot.IsAllow(originSlot.currentItem)||originSlot.IsAllow(targetSlot.currentItem))
            return;
            
        var temp = originSlot.currentItem;
        originSlot.SetItem(targetSlot.currentItem);
        targetSlot.SetItem(temp);

    }
}
