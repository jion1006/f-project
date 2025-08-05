using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipItemType
{
    Weapon,
    Head,
    Armor,
    Shoes,
    Rings,
    Neckless,
}

[CreateAssetMenu(fileName = "NewItem", menuName = "Data/EquipItem")]
public class EquipItemData : ItemData
{
    public EquipItemType equipType;
    public int itemAtk;
    public int itemDef;
    public int itemHp;

    public int enforce = 0;
    public bool isEquip = false;
    public override void Use(ItemSlotUI slotUI)
    {
        if (!isEquip)
            EquipManager.Instance.Equip(slotUI);
        else
            EquipManager.Instance.UnEquip(equipType);
    }

    public override ItemData Clone()
    {
        EquipItemData item = ScriptableObject.CreateInstance<EquipItemData>();
        item.itemType = itemType;
        item.itemName = itemName;
        item.icon = icon;
        item.itemID = itemID;
        item.itemCount = itemCount;
        item.description = description;

        item.equipType = equipType;
        item.itemAtk = itemAtk;
        item.itemDef = itemDef;
        item.itemHp = itemHp;

        item.enforce = enforce;
        item.isEquip = isEquip;
        return item;
    }

}
