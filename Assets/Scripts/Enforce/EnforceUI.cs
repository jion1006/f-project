using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnforceUI : MonoBehaviour
{
    public GameObject total;

    public ItemSlotUI enforceSlot;

    public List<ItemSlotUI> itemSlots;

    private int currentLevel;
    public TextMeshProUGUI enforceText;

    

    // Start is called before the first frame update
    void Start()
    {
    
    }
    void OnEnable()
    {
        EnforceManager.Instance.itemChange += RefreshEnforceUI;
        InvenManager.Instance.OnitemChanged += RefreshEnforceUI;
        RefreshEnforceUI();
    }
    void OnDisable()
    {
        EnforceManager.Instance.itemChange -= RefreshEnforceUI;
        InvenManager.Instance.OnitemChanged -= RefreshEnforceUI;

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            OnEndEnforceUI();
    }

    public void OnClickEnforceButton()
    {

        EnforceManager.Instance.TryEnforce();
    }

    

    

    public void RefreshEnforceUI()
    {
        EquipItemData itemData = EnforceManager.Instance.GetItem(ItemType.Equip, 0) as EquipItemData;
        enforceSlot.SetSlot(EnforceManager.Instance, itemData, 0);
        if (itemData != null)
        {
            currentLevel = itemData.enforce;
            float successRate = EnforceManager.Instance.enforceRate[currentLevel];
            int percent = Mathf.RoundToInt(successRate * 100f);
            enforceText.text = $"현재 강화 : {currentLevel}\n강화 확률 : {percent}%";
        }
        else
        {
            enforceText.text = "";
        }

        var array = InvenManager.Instance.GetItemArray(ItemType.Equip);

        for (int i = 0; i < array.Length; ++i)
        {
            itemSlots[i].SetSlot(InvenManager.Instance, array[i], i);
            itemSlots[i].currentType = ItemType.Equip;
        }
    }

    public void OnEndEnforceUI()
    {
        EnforceManager.Instance.OnEndEnforce();
        RefreshEnforceUI();
        UIManager.Instance.CloseUI(total, () =>
        {
            PlayerController.Instance.thePS.ChangeState(PlayerStateType.Move);
        });
    }


    
    
}
