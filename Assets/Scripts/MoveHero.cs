using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHero : MovingObject
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(hor, ver);

        if (input != Vector2.zero)
        {
            animator.SetBool("Run", true);
            if(hor!=0)
                animator.SetFloat("DirX", input.x);
            Move(input);
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
