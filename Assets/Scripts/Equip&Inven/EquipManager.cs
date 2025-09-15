using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class ItemStat
{
    public int atk = 0;
    public int def = 0;
    public int maxHP = 0;
}
public class EquipManager : MonoBehaviour, IItemContainer
{
    private EquipItemData[] theEq;
    // Start is called before the first frame update

    public static EquipManager Instance { get; private set; }

    public event Action OnEquipChange;
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
        int equipnum = Enum.GetNames(typeof(EquipItemType)).Length;
        theEq = new EquipItemData[equipnum];
        SaveLoadManager.Instance.OnStartLoad += Load;
    }

    public void Init()
    {
        ClearAll();
    }

    public void Load()
    {
        SaveData data = SaveLoadManager.Instance.load;
        ClearAll();
        foreach (var equips in data.equipSave)
        {
            EquipItemData equip = DataManager.Instance.GetItem(equips.itemID) as EquipItemData;
            equip.enforce = equips.enforce;
            equip.isEquip = true;
            SetItem(ItemType.Equip, (int)equip.equipType, equip);
        }
    }

    public void Equip(ItemSlotUI _equipSlot)
    {
        EquipItemData origin = _equipSlot.currentItem as EquipItemData;
        EquipItemData target = theEq[(int)origin.equipType];
        if (target != null)
            target.isEquip = false;
        _equipSlot.SetItem(target);
        SetItem(ItemType.Equip, (int)origin.equipType, origin);
    }

    public void UnEquip(EquipItemType _equipType)
    {
        EquipItemData nData = theEq[(int)_equipType];
        nData.isEquip = false;
        theEq[(int)_equipType] = null;
        InvenManager.Instance.Add(nData);
        OnEquipChange?.Invoke();

    }



    public ItemData GetItem(ItemType itemType, int index)
    {
        return theEq[index];
    }
    public void SetItem(ItemType itemType, int index, ItemData item)
    {
        EquipItemData set = item as EquipItemData;
        if (set != null)
            set.isEquip = !set.isEquip;
        theEq[index] = set;
        OnEquipChange?.Invoke();
    }

    public void ClearItem(ItemType itemType, int index)
    {
        theEq[index] = null;
        OnEquipChange.Invoke();
    }
    public EquipItemData[] GetAll()
    {
        return theEq;
    }
    public void ClearAll()
    {
        for (int i = 0; i < theEq.Length; ++i)
        {
            theEq[i] = null;
        }
    }

    public ItemStat GetItemStat()
    {
        ItemStat restat = new ItemStat();
        for (int i = 0; i < theEq.Length; ++i)
        {
            EquipItemData equip = theEq[i];
            if (equip == null)
                continue;
            restat.atk += equip.itemAtk;
            restat.def += equip.itemDef;
            restat.maxHP += equip.itemHp;
        }
        return restat;
    }
}
