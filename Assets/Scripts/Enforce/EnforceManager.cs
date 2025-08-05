using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnforceManager : MonoBehaviour, IItemContainer
{

    public static EnforceManager Instance;

    public event Action itemChange;

    private EquipItemData currentItemData;
    public Dictionary<int, float> enforceRate;
    private float successRate;
    // Start is called before the first frame update

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
        enforceRate = new Dictionary<int, float>()
        {

            { 0,1.00f},
            {1,0.90f},
            {2,0.80f},
            {3,0.70f},
            {4,0.60f},
            {5,0.50f},
            {6,0.40f},
            {7,0.30f},
            {8,0.20f},
        };
        currentItemData = null;
    }

   

    public void TryEnforce()
    {
        float ran = UnityEngine.Random.Range(0f, 1f);
        if (currentItemData.enforce > 8)
            return;
        successRate = enforceRate[currentItemData.enforce];
        if (ran < successRate)
        {
            Debug.Log("성공");
            currentItemData.enforce += 1;
        }
        itemChange?.Invoke();
    }
    public void OnEndEnforce()
    {
        if (currentItemData != null)
            InvenManager.Instance.Add(currentItemData);
        currentItemData = null;
    }

    public ItemData GetItem(ItemType itemType, int index)
    {
        return currentItemData;
    }
    public void SetItem(ItemType itemType, int index, ItemData item)
    {
        if (item != null)
            currentItemData = item as EquipItemData;
        else
            currentItemData = null;
        itemChange?.Invoke();
    }
    public void ClearItem(ItemType itemType, int index)
    {
        currentItemData = null;
        itemChange?.Invoke();
    }
}
