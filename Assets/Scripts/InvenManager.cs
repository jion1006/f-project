using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InvenManager : MonoBehaviour
{
    private Dictionary<ItemType, ItemData[]> theItemL;
    // Start is called before the first frame update

    public static InvenManager Instance;
    

    public event Action OnitemChanged;
    public InvenInfoUI theInfo;

    public int slotsize = 40;


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
        theItemL = new Dictionary<ItemType, ItemData[]>();
        foreach(ItemType item in Enum.GetValues(typeof(ItemType)))
        {
            theItemL[item] = new ItemData[slotsize];
        }
        
    }

    public void Add(ItemData _item)
    {
        var array = theItemL[_item.itemType];
        for (int i = 0; i < array.Length; ++i)
        {
            if (array[i] == null)
            {
                array[i] = _item;
                break;
            }
        }
        OnitemChanged.Invoke();
    }

    public void ReMove(ItemData _item,int index)
    {
        theItemL[_item.itemType][index]=null;
    }
    // Update is called once per frame

    public ItemData[] GetItemArray(ItemType _itemType)
    {

        return theItemL[_itemType];
    }
}
