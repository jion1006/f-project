using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    public static QuestManager Instance;

    [SerializeField]
    private List<QuestData> LQuest;

   
    private Dictionary<int, QuestData> DQuest = new Dictionary<int, QuestData>();
    private Dictionary<int, QuestData> activeQuest=new Dictionary<int, QuestData>();

    public event Action OnQuestChanged;
    public event Action<int> OnItemQuest;
    public event Action<int> OnKillQuest;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        SetAllQuest();
    }


    public void SetAllQuest()
    {
        foreach (QuestData quest in LQuest)
        {
            DQuest[quest.questId] = Instantiate(quest);
        }
    }

    public void GoingQuest(int _id)
    {
        DQuest[_id].questState = QuestState.OnGoing;
        DQuest[_id].StartQuest();
        DQuest[_id].OnClearQuest += ClearQuest;
        activeQuest[_id]=DQuest[_id];
        OnQuestChanged?.Invoke();
    }
    public void ClearQuest(int _id)
    {
        DQuest[_id].questState = QuestState.Claer;
    }

    public void EndQuest(int _id)
    {
        QuestData data = DQuest[_id];
        data.questState = QuestState.End;
        DQuest[_id].OnClearQuest -= ClearQuest;
        data.GetReward();
        data.EndQuest();
        activeQuest.Remove(_id);
        foreach (int nId in data.nextQuest)
        {
            DQuest[nId].questState = QuestState.NoStart;
        }
        OnQuestChanged?.Invoke();
    }

    public void ItemGet(int _id)
    {
        OnItemQuest?.Invoke(_id);
        OnQuestChanged?.Invoke();

    }

    public void KillGet(int _id)
    {
        OnKillQuest?.Invoke(_id);
        OnQuestChanged?.Invoke();

    }

    public Dictionary<int, QuestData> GetActiveQuest()
    {
        return activeQuest;
    }

    public Dictionary<int, QuestData> GetAllQuest()
    {
        return DQuest;
    }
}
