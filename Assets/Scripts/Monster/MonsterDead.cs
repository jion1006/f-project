using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDead : MonoBehaviour, IMonsterState
{
    public MonsterStateType monsterState => MonsterStateType.Dead;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Enter(MonsterController theMC, MonsterStateMachine theMS)
    {
        animator.CrossFade("Dead",0.05f);

       
    }

    // Update is called once per frame
    public void SUpdate()
    {
       
    }

    public void OnDead()
    {
        Destroy(gameObject);
    }

    public void Exit()
    {

    }
}
