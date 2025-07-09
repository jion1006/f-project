using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAttackCollider : MonoBehaviour
{
    PlayerController playerController;

    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            MonsterController ms = collision.GetComponent<MonsterController>();
            if (ms != null)
            {
                ms.Damaged(playerController.playerStat.atk);
            }
        }
    }
}
