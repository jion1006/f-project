using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject invenUI;
    public GameObject shopUI;

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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnInvenPanel()
    {
        invenUI.SetActive(true);
    }
    public void OnShopPanel()
    {
        shopUI.SetActive(true);
    }
    
    public void CloseUI(GameObject targetUI, Action close = null)
    {
        targetUI.SetActive(false);
        close.Invoke();
    }

    
}
