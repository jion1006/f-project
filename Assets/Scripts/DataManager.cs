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


    private Dictionary<int, MonsterStat> DMstate;

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
}
