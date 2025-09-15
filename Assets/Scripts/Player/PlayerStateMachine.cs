using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IPlayerState
{
    PlayerStateType stateType { get; }
    void Enter(PlayerController thePC, PlayerStateMachine theSM);
    void SUpdate();
    void Exit();
    void HandleInput();
}

public enum PlayerStateType
{
    Move,
    UI,
    Attack,
    Damaged,
    Skill,
    Dead,
    

}
[Serializable]
public class PlayerStateEntry
{
    public PlayerStateType stateType;
    public MonoBehaviour behaviour;
}


public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField]
    private List<PlayerStateEntry> stateList;

    private Dictionary<PlayerStateType, IPlayerState> stateDI;

    public IPlayerState currentState;
    public PlayerStateType currentType;
    private PlayerController thePC;

    void Awake()
    {
        stateDI = new Dictionary<PlayerStateType, IPlayerState>();
        foreach (var std in stateList)
        {
            if (std.behaviour is IPlayerState state)
                stateDI[state.stateType] = state;
        }
    }
    void Start()
    {
        thePC = FindObjectOfType<PlayerController>();
        currentType = PlayerStateType.Move;
        currentState = stateDI[currentType];
        currentState.Enter(thePC,this);

    }

    void Update()
    {
        currentState.SUpdate();
    }


    public void ChangeState(PlayerStateType _thePST)
    {
        currentState?.Exit();
        currentType = _thePST;
        currentState = stateDI[_thePST];
        currentState.Enter(thePC,this);
    }

}
