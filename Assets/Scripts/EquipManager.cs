using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    public EquipItemData[] theEq;
    public GameObject[] go;
    // Start is called before the first frame update
    void Awake()
    {
        int equipnum = System.Enum.GetNames(typeof(equipItemType)).Length;
        theEq = new EquipItemData[equipnum];
    }

    void Equip(EquipItemData _equipItem)
    {

    }

    void UnEquip(equipItemType _equipType)
    {
        
    }
}
