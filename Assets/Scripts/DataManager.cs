using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataManager : MonoBehaviour
{

    [SerializeField]
    private List<MonsterStat> LMstate;
    [SerializeField]
    private List<ItemData> LItem;
    [SerializeField]
    private PlayerStat playerStat;
    [SerializeField]
    private List<QuestData> LQuest;


    private Dictionary<int, MonsterStat> DMstate;
    private Dictionary<int, ItemData> DItem;
    private Dictionary<int, QuestData> DQuest;
    public static DataManager Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        DMstate = LMstate.ToDictionary(stat => stat.ID);
        DItem = LItem.ToDictionary(item => item.itemID);
        DQuest = LQuest.ToDictionary(quest => quest.questId);
    }

    public void Start()
    {
    }


    public MonsterStat GetMonsterStat(int _ID)
    {
        var MStat = DMstate[_ID];
        if (MStat != null)
            return MStat;
        return null;
    }

    public PlayerStat GetPlayerStat()
    {
        return playerStat;
    }

    public ItemData GetItem(int _id)
    {
        var item = DItem[_id];
        if (item != null)
        {
            ItemData RItem = Instantiate(item);
            return RItem;
        }

        return null;
    }

    public QuestData GetQuest(int _id)
    {
        var quest = DQuest[_id];
        if (quest != null)
        {
            QuestData RQuest = Instantiate(quest);
            return RQuest;
        }
        return null;
    }
}
