using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Equip,
    Use,
    Etc,
    Quest
}

[CreateAssetMenu(menuName = "Data/Item")]
public class ItemData : ScriptableObject
{
    public ItemType itemType;
    public string itemName;
    public Sprite icon;
    public int itemID;
    public int itemCount;
    public string description;
}
