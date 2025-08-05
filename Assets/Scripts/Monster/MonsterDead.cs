using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDead : MonoBehaviour, IMonsterState
{
    public MonsterStateType monsterState => MonsterStateType.Dead;
    private Animator animator;

    public event Action OnDeadEvent;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Enter(MonsterController theMC, MonsterStateMachine theMS)
    {
        animator.CrossFade("Dead",0.05f);

       
    }



    public void OnDead()
    {
        OnDeadEvent?.Invoke();
        Destroy(gameObject);
    }

    public void Exit()
    {

    }
}
