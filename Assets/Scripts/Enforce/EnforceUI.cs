using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnforceUI : MonoBehaviour, IItemContainer
{
    public GameObject total;
    public ItemSlotUI enforceItem;
    private EquipItemData currentItemData;

    Dictionary<int, float> enforceRate;
    private float successRate;
    private int currentLevel;
    public TextMeshProUGUI enforceText;

    public List<ItemSlotUI> itemSlots;

    // Start is called before the first frame update
    void Start()
    {
        enforceRate = new Dictionary<int, float>()
        {
            {0,1.00f},
            {1,0.90f},
            {2,0.80f},
            {3,0.70f},
            {4,0.60f},
            {5,0.50f},
            {6,0.40f},
            {7,0.30f},
            {8,0.20f},
        };
        enforceItem.currentType = ItemType.Equip;
        enforceItem.itemContainer = this;
    }
    void OnEnable()
    {
        var array = InvenManager.Instance.GetItemArray(ItemType.Equip);
        for (int i = 0; i < array.Length; ++i)
        {
            if (array[i] != null)
                itemSlots[i].SetSlot(InvenManager.Instance,array[i], i);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            OnEndEnforceUI();
    }

    public void OnClickEnforceButton()
    {
        if (TryEnforce())
        {
            currentItemData.enforce += 1;
        }

        RefreshEnforceUI();
    }

    bool TryEnforce()
    {
        float ran = Random.Range(0f, 1f);
        return ran < successRate;
    }

    public void ChangeEnforceSlot()
    {
        currentItemData = enforceItem.currentItem as EquipItemData;
        RefreshEnforceUI();
    }

    public void RefreshEnforceUI()
    {
        currentLevel = currentItemData.enforce;
        successRate = enforceRate[currentLevel];
        if (currentItemData != null)
        {
            int percent = Mathf.RoundToInt(successRate * 100f);
            enforceText.text = $"현재 강화 : {currentLevel} 강화 확률 : {percent}%";
        }
        else
        {
            enforceText.text = "";
        }
    }

    public void OnEndEnforceUI()
    {
        InvenManager.Instance.Add(currentItemData);
        currentItemData = null;
        RefreshEnforceUI();
        UIManager.Instance.CloseUI(total, () =>
        {
            PlayerController.Instance.thePS.ChangeState(PlayerStateType.Move);
        });
    }


    public ItemData GetItem(ItemType itemType, int index)
    {
        return currentItemData;
    }
    public void SetItem(ItemType itemType, int index, ItemData item)
    {
        currentItemData = item as EquipItemData;
    }
    public void ClearItem(ItemType itemType, int index)
    {
        currentItemData = null;
    }
}
