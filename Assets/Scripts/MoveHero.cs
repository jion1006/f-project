using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHero : MovingObject, IPlayerState
{
    public PlayerStateType stateType=>PlayerStateType.Move;
    public bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
    }

    public void Enter()
    {
        canMove = true;
    }
    public void Exit()
    {
        canMove = false;
    }
    // Update is called once per frame
    void Update()
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

        /*if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            move("UP");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            move("DOWN");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            move("RIGHT");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            move("LEFT");
        }*/
    }
}
