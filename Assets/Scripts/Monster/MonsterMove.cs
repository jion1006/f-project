using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MovingObject, IMonsterState
{
    public MonsterStateType monsterState => MonsterStateType.Move;
    private MonsterStateMachine stateMachine;
    private MonsterController monsterCT;

    void Start()
    {
        animator.SetFloat("DirX", -1);
    }

    public void Enter(MonsterController theMC, MonsterStateMachine theMS)
    {
        monsterCT = theMC;
        stateMachine = theMS;
        StartCoroutine(StartMove());
    }
    

    IEnumerator StartMove()
    {
        yield return new WaitForSeconds(1f);

        Vector2[] direct = new Vector2[]
        {
            Vector2.up,
            Vector2.down,
            Vector2.left,
            Vector2.right
        };

        while (!DetectPlayer())
        {
            int randir = Random.Range(0, direct.Length);
            yield return StartCoroutine(Moving(direct[randir]));
            yield return new WaitForSeconds(2f);
        }
        Stop();
        stateMachine.ChangeState(MonsterStateType.Target);


    }

    public void Exit()
    {
        StopAllCoroutines();
        Stop();
    }


    bool DetectPlayer()
    {
        bool isTarget = false;
        float dist = 0f;
        if (PlayerController.Instance)
        {
            dist = Vector2.Distance(PlayerController.Instance.transform.position, transform.position);
        }

        if (dist < monsterCT.DetectRange)
            isTarget = true;
        else
            isTarget = false;

        return isTarget;
    }


    IEnumerator Moving(Vector2 dir)
    {
        float time = 0f;

        while (time < 1f)
        {
            Move(dir);
            time += Time.deltaTime;
            yield return null;
        }
        Stop();
    }
    

}
