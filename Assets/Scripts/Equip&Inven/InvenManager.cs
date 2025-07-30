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
    public List<ItemData> prevDatas;
    
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
            Add(prevDatas[i]);
        }
    }

    public void Add(ItemData _item)
    {
        var array = theItemL[_item.itemType];
        for (int i = 0; i < array.Length; ++i)
        {
            if (array[i] == null)
            {
                array[i] = _item;
                break;
            }
            if (array[i].itemType != ItemType.Equip && array[i].itemID == _item.itemID)
            {
                array[i].itemCount++;
            }
        }
        OnitemChanged?.Invoke();
    }

    public ItemData GetItem(ItemType itemType, int index)
    {
        return theItemL[itemType][index];
    }
    public void SetItem(ItemType itemType, int index, ItemData item)
    {
        theItemL[itemType][index] = item;
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
}
