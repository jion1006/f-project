using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : SkillBase
{
    [SerializeField]
    private SkillObject vfxPref;
    private SkillObject[] vfxs;

    private float skillSpace = 2f;
    private int skillCount = 3;
    void Awake()
    {
        vfxs = new SkillObject[3];
        for (int i = 0; i < skillCount; ++i)
        {
            vfxs[i] = Instantiate(vfxPref,transform);
        }    
    }
    public override void StartSkill()
    {
        PlayerController.Instance.SkilAnimation(skill.skillName);
        Transform trans = PlayerController.Instance.transform;
        for (int i = 0; i < skillCount; ++i)
        {
            vfxs[i].Init(skill);
            if (trans.rotation.y == 0)
                vfxs[i].transform.position = new Vector3(trans.position.x + skillSpace * (i + 1), trans.position.y+2f, trans.position.z);
            else
                vfxs[i].transform.position = new Vector3(trans.position.x - skillSpace * (i + 1), trans.position.y+2f, trans.position.z);
            vfxs[i].transform.rotation = trans.rotation;
            vfxs[i].gameObject.SetActive(true);
        }

    }
}
