using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNPC : BaseNPC
{
    public GameObject x;

    public override void OpenTargetUI()
    {
        PlayerController.Instance.thePS.ChangeState(PlayerStateType.UI);
        UIManager.Instance.OnQuestMenuPanel();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
            x.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
            x.SetActive(false);
    }
}
