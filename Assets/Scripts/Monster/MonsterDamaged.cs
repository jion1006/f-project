using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterDamaged : MonoBehaviour, IMonsterState
{
    public MonsterStateType monsterState => MonsterStateType.Damaged;
    private Animator animator;
    private MonsterStateMachine monsterSM;

    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    public void Enter(MonsterController theMC, MonsterStateMachine theMS)
    {
        monsterSM = theMS;
        animator.CrossFade("Damaged Tree",0.05f);

        
        
    }

    public void Exit()
    {
        
    }


    public void SUpdate()
    {
        var anim = animator.GetCurrentAnimatorStateInfo(0);
        if (anim.IsName("Damaged Tree"))
        {
            if (anim.normalizedTime > 0.8f)
            {
                monsterSM.ChangeState(MonsterStateType.Move);
            }
        }
    }
}
