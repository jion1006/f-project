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

[CreateAssetMenu(fileName = "NewItem", menuName = "Data/EquipItem")]
public class EquipItemData : ItemData
{
    public EquipItemType equipType;
    public int itemAtk;
    public int itemDef;
    public int itemHp;

    public int itemCrt;
    public int itemCrtdmg;
    public int enforce = 0;

}
