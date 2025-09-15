using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        var dmg = collision.GetComponent<IDamagable>();
        int atk = playerController.GetTotal().atk;

        if (dmg != null)
        {
            dmg.Damaged(atk);
        }

    }

    
}
