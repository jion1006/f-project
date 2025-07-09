using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : MonoBehaviour,IPlayerState
{
    public PlayerStateType stateType => PlayerStateType.Attack;

    private Animator animator;
    private PlayerStateMachine stateMachine;
    private Rigidbody2D rigid;

    private int comboStep = 0;
    private float comboTime = 0.7f;
    private float timer;
    private bool isInput = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Enter(PlayerController thePC, PlayerStateMachine theSM)
    {
        stateMachine = theSM;
        comboStep = 1;
        isInput = false;
        timer = 0f;
        rigid.velocity = Vector2.zero;
        animator.SetBool("Run", false);
        animator.SetTrigger("Attack1");
    }
    

    public void SUpdate()
    {
        timer += Time.deltaTime;
        var currenAnim = animator.GetCurrentAnimatorStateInfo(0);

        if (comboStep == 1 && timer >= 0.2f && timer <= comboTime)
        {

            if (Input.GetKeyDown(KeyCode.X))
            {
                isInput = true;
            }

            if (currenAnim.normalizedTime > 0.9f && isInput)
            {
                timer = 0f;
                animator.SetTrigger("Attack2");
                comboStep = 2;
            }
        }

        if (comboStep == 1 && timer > comboTime)
        {
            stateMachine.ChangeState(PlayerStateType.Move);
        }

        if (comboStep == 2 && currenAnim.IsName("Attack2 Tree") && currenAnim.normalizedTime > 0.95f)
        {
            stateMachine.ChangeState(PlayerStateType.Move);
        }
    }


    public void HandleInput()
    {
    }

    public void Exit()
    {
        animator.ResetTrigger("Attack1");
        animator.ResetTrigger("Attack2");

    }




}
