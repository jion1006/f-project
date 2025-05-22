using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenState : MonoBehaviour, IPlayerState
{
    public PlayerStateType stateType => PlayerStateType.Inven;

    public GameObject go;
    public void Enter(PlayerController thePC)
    {
        Time.timeScale = 0;
        go.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {

    }

    public void Exit()
    {
        Time.timeScale = 1;
        go.SetActive(false);
    }
}
