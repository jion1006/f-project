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
        ItemStat itemStat = EquipManager.Instance.GetItemStat();
        int atk = playerController.playerStat.atk + itemStat.atk;

        if (dmg != null)
        {
            StartCoroutine(DmgCoroutine(atk, 1f));
            dmg.Damaged(atk);
        }

    }

    IEnumerator DmgCoroutine(int _atk,float duration)
    {
        float tTime = 0f;
        
        Vector3 startpostion = transform.position;
        Vector3 endposstion = transform.position + new Vector3(0, 1f, 0);
        GameObject dmgText = PoolManager.Instance.GetDamageT();
        while (tTime < duration)
        {
            tTime += Time.deltaTime;
            float ratio = tTime / duration;
            dmgText.GetComponent<DamageText>().SetTransform(Vector3.Lerp(startpostion,endposstion, ratio), _atk);
            yield return null;
        }
        

        PoolManager.Instance.ReturnDText(dmgText);
    }
}
