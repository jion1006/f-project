using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Data/Healing")]
public class HealingItemData : ItemData
{
    public int healing;

    public override void Use(ItemSlotUI slotUI)
    {
        PlayerController.Instance.Heal(healing);
        itemCount--;
        if (itemCount <= 0)
        {
            slotUI.SetItem(null);
        }
        else
            slotUI.SetItem(this);
    }

    public override ItemData Clone()
    {
        HealingItemData item = ScriptableObject.CreateInstance<HealingItemData>();
        item.itemType = itemType;
        item.itemName = itemName;
        item.icon = icon;
        item.itemID = itemID;
        item.itemCount = itemCount;
        item.description = description;

        item.healing = healing;
        return item;
    }
}
