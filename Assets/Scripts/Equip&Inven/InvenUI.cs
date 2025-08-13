using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public ItemSlotUI[] invenSlotUIs;

    public GameObject total;
    private ItemType currentType;

    public TextMeshProUGUI coinText;
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
        Time.timeScale = 0f;
    }

    void OnDisable()
    {
        InvenManager.Instance.OnitemChanged -= RefrashUI;
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            OnCloseButton();
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
            //if (array[i] != null)
            invenSlotUIs[i].currentType = currentType;
            invenSlotUIs[i].SetSlot(InvenManager.Instance, array[i], i);
            if (array[i] != null)
                invenSlotUIs[i].icon.color = new Color(1f, 1f, 1f, 1f);
        }
        coinText.text = PlayerController.Instance.playerStat.coin.ToString();
    }

    public void OnCloseButton()
    {
        UIManager.Instance.CloseUI(total, () =>
        {
            PlayerController.Instance.thePS.ChangeState(PlayerStateType.Move);
        });
    }


    
}
