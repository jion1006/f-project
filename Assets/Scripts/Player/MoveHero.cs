using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class MoveHero : MovingObject, IPlayerState
{
    public PlayerStateType stateType => PlayerStateType.Move;
    public bool canMove;

    public BaseNPC nearNPC;
    private PlayerStateMachine stateMachine;



    void Start()
    {
        animator.SetFloat("DirX", 1);
    }

    public void Enter(PlayerController thePC, PlayerStateMachine theSM)
    {
        stateMachine = theSM;
        canMove = true;
    }
    public void Exit()
    {
        Stop();
        canMove = false;
    }
    public void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            stateMachine.ChangeState(PlayerStateType.UI);
            UIManager.Instance.OnInvenPanel();
        }
        if (Input.GetKeyDown(KeyCode.X) && nearNPC == null)
        {
            stateMachine.ChangeState(PlayerStateType.Attack);
        }
        if (Input.GetKeyDown(KeyCode.X) && nearNPC != null)
        {
            stateMachine.ChangeState(PlayerStateType.UI);
            nearNPC.OpenTargetUI();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            stateMachine.ChangeState(PlayerStateType.UI);
            UIManager.Instance.OnMenuPanel();
        }
    }


    // Update is called once per frame
    public void SUpdate()
    {
        if (canMove)
        {
            float hor = Input.GetAxisRaw("Horizontal");
            float ver = Input.GetAxisRaw("Vertical");
            Vector2 input = new Vector2(hor, ver);

            if (input != Vector2.zero)
            {
                Move(input);
            }
            else
            {
                Stop();
            }
        }
        else
        {
            Stop();
        }

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NPC")
            nearNPC = collision.GetComponent<BaseNPC>();
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<BaseNPC>() == nearNPC)
            nearNPC = null;
    }

    public void OnSkill(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (context.control is KeyControl keyCtrl)
            {
                Key code = keyCtrl.keyCode;
                if (SkillManager.Instance.StartSkill(code))
                    stateMachine.ChangeState(PlayerStateType.Skill);
            }
        }
        
    }
}
