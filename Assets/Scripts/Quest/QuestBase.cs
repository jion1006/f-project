using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class QuestBase
{
    abstract public string GetGoingText();
    abstract public bool IsClear();
}

[Serializable]
public class QuestKill : QuestBase
{
    [Header("처치해야할 몬스터의 코드")]
    public int monId;
    [Header("처리해야될 마리 수")]
    public int killCount;

    //현재 처치 수
    public int currentCount = 0;

    public override string GetGoingText()
    {
        return $"{Math.Clamp(currentCount, 0, killCount)}/{killCount}";
    }
    
    public override bool IsClear()
    {
        if (currentCount == killCount)
            return true;
        return false;

    }
}

[Serializable]
public class QuestGet : QuestBase
{
    [Header("수집해야할 아이템ID")]
    public int itemId;
    [Header("수집할 개수")]
    public int getCount;

    //현재 수집 개수
    public int currentCount = 0;

    public override string GetGoingText()
    {
        return $"{currentCount}/{getCount}";
    }

    public override bool IsClear()
    {
        if (currentCount >= getCount)
            return true;
        return false;
    }
}
