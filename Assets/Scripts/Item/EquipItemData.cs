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

    

}
