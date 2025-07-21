using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InvenState : MonoBehaviour
{
    

    public GameObject go;

    private PlayerStateMachine stateMachine;
    public void Enter(PlayerController thePC, PlayerStateMachine theSM)
    {
        stateMachine = theSM;
        Time.timeScale = 0;
        go.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void SUpdate()
    {

    }

    public void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.I)||Input.GetKeyDown(KeyCode.Escape))
        {
            stateMachine.ChangeState(PlayerStateType.Move);
        }
    }

    public void Exit()
    {
        Time.timeScale = 1;
        go.SetActive(false);
    }
}
