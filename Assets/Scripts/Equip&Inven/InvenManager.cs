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
    private Dictionary<ItemType, ItemData[]> DItem;

    public static InvenManager Instance;
    public List<int> prevDatas;

    public event Action OnitemChanged;
    public event Action<int> OnitemAdd;


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
        DItem = new Dictionary<ItemType, ItemData[]>();
        foreach (ItemType item in Enum.GetValues(typeof(ItemType)))
        {
            DItem[item] = new ItemData[slotsize];
        }
        SaveLoadManager.Instance.OnStartLoad += Load;
    }
    
    public void Init()
    {
        ClearAll();
        for (int i = 0; i < prevDatas.Count; ++i)
        {
            Add(DataManager.Instance.GetItem(prevDatas[i]));
        }

        for (int i = 0; i < slotsize; ++i)
        {
            if (DItem[ItemType.Equip][i] != null)
            {
                EquipItemData startEquip = DItem[ItemType.Equip][i] as EquipItemData;
                startEquip.isEquip = false;
                DItem[ItemType.Equip][i] = startEquip;
            }
        }
    }

    public void Load()
    {
        SaveData data = SaveLoadManager.Instance.load;
        ClearAll();
        foreach (var items in data.itemSave)
        {
            ItemData item = DataManager.Instance.GetItem(items.itemID);
            item.itemCount = items.itemCount;
            SetItem(item.itemType, items.index, item);
        }
    }

    public void Add(ItemData _item)
    {
        var array = DItem[_item.itemType];
        for (int i = 0; i < array.Length; ++i)
        {
            if (array[i] != null && array[i].itemType != ItemType.Equip && array[i].itemID == _item.itemID)
            {
                array[i].itemCount++;
                OnitemChanged?.Invoke();
                QuestManager.Instance.ItemGet(_item.itemID);
                return;
            }
        }
        for (int i = 0; i < array.Length; ++i)
        {
            if (array[i] == null)
            {
                array[i] = _item;
                OnitemChanged?.Invoke();
                OnitemAdd?.Invoke(_item.itemID);
                QuestManager.Instance.ItemGet(_item.itemID);
                return;
            }

        }
    }

    public ItemData GetItem(ItemType itemType, int index)
    {
        return DItem[itemType][index];
    }

    public void SetItem(ItemType itemType, int index, ItemData item)
    {
        if (item != null && itemType == ItemType.Equip)
        {
            EquipItemData equip = item as EquipItemData;
            equip.isEquip = false;
            DItem[itemType][index] = equip;
        }
        else
        {
            DItem[itemType][index] = item;
        }
        OnitemChanged?.Invoke();

    }



    public void ReduceItem(int _id, int _count)
    {
        ItemData sample = DataManager.Instance.GetItem(_id);
        var itemL = DItem[sample.itemType];
        for (int i = 0; i < itemL.Length; ++i)
        {
            if (itemL[i] != null && itemL[i].itemID == _id)
            {
                itemL[i].itemCount -= _count;
                if (itemL[i].itemCount <= 0)
                    ClearItem(itemL[i].itemType, i);
                break;
            }
        }
        Destroy(sample);
    }
    

    public void ClearItem(ItemType itemType, int index)
    {
        Destroy(DItem[itemType][index]);
        DItem[itemType][index] = null;
        OnitemChanged?.Invoke();
    }

    public ItemData[] GetItemArray(ItemType _itemType)
    {

        return DItem[_itemType];
    }

    public Dictionary<ItemType, ItemData[]> GetAll()
    {
        return DItem;
    }

    public void ClearAll()
    {
        foreach (var itemL in DItem)
        {
            ItemData[] items = itemL.Value;
            for (int i = 0; i < items.Length; ++i)
            {
                Destroy(items[i]);
                items[i] = null;
            }
        }
    }
}
