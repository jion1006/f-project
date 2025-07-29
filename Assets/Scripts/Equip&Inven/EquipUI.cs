using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EquipUI : MonoBehaviour
{
    [SerializeField]
    public ItemSlotUI[] equipItem;

    // Start is called before the first frame update

    // Update is called once per frame
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
            EquipItemData item = EquipManager.Instance.GetEquipItem((EquipItemType)i);
            equipItem[i].icon.sprite = item != null ? item.icon : null;
            //equipImg[i].enabled = item != null;
        }
    }

    void ODisable()
    {
        EquipManager.Instance.OnEquipChange -= RefrashEUI;
    }
}
