using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InTown : MonoBehaviour
{
    private static bool isLoading = false;
    public GameObject playerSpawn;
    public BoxCollider2D townBound;
    public CameraManager cameraManager;
    // Start is called before the first frame update
    void Start()
    {
        if (isLoading)
        {
            PlayerController.Instance.transform.position = playerSpawn.transform.position;
        }
        else
        {
            isLoading = true;
        }

        townBound = GetComponent<BoxCollider2D>();
        cameraManager.SetBound(townBound);
        if (SaveLoadManager.Instance.isLoad)
            IsLoding();
    }

    public void IsLoding()
    {
        SaveData data = SaveLoadManager.Instance.load;
        InvenManager.Instance.ClearAll();
        foreach (var items in data.itemSave)
        {
            ItemData item = DataManager.Instance.GetItem(items.itemID);
            item.itemCount = items.itemCount;
            InvenManager.Instance.SetItem(item.itemType, items.index, item);
        }

        EquipManager.Instance.ClearAll();
        foreach (var equips in data.equipSave)
        {
            EquipItemData equip = DataManager.Instance.GetItem(equips.itemID) as EquipItemData;
            equip.enforce = equips.enforce;
            equip.isEquip = true;
            EquipManager.Instance.SetItem(ItemType.Equip, (int)equip.equipType, equip);
        }

    }
}
