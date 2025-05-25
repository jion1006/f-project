using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : MonoBehaviour,IPlayerState
{
    public PlayerStateType stateType => PlayerStateType.Attack;

    private Animator animator;
    private PlayerStateMachine stateMachine;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Enter(PlayerController thePC,PlayerStateMachine theSM)
    {
        stateMachine = theSM;
        animator.SetBool("Attack", true);
        StartCoroutine(waitTime());
    }
    public void Update()
    {
    }

    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(0.5f);
        stateMachine.ChangeState(PlayerStateType.Move);
    }

    public void HandleInput()
    {

    }

    public void Exit()
    {
        animator.SetBool("Attack", false);

    }




}
