using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/MonsterStat")]
public class MonsterStat:ScriptableObject
{
    public int ID;
    public int atk;
    public int def;
    public int maxHp;
    
}
