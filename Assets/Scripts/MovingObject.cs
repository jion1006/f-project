using System.Collections;
using System.Collections.Generic;
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
        animator.SetFloat("DirX", 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move(Vector2 _direction)
    {
        Vector2 dir = _direction.normalized;
        rigid.velocity = dir * speed;
    }

    public void Stop()
    {
        rigid.velocity = Vector2.zero;
    }
    

}
