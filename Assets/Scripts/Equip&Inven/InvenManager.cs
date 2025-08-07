using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data.Common;

public interface IItemContainer
{
    public ItemData GetItem(ItemType itemType,int index);
    public void SetItem(ItemType itemType, int index, ItemData item);
    public void ClearItem(ItemType itemType, int index);
}

public class InvenManager : MonoBehaviour, IItemContainer
{
    private Dictionary<ItemType, ItemData[]> theItemL;

    public static InvenManager Instance;
    public List<int> prevDatas;

    public event Action OnitemChanged;


    public int slotsize = 40;


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

    void Start()
    {
        theItemL = new Dictionary<ItemType, ItemData[]>();
        foreach (ItemType item in Enum.GetValues(typeof(ItemType)))
        {
            theItemL[item] = new ItemData[slotsize];
        }
        for (int i = 0; i < prevDatas.Count; ++i)
        {
            Add(DataManager.Instance.GetItem(prevDatas[i]));
        }

        for (int i = 0; i < slotsize; ++i)
        {
            if (theItemL[ItemType.Equip][i] != null)
            {
                EquipItemData startEquip = theItemL[ItemType.Equip][i] as EquipItemData;
                startEquip.isEquip = false;
                theItemL[ItemType.Equip][i] = startEquip;
            }
        }
    }

    public void Add(ItemData _item)
    {
        var array = theItemL[_item.itemType];
        for (int i = 0; i < array.Length; ++i)
        {
            if (array[i] != null && array[i].itemType != ItemType.Equip && array[i].itemID == _item.itemID)
            {
                array[i].itemCount++;
                OnitemChanged?.Invoke();
                return;
            }
        }
        for (int i = 0; i < array.Length; ++i)
        {
            if (array[i] == null)
            {
                array[i] = _item;
                OnitemChanged?.Invoke();
                return;
            }

        }
    }

    public ItemData GetItem(ItemType itemType, int index)
    {
        return theItemL[itemType][index];
    }
    public void SetItem(ItemType itemType, int index, ItemData item)
    {
        if (item != null && itemType == ItemType.Equip)
        {
            EquipItemData equip = item as EquipItemData;
            equip.isEquip = false;
            theItemL[itemType][index] = equip;
        }
        else
        {
            theItemL[itemType][index] = item;
        }
        OnitemChanged?.Invoke();

    }

    public void ClearItem(ItemType itemType, int index)
    {
        theItemL[itemType][index] = null;
        OnitemChanged?.Invoke();
    }

    public ItemData[] GetItemArray(ItemType _itemType)
    {

        return theItemL[_itemType];
    }

    public Dictionary<ItemType, ItemData[]> GetAll()
    {
        return theItemL;
    }

    public void ClearAll()
    {
        foreach (var itemL in theItemL)
        {
            ItemData[] items = itemL.Value;
            for (int i = 0; i < items.Length; ++i)
            {
                items[i] = null;
            }
        }
    }
}
