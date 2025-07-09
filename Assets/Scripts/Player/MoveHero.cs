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
        animator.SetFloat("DirX", 1);
    }

    public void Enter(PlayerController thePC,PlayerStateMachine theSM)
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
            stateMachine.ChangeState(PlayerStateType.Inven);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            stateMachine.ChangeState(PlayerStateType.Attack);
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
}
