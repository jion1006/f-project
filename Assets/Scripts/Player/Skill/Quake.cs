using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quake : SkillBase
{
    [SerializeField]
    private SkillObject vfxPref;
    private SkillObject vfx;

    void Awake()
    {
        if (vfx == null)
            vfx = Instantiate(vfxPref,transform);
    }
    public override void StartSkill()
    {
        
        vfx.Init(skill);
        PlayerController.Instance.SkilAnimation(skill.skillName);
        Transform transform=PlayerController.Instance.transform;
        if (transform.rotation.y == 0)
        {
            vfx.transform.rotation = transform.rotation;
            vfx.transform.position = new Vector3(transform.position.x + 6f, transform.position.y+2f, 0);
        }
        else
        {
            vfx.transform.rotation = transform.rotation;
            vfx.transform.position = new Vector3(transform.position.x - 6f, transform.position.y+2f, 0);
        }
        vfx.gameObject.SetActive(true);

        
    }
}
