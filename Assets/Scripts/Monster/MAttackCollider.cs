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

        if (other.CompareTag("Player"))
        {
            PlayerController.Instance.AttackDamaged(mosterCT.monsterStat.atk);
        }
    }
}
