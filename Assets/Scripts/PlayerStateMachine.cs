using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IPlayerState
{
    PlayerStateType stateType{ get; }
    void Enter(PlayerController thePC);
    void Update();
    void Exit();
}

public enum PlayerStateType
{
    Move,
    Inven,
    Attack,

}
[System.Serializable]
public class PlaerStateEntry
{
    public PlayerStateType stateType;
    public MonoBehaviour behaviour;
}


public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField]
    private List<PlaerStateEntry> stateBehaviour;

    private Dictionary<PlayerStateType, IPlayerState> stateDI;

    public IPlayerState currentState;
    public PlayerStateType currentType;
    private PlayerController thePC;

    void Awake()
    {
        stateDI = new Dictionary<PlayerStateType, IPlayerState>();
        foreach (var std in stateBehaviour)
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
        currentState.Enter(thePC);

    }

    void Update()
    {
        currentState.Update();
    }


    public void changeState(PlayerStateType _thePST)
    {
        currentState?.Exit();
        currentType = _thePST;
        currentState = stateDI[_thePST];
        currentState.Enter(thePC);
    }

}
