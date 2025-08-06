using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

        int equipnum = System.Enum.GetNames(typeof(EquipItemType)).Length;
        theEq = new EquipItemData[equipnum];
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
}
