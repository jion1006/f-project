using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



public class EquipUI : MonoBehaviour
{
    [SerializeField]
    public ItemSlotUI[] equipItem;

    public TextMeshProUGUI[] statL;

    void Start()
    {
        for (int i = 0; i < equipItem.Length; ++i)
        {
            equipItem[i].index = i;
        }
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
        }

        PlayerStat stat = PlayerController.Instance.playerStat;
        ItemStat itemStat = EquipManager.Instance.GetItemStat();
        statL[0].text = "ATK : " + (stat.atk + itemStat.atk).ToString();
        statL[1].text = "DEF : " + (stat.def + itemStat.def).ToString();
        statL[2].text = "HP : " +PlayerController.Instance.currentHp.ToString()+" / "+(stat.maxHp + itemStat.maxHP).ToString();
        statL[3].text = "Level : " + stat.level.ToString();

    }

    void OnDisable()
    {
        EquipManager.Instance.OnEquipChange -= RefrashEUI;
    }
    
}
