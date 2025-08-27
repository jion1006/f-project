using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAttackCollider : MonoBehaviour
{
    MonsterController mosterCT;

    void Start()
    {
        mosterCT = GetComponentInParent<MonsterController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var dmg = other.GetComponent<IDamagable>();
        if(dmg!=null)
            dmg.Damaged(mosterCT.monsterStat.atk);
    }
    
}
