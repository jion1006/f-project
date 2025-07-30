using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public PlayerStateMachine thePS;
    public static PlayerController Instance;
    

    [SerializeField]
    private int currentHp;
    [SerializeField]
    private int currentMp;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

    }

    public PlayerStat playerStat;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        thePS = FindObjectOfType<PlayerStateMachine>();
        animator = GetComponent<Animator>();
        playerStat = DataManager.Instance.GetPlayerStat();
        currentHp = playerStat.maxHp;
        currentMp = playerStat.maxMp;

    }

    // Update is called once per frame
    void Update()
    {
        thePS.currentState.HandleInput();
    }

    public void AttackDamaged(int _monAttack)
    {
        currentHp -= _monAttack;
        if (currentHp <= 0)
        {
            thePS.ChangeState(PlayerStateType.Dead);
        }
        else
        {
            thePS.ChangeState(PlayerStateType.Damaged);
        }
    }

    

}
