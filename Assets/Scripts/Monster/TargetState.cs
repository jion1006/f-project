using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetState : MovingObject, IMonsterState
{
    public MonsterStateType monsterState => MonsterStateType.Target;
    private MonsterController monsterCT;
    private MonsterStateMachine monsterMC;

    Coroutine targetC;
    float dist = 0f;
    Vector2 dir = Vector2.zero;
    public void Enter(MonsterController theMC, MonsterStateMachine theMS)
    {
        monsterCT = theMC;
        monsterMC = theMS;
        targetC = StartCoroutine(StartTarget());

    }

    public void Exit()
    {
        if (targetC != null)
        {
            StopCoroutine(targetC);
            targetC = null;
        }
        Debug.Log("타겟 나가기");
        Stop();
    }

    IEnumerator StartTarget()
    {
        while (true)
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
                break;
            }
            else
            {
                yield return null;
                Move(dir);
            }

            if (dist < monsterCT.AttackRange)
            {
                monsterMC.ChangeState(MonsterStateType.Attack);
                break;
            }
            yield return null;
        }
    }

    
}
