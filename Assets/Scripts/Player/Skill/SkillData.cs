using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Skill/SkillData")]
public class SkillData : ScriptableObject
{
    public int id;
    public float coolDown;
    public int damage;
    public int useMp;
    public string skillName;
    public AudioClip sfx;
    
}
