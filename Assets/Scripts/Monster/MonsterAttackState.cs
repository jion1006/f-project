using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackState : MonoBehaviour, IMonsterState
{
    public MonsterStateType monsterState => MonsterStateType.Attack;
    private Animator animator;
    private MonsterStateMachine monsterMS;
    [SerializeField]
    private BoxCollider2D atkColl;

    private Rigidbody2D rigid;

    public void Enter(MonsterController theMC, MonsterStateMachine theMS)
    {
        monsterMS = theMS;
        animator.SetBool("Run", false);
        monsterMS.StopAllCoroutines();
        rigid.velocity = Vector2.zero;
        animator.SetTrigger("Attack");
    }
    public void Exit()
    {
        atkColl.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();

    }

    public void ExitAttack()
    {
        monsterMS.ChangeState(MonsterStateType.Move);
    }
}
