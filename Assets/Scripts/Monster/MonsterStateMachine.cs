using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterStateType
{
    Move,
    Target,
    Attack,
    Damaged,
    Dead,
}

public interface IMonsterState
{
    MonsterStateType monsterState { get; }
    void Enter(MonsterController theMC, MonsterStateMachine theMS);
    void SUpdate();
    void Exit();
}

[Serializable]
public class MonsterStateEntry
{
    public MonsterStateType MstateType;
    public MonoBehaviour monoBehaviour;
}



public class MonsterStateMachine : MonoBehaviour
{
    [SerializeField]
    private List<MonsterStateEntry> stateList;

    private Dictionary<MonsterStateType, IMonsterState> stateDI;

    private IMonsterState currentState;

    [SerializeField]
    private MonsterStateType currentType;
    private MonsterController monsterController;
    // Start is called before the first frame update
    void Awake()
    {
        stateDI = new Dictionary<MonsterStateType, IMonsterState>();
        foreach (var std in stateList)
        {
            if (std.monoBehaviour is IMonsterState state)
                stateDI[state.monsterState] = state;
        }
    }

    void Start()
    {
        monsterController = GetComponent<MonsterController>();
        currentType = MonsterStateType.Move;
        currentState = stateDI[currentType];
        currentState.Enter(monsterController, this);
        Debug.Log("몬스터 초기화");
    }

    // Update is called once per frame
    void Update()
    {
        currentState.SUpdate();
    }

    public void ChangeState(MonsterStateType _monsterState)
    {
        currentState.Exit();
        currentType = _monsterState;
        currentState = stateDI[currentType];
        currentState.Enter(monsterController, this);
    }

    public bool IsNotCurrent(MonsterStateType _state)
    {
        return currentType != _state;
    }

}
