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

        Debug.Log("버튼누림");
        GameManager.Instance.ChangeScene("TownScene");
    }

    public void OnClickLoad()
    {

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
