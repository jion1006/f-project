using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EquipUI : MonoBehaviour
{
    [SerializeField]
    public ItemSlotUI[] equipItem;

    // Start is called before the first frame update

    // Update is called once per frame
    void Start()
    {
        foreach (var slot in equipItem)
        {
            slot.currentType = ItemType.Equip;
        }
    }
    void Update()
    {

    }

    void OnEnable()
    {
        EquipManager.Instance.OnEquipChange += RefrashEUI;
        RefrashEUI();
    }

    void RefrashEUI()
    {
        for (int i = 0; i < equipItem.Length; ++i)
        {
            equipItem[i].SetSlot(EquipManager.Instance, EquipManager.Instance.GetItem(ItemType.Equip, i), i);
            //equipImg[i].enabled = item != null;
        }
    }

    void ODisable()
    {
        EquipManager.Instance.OnEquipChange -= RefrashEUI;
    }
}
