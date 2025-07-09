using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EquipManager : MonoBehaviour
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

    void Equip(EquipItemData _equipItem)
    {
        if (theEq[(int)_equipItem.equipType] == null)
        {
            theEq[(int)_equipItem.equipType] = _equipItem;
            OnEquipChange.Invoke();
        }
    }

    EquipItemData UnEquip(EquipItemType _equipType)
    {
        EquipItemData nData = theEq[(int)_equipType];
        theEq[(int)_equipType] = null;
        OnEquipChange.Invoke();
        return nData;
    }

    public EquipItemData GetEquipItem(EquipItemType _equipType)
    {
        return theEq[(int)_equipType];
    }
}
