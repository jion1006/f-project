using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;


//퀘스트의 상태를 나타내기위한 enum값
[Serializable]
public enum QuestState
{
    Not,
    NoStart,
    OnGoing,
    Claer,
    End,
}
[Serializable]
public enum QuestType
{
    Kill,
    Get,
}

[Serializable]
[CreateAssetMenu(fileName = "Quest", menuName = "AddQuest")]
public class QuestData : ScriptableObject
{
    public QuestState questState = QuestState.Not;
    public int questId = -1;

    public int getEXP;
    public int[] RewarditemID;

    public event Action<int> OnClearQuest;
    public event Action<int> OnCountChanged;

    //퀘스트 타입
    public QuestType questType;
    //퀘스트 타입에 따른 몬스터 또는 아이템 ID 및 카운트
    public int id;
    [HideInInspector]public int currentCount = 0;
    [SerializeField]
    public int targetCount = 0;


    //퀘스트UI에 들어가는 설명
    public string questName;
    public string shortDes;
    public string longDes;

    //퀘스트 진행 후 연계 되는 퀘스트
    public int[] nextQuest;

    public void GetCount(int _id)
    {
        if (id == _id)
            currentCount++;
        if (currentCount >= targetCount)
            OnClearQuest?.Invoke(questId);
        OnCountChanged?.Invoke(questId);

    }

    public void StartQuest()
    {
        if (questType == QuestType.Kill)
            QuestManager.Instance.OnKillQuest += GetCount;
        else if (questType == QuestType.Get)
            QuestManager.Instance.OnItemQuest += GetCount;
    }

    public void EndQuest()
    {
        QuestManager.Instance.OnItemQuest -= GetCount;
        QuestManager.Instance.OnKillQuest -= GetCount;
    }
    public void GetReward()
    {
        PlayerController.Instance.GetExp(getEXP);
        foreach (int id in RewarditemID)
        {
            InvenManager.Instance.Add(DataManager.Instance.GetItem(id));
        }
    }
}
