using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//퀘스트의 상태를 나타내기위한 enum값
[Serializable]
public enum QuestState
{
    CanStart,
    OnGoing,
    End,
}

[Serializable]
[CreateAssetMenu(fileName = "Quest", menuName = "AddQuest")]
public class QuestData : ScriptableObject
{
    public QuestState questState = QuestState.CanStart;
    public int questId = -1;
    public float getEXP;

    public QuestKill questKill;
    public QuestGet questGet;

    //처치 퀘스트와 수집 퀘스트 중 설정된 것을 퀘스트로 설정하는 역할
    public QuestBase quest;

    //퀘스트UI에 들어가는 설명
    public string shortInfo;
    public string longInfo;

    //퀘스트 진행 후 연계 되는 퀘스트
    public int[] nextQuest;
}
