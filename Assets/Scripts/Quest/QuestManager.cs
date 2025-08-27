using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private Dictionary<int, QuestData> activeQuest = new();
    void Awake()
    {

    }


    public void SetQuest(int _id)
    {
        activeQuest[_id] = DataManager.Instance.GetQuest(_id);
    }

    public void GoingQuest()
    {

    }

}
