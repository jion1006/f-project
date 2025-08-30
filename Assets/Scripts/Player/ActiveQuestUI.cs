using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveQuestUI : MonoBehaviour
{
    public ActiveQuestSlot[] slots;

    void Start()
    {
        QuestManager.Instance.OnQuestChanged += RefreshUI;
        RefreshUI();
    }

    public void RefreshUI()
    {
        AllslotClear();
        Dictionary<int, QuestData> active = QuestManager.Instance.GetActiveQuest();
        int i = 0;
        foreach (var data in active)
        {
            slots[i].gameObject.SetActive(true);
            QuestData quest = data.Value;
            slots[i].questName.text = quest.questName;
            slots[i].questCount.text = $"{quest.currentCount} / {quest.targetCount}";
            i++;

        }
    }

    void AllslotClear()
    {
        foreach (ActiveQuestSlot slot in slots)
        {
            slot.gameObject.SetActive(false);        
        }
    }
}
