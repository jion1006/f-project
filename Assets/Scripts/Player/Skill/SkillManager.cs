using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance;
    [SerializeField]
    private List<SkillBase> Lskill;
    private Dictionary<Key, SkillBase> Dskill;
    private Dictionary<Key, float> DskillCool;
    private Dictionary<Key, int> DskillMana;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
        SetSkill();
    }
    private void SetSkill()
    {
        Dskill = new Dictionary<Key, SkillBase>();
        DskillCool = new Dictionary<Key, float>();
        DskillMana = new Dictionary<Key, int>();
        foreach (SkillBase skill in Lskill)
        {
            Dskill[skill.key] = Instantiate(skill,transform);
            DskillCool[skill.key] = 0f;
            DskillMana[skill.key] = skill.skill.useMp;
        }
    }

    public bool StartSkill(Key key)
    {
        if (!IsCool(key))
            return false;
        if (!IsMana(key))
            return false;
        Debug.Log("스킬시작");
        SetCool(key);
        Dskill[key].StartSkill();
        return true;
    }

    private bool IsMana(Key key)
    {
        return PlayerController.Instance.TryUseMana(DskillMana[key]);
    }

    private bool IsCool(Key key)
    {
        if (Time.time < DskillCool[key])
            return false;
        else
            return true;

    }

    private void SetCool(Key key)
    {
        DskillCool[key] = Time.time + Dskill[key].GetCool();
    }

    public float GetCoolRate(Key key)
    {
        return Mathf.Max(0f, DskillCool[key] - Time.time) / Dskill[key].GetCool();
    }
}
