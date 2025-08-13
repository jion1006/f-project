using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TitleUI : MonoBehaviour
{
    public GameObject optionGo;

    public void OnClickStart()
    {

        GameManager.Instance.ChangeScene("TownScene");
    }

    public void OnClickLoad()
    {
        SaveLoadManager.Instance.Load();
    }

    public void OnClickOption()
    {
        optionGo.SetActive(true);
    }

    public void OnClickExit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}
