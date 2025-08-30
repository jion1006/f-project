using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button button;
    public TextMeshProUGUI buttonText;
    public GameObject Long;

    private int questId;
    public TextMeshProUGUI questName;
    public TextMeshProUGUI shortDes;
    public TextMeshProUGUI longDes;


    public void SetQuest(QuestData quest)
    {
        questId = quest.questId;
        questName.text = quest.questName;
        shortDes.text = quest.shortDes;
        longDes.text = quest.longDes;
        button.onClick.RemoveAllListeners();

        if (quest.questState == QuestState.NoStart)
        {
            button.onClick.AddListener(OngoingButton);
            buttonText.text = "수락";
        }
        else if (quest.questState == QuestState.Claer)
        {
            button.onClick.AddListener(OnEndButton);
            buttonText.text = "완료";
        }
        else
        {
            buttonText.text = "진행중";
        }
    }

    public void OngoingButton()
    {
        QuestManager.Instance.GoingQuest(questId);
    }

    public void OnEndButton()
    {
        QuestManager.Instance.EndQuest(questId);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Long.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Long.SetActive(false);
    }
}
