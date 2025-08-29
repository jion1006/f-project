using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject invenUI;
    public GameObject shopUI;
    public GameObject enforceUI;
    public GameObject dragUI;
    public GameObject questMenuUI;
    public ItemInfoUI itemInfo;
    public GameObject menuUI;
    public static UIManager Instance;
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

    


    public void OnInvenPanel()
    {
        invenUI.SetActive(true);
    }
    public void OnShopPanel()
    {
        shopUI.SetActive(true);
    }
    public void OnEnforcePanel()
    {
        enforceUI.SetActive(true);
    }
    public void OnQuestMenuPanel()
    {
        questMenuUI.SetActive(true);
    }
    public void OnMenuPanel()
    {
        menuUI.SetActive(true);
    }

    public void OnTooltipPanel(ItemData _item, Vector2 _postion)
    {
        itemInfo.ShowTooltip(_item, _postion);
    }
    public void EndTooltip()
    {
        itemInfo.HideToolTip();
    }

    public void OnDragPanel(Sprite _sprite)
    {
        itemInfo.ShowDragPanel(_sprite);
    }
    public void Draging(Vector2 _postion)
    {
        itemInfo.MoveDrag(_postion);
    }
    public void EndDrag()
    {
        itemInfo.HideDrag();
    }

    public void CloseUI(GameObject targetUI, Action close = null)
    {
        targetUI.SetActive(false);
        close.Invoke();
    }
    

    
}
