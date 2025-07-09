using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : MonoBehaviour,IPlayerState
{
    public PlayerStateType stateType => PlayerStateType.Dead;

    private Animator animator;

    public void Enter(PlayerController thePC, PlayerStateMachine theePS)
    {
        animator.CrossFade("Dead", 0.05f);
        
        
    }

    public void Exit()
    {

    }
    public void HandleInput()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void SUpdate()
    {
        var anim = animator.GetCurrentAnimatorStateInfo(0);
        if (anim.IsName("Dead"))
        {
            if (anim.normalizedTime > 0.9f)
                Destroy(this.gameObject);
        }
    }
}
