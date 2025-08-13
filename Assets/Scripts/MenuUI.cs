using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    public GameObject total;

    public GameObject setting;

    public void OnResume()
    {
        UIManager.Instance.CloseUI(total, () =>
        {
            PlayerController.Instance.thePS.ChangeState(PlayerStateType.Move);
        });
    }

    public void OnSetting()
    {
        setting.SetActive(true);
    }

    public void OnTitle()
    {
        SaveLoadManager.Instance.Save();
        GameManager.Instance.ChangeScene("StartScene");
        total.SetActive(false);
    }
}
