using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSlotUI : ItemSlotUI
{
    
    public override bool IsAllow(ItemData item)
    {
        if (item == null) return true;
        if (!restrictByType) return true;
        if (item.itemType != alloweType) return false;
        EquipItemData equip = currentItem as EquipItemData;
        EquipItemData target = item as EquipItemData;
        return index == (int)target.equipType;
    }

    
}
