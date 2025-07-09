using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipUI : MonoBehaviour
{
    [SerializeField]
    public Image[] equipImg;

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
        for (int i = 0; i < equipImg.Length; ++i)
        {
            EquipItemData item = EquipManager.Instance.GetEquipItem((EquipItemType)i);
            equipImg[i].sprite = item != null ? item.icon : null;
            //equipImg[i].enabled = item != null;
        }
    }

    void ODisable()
    {
        EquipManager.Instance.OnEquipChange -= RefrashEUI;
    }
}
