using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetState : MovingObject, IMonsterState
{
    public MonsterStateType monsterState => MonsterStateType.Target;
    private MonsterController monsterCT;
    private MonsterStateMachine monsterMC;
    float dist = 0f;
    Vector2 dir = Vector2.zero;
    public void Enter(MonsterController theMC, MonsterStateMachine theMS)
    {
        monsterCT = theMC;
        monsterMC = theMS;


    }

    public void Exit()
    {
        Stop();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void SUpdate()
    {
        if (PlayerController.Instance)
        {
            dist = Vector2.Distance(PlayerController.Instance.transform.position, transform.position);
            dir = PlayerController.Instance.transform.position - transform.position;
        }
        
       
        if (dist > monsterCT.DetectRange + 0.5f)
        {
            Stop();
            monsterMC.ChangeState(MonsterStateType.Move);
        }
        else
            Move(dir);

        if (dist < monsterCT.AttackRange)
            monsterMC.ChangeState(MonsterStateType.Attack);
    }

}
