using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIState : MonoBehaviour, IPlayerState
{
    public PlayerStateType stateType => PlayerStateType.UI;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void SUpdate()
    {

    }

    public void Enter(PlayerController thePC, PlayerStateMachine thePM)
    {

    }

    public void Exit()
    {

    }

    public void HandleInput()
    {
        
    }
}
