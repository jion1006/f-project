using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IPlayerState
{
    PlayerStateType stateType{ get; }
    void Enter();
    void Exit();
}

public enum PlayerStateType
{
    Move,
    Inven,
    Attack,

}

public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField]
    private List<MonoBehaviour> stateBehaviour;

    private Dictionary<PlayerStateType, IPlayerState> stateDI;

    private IPlayerState currentState;

    void Awake()
    {
        stateDI = new Dictionary<PlayerStateType, IPlayerState>();
        foreach (var std in stateBehaviour)
        {
            if (std is IPlayerState state)
                stateDI[state.stateType] = state;
        }
        currentState = stateDI[PlayerStateType.Move];
    }
    void Start()
    {
        currentState.Enter();
    }

    void Update()
    {

    }


    public void changeState(PlayerStateType _thePST)
    {
        currentState?.Exit();
        currentState = stateDI[_thePST];
        currentState.Enter();
    }

}
