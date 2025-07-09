using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class MonsterController : MonoBehaviour
{

    [Header("탐지범위")]
    [SerializeField]
    private float detectRange = 5f;
    [Header("공격시작범위")]
    [SerializeField]
    private float attackRange = 3f;

    public float DetectRange => detectRange;
    public float AttackRange => attackRange;


    public MonsterStat monsterStat;
    [SerializeField]
    private int currentHp;
    [SerializeField]
    private int mID;

    public MonsterStateMachine mStateMachine;
    void Start()
    {
        var mdata = DataManager.Instance.GetMonsterStat(mID);
        monsterStat = mdata;
        mStateMachine = GetComponent<MonsterStateMachine>();
        currentHp = monsterStat.maxHp;
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }


    public void Damaged(int _playerAtk)
    {
        currentHp -= _playerAtk;
        if (currentHp <= 0)
            mStateMachine.ChangeState(MonsterStateType.Dead);
        else
            mStateMachine.ChangeState(MonsterStateType.Damaged);
        Debug.Log($"데미지 입음 {_playerAtk}");
    }
}
