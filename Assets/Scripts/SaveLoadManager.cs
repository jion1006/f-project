using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;

[Serializable]
public class SaveData
{
    public PlayerStat playerStat;
    public List<ItemSaveData> itemSave;
    public List<EquipSaveData> equipSave;
}

[Serializable]
public class ItemSaveData
{
    public int itemID;
    public int itemCount;
    public int index;
}

[Serializable]
public class EquipSaveData
{
    public int itemID;
    public int enforce;
}

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager Instance;

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

    public void Save()
    {
        SaveData save = new SaveData();

        PlayerStat stat = PlayerController.Instance.playerStat;
        save.playerStat = new PlayerStat
        {
            maxHp = stat.maxHp,
            maxMp = stat.maxMp,
            maxExp=stat.maxExp,
            atk = stat.atk,
            def = stat.def,
            level=stat.level,
            coin = stat.coin
        };

        save.itemSave = new List<ItemSaveData>();
        foreach (var pair in InvenManager.Instance.GetAll())
        {
            ItemType type = pair.Key;
            ItemData[] array = pair.Value;
            for (int i = 0; i < array.Length; ++i)
            {
                ItemData item = array[i];
                if (item != null)
                {
                    save.itemSave.Add(new ItemSaveData
                    {
                        itemID = item.itemID,
                        itemCount = item.itemCount,
                        index = i
                    });
                }
            }
        }

        save.equipSave = new List<EquipSaveData>();
        foreach (var equip in EquipManager.Instance.GetAll())
        {
            if (equip != null)
            {
                save.equipSave.Add(new EquipSaveData
                {
                    itemID = equip.itemID,
                    enforce = equip.enforce
                });
            }
        }


        string json = JsonUtility.ToJson(save, true);
        Debug.Log(Application.persistentDataPath);
        File.WriteAllText(Application.persistentDataPath + "/save.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/save.json";
        if (!File.Exists(path))
            return;

        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        PlayerStat stat = PlayerController.Instance.playerStat;
        stat.maxHp = data.playerStat.maxHp;
        stat.maxMp = data.playerStat.maxMp;
        stat.maxExp = data.playerStat.maxExp;
        stat.atk = data.playerStat.atk;
        stat.def = data.playerStat.def;
        stat.level = data.playerStat.level;

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
