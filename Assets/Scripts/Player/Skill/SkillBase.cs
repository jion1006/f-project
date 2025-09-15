using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public abstract class SkillBase : MonoBehaviour
{
    public Key key;
    [field:SerializeField]
    public SkillData skill { get; private set; }

    public abstract void StartSkill();

    public int GetUseMana()
    {
        return skill.useMp;
    }

    public float GetCool()
    {
        return skill.coolDown;
    }
}
