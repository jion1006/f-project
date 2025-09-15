using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillObject : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particle;
    [SerializeField]
    private BoxCollider2D box;

    private SkillData data;

    public void Init(SkillData _data)
    {
        data = _data;
    }
    void OnEnable()
    {
        box.enabled = false;
        particle.Play();
        StartCoroutine(StartSkill());
    }

    IEnumerator StartSkill()
    {
        yield return new WaitForSeconds(0.5f);
        box.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        var dmg = collision.GetComponent<IDamagable>();
        dmg.Damaged(data.damage);

    }
}
