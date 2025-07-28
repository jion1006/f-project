using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnforceUI : MonoBehaviour
{
    public ItemSlotUI enforceItem;
    private ItemData currentItemData;
    // Start is called before the first frame update
    void Start()
    {
        enforceItem.OnSlotChanged += ChangeEnforeSlot;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickEnforceButton()
    {
        
    }

    public void ChangeEnforeSlot(ItemData itemData)
    {
        currentItemData = itemData;
    }
}
