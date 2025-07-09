using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedState : MonoBehaviour,IPlayerState
{
    public PlayerStateType stateType => PlayerStateType.Damaged;

    Animator animator;
    

    private PlayerStateMachine stateMachine;

    public void Enter(PlayerController thePC, PlayerStateMachine thePS)
    {
        stateMachine = thePS;
        animator.CrossFade("Damaged Tree", 0.05f);
    }
    public void Exit()
    {

    }
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void HandleInput()
    {

    }

    // Update is called once per frame
    public void SUpdate()
    {
        var anim = animator.GetCurrentAnimatorStateInfo(0);
        if (anim.IsName("Damaged Tree"))
        {
            if (anim.normalizedTime > 0.8f)
            {
                stateMachine.ChangeState(PlayerStateType.Move);
            }
        }

    }
}
