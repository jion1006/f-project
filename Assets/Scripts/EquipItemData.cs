using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum equipItemType
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
    equipItemType equipType;
    int itemAtk;
    int itemDef;
    int itemHp;

    int itemCrt;
    int itemCrtdmg;


}
