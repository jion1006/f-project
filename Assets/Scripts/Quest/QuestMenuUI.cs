using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMenuUI : MonoBehaviour
{
    public GameObject total;
    public QuestSlot[] questSlots;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            OnCloseButton();


    }
    void OnEnable()
    {
        QuestManager.Instance.OnQuestChanged += RefreshUI;
        RefreshUI();
    }

    void OnDisable()
    {
        QuestManager.Instance.OnQuestChanged -= RefreshUI;
    }
    public void RefreshUI()
    {
        SlotDown();
        int count = 0;
        foreach (var data in QuestManager.Instance.GetAllQuest())
        {
            QuestData quest = data.Value;
            if (quest.questState != QuestState.Not && quest.questState != QuestState.End)
            {
                questSlots[count].gameObject.SetActive(true);
                questSlots[count].SetQuest(quest);
                count++;
            }
        }
    }

    void SlotDown()
    {
        foreach (QuestSlot slot in questSlots)
        {
            slot.gameObject.SetActive(false);
        }
    }

    public void OnCloseButton()
    {
        UIManager.Instance.CloseUI(total, () =>
        {
            PlayerController.Instance.thePS.ChangeState(PlayerStateType.Move);
        });
    }
}
