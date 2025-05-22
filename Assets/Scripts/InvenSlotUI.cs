using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class InvenSlotUI : MonoBehaviour
{
    public Image icon;

    public void SetItem(ItemData _item)
    {
        icon.sprite = _item?_item.icon:null;
    }

    public void Clear()
    {
        icon.sprite = null;
    }
}
