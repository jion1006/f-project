using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IDamagable
{
    public void Damaged(int _atk);
}

public class MonsterController : MonoBehaviour, IDamagable
{

    [Header("탐지범위")]
    [SerializeField]
    private float detectRange = 5f;
    [Header("공격시작범위")]
    [SerializeField]
    private float attackRange = 3f;

    public float DetectRange => detectRange;
    public float AttackRange => attackRange;

    public Action<int> hpChanged;

    public MonsterStat monsterStat;
    [SerializeField]
    private int currentHp;
    [SerializeField]
    private int mID;

    public GameObject hpBar;

    public MonsterStateMachine mStateMachine;
    void Start()
    {
        var mdata = DataManager.Instance.GetMonsterStat(mID);
        monsterStat = mdata;
        mStateMachine = GetComponent<MonsterStateMachine>();
        currentHp = monsterStat.maxHp;
        hpBar = PoolManager.Instance.GetHpbar();
        hpBar.GetComponent<MonsterHpBar>().SetTarget(this);
    }

    


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }


    public void Damaged(int _playerAtk)
    {
        currentHp = Mathf.Clamp(currentHp, 0, monsterStat.maxHp);
        currentHp -= _playerAtk;
        if (currentHp <= 0)
        {
            PoolManager.Instance.ReturnHpbar(hpBar);
            mStateMachine.ChangeState(MonsterStateType.Dead);
        }
        else
            mStateMachine.ChangeState(MonsterStateType.Damaged);
        hpChanged?.Invoke(currentHp);
    }
}
