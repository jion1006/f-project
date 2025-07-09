using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    Rigidbody2D rigid;

    protected
    Animator animator;



    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move(Vector2 _direction)
    {
        float minMove = 0.2f;

        Vector2 dir = new Vector2(
            Mathf.Abs(_direction.x)<minMove ? 0 : (_direction.x > 0 ? 1 : -1),
            Mathf.Abs(_direction.y) < minMove ? 0 : (_direction.y > 0 ? 1 : -1)
        );
        float hor = dir.x;
        animator.SetBool("Run", true);
        if (hor != 0)
            animator.SetFloat("DirX", hor);
        rigid.velocity = dir * speed;
    }

    public void Stop()
    {
        animator.SetBool("Run", false);
        rigid.velocity = Vector2.zero;
    }
    

}
