using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Playables;


public class PlayerController : MonoBehaviour
{
    public PlayerStateMachine thePS;
    public static PlayerController Instance;


    [SerializeField]
    private int currentHp;
    [SerializeField]
    private int currentMp;
    [SerializeField]
    private int currenExp = 0;
    public event Action<int, int> OnHealthChanged;
    public event Action<int, int> OnExpChanged;
    public event Action OnLevelChanged;
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

        if (SaveLoadManager.Instance.isLoad)
            SetLoad(SaveLoadManager.Instance.load.playerStat);

        StatUpdate();
        OnLevelChanged += StatUpdate;
    }

    public void StatUpdate()
    {
        currentHp = playerStat.maxHp;
        currentMp = playerStat.maxMp;
    }

    public void SetLoad(PlayerStat loadStat)
    {
        playerStat.maxHp = loadStat.maxHp;
        playerStat.maxMp = loadStat.maxMp;
        playerStat.maxExp = loadStat.maxExp;
        playerStat.atk = loadStat.atk;
        playerStat.def = loadStat.def;
        playerStat.level = loadStat.level;
        playerStat.coin = loadStat.coin;
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
        OnHealthChanged?.Invoke(currentHp, playerStat.maxHp);
    }

    public void Heal(int _heal)
    {
        currentHp += _heal;
        if (currentHp > playerStat.maxHp)
            currentHp = playerStat.maxHp;

        OnHealthChanged?.Invoke(currentHp, playerStat.maxHp);
    }
    public void GetExp(int _exp)
    {
        currenExp += _exp;
        if (currenExp >= playerStat.maxExp)
            LevelUp();
        OnExpChanged?.Invoke(currenExp,playerStat.maxExp);
    }

    public void LevelUp()
    {
        currenExp -= playerStat.maxExp;
        playerStat.maxExp += 10;
        playerStat.maxHp += 20;
        playerStat.maxMp += 10;
        playerStat.level += 1;
        playerStat.atk += 1;
        playerStat.def += 1;
        OnLevelChanged?.Invoke();
    }
}
