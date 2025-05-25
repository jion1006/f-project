using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class MoveHero : MovingObject, IPlayerState
{
    public PlayerStateType stateType=>PlayerStateType.Move;
    public bool canMove;
    // Start is called before the first frame update

    private PlayerStateMachine stateMachine;
   
    void Start()
    {
        
    }

    public void Enter(PlayerController thePC,PlayerStateMachine theSM)
    {
        stateMachine = theSM;
        canMove = true;
    }
    public void Exit()
    {
        canMove = false;
    }
    public void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            stateMachine.ChangeState(PlayerStateType.Inven);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            stateMachine.ChangeState(PlayerStateType.Attack);
        }
    }


    // Update is called once per frame
    public void Update()
    {
        if (canMove)
        {
            float hor = Input.GetAxisRaw("Horizontal");
            float ver = Input.GetAxisRaw("Vertical");
            Vector2 input = new Vector2(hor, ver);

            if (input != Vector2.zero)
            {
                animator.SetBool("Run", true);
                if (hor != 0)
                    animator.SetFloat("DirX", input.x);
                Move(input);
            }
            else
            {
                animator.SetBool("Run", false);
                Stop();
            }
        }
        else
        {
            animator.SetBool("Run", false);
            Stop();
        }

    }
}
