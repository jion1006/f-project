using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class InvenUI : MonoBehaviour
{
    [Serializable]
    public class InvenTab
    {
        public ItemType itemType;
        public Button button;
        public Image buttonImage;
        public Sprite activeImg;
        public Sprite unactiveImg;

    }

    [SerializeField]
    public List<InvenTab> invenTab;

    public InvenSlotUI[] invenSlotUIs;
    private ItemType currentType;

    void Start()
    {
        foreach (var tab in invenTab)
        {
            var clickTab = tab;
            tab.button.onClick.AddListener(() => OnTabSelect(clickTab));
        }
    }

    void OnEnable()
    {
        OnTabSelect(invenTab[0]);
        InvenManager.Instance.OnitemChanged += RefrashUI;
        RefrashUI();
    }

    void OnDisable()
    {
        InvenManager.Instance.OnitemChanged -= RefrashUI;
    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnTabSelect(InvenTab _tab)
    {
        currentType = _tab.itemType;
        foreach (var tab in invenTab)
        {
            tab.buttonImage.sprite = (tab.itemType == currentType) ? tab.activeImg : tab.unactiveImg;
        }
        RefrashUI();
    }


    void RefrashUI()
    {
        var array = InvenManager.Instance.GetItemArray(currentType);

        foreach (var slot in invenSlotUIs)
        {
            slot.Clear();
        }

        for (int i = 0; i < array.Length; ++i)
        {
            if(array[i]!=null)
                invenSlotUIs[i].SetItem(array[i]);
        }

    }

}
