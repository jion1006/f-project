using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipItemType
{
    Head,
    Armor,
    Shoes,
    Weapon,
    Rings,
    Neckless,
}

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/EquipItem")]
public class EquipItemData : ItemData
{
    public EquipItemType equipType;
    int itemAtk;
    int itemDef;
    int itemHp;

    int itemCrt;
    int itemCrtdmg;


}
