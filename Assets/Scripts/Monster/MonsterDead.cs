using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDead : MonoBehaviour, IMonsterState
{
    public MonsterStateType monsterState => MonsterStateType.Dead;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Enter(MonsterController theMC, MonsterStateMachine theMS)
    {
        animator.CrossFade("Dead",0.05f);

       
    }

    // Update is called once per frame
    public void SUpdate()
    {
        var anim = animator.GetCurrentAnimatorStateInfo(0);

        if (anim.IsName("Dead"))
        {
            if (anim.normalizedTime > 0.9f)
            {
                Destroy(gameObject);
            }
        }
    }


    public void Exit()
    {

    }
}
