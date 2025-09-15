using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class PlayerController : MonoBehaviour, IDamagable
{
    public PlayerStateMachine thePS;
    public static PlayerController Instance;

    public event Action<int, int> OnHealthChanged;
    public event Action<int, int> OnManaChanged;
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
    private PlayerStat totalStat;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        thePS = FindObjectOfType<PlayerStateMachine>();
        animator = GetComponent<Animator>();
        playerStat = DataManager.Instance.GetPlayerStat();
        totalStat = new PlayerStat();
        if (SaveLoadManager.Instance.isLoad)
            SetLoad(SaveLoadManager.Instance.load.playerStat);
        SetTotal();
        StatUpdate();
        OnLevelChanged += SetTotal;
        OnLevelChanged += StatUpdate;
        EquipManager.Instance.OnEquipChange += SetTotal;
    }

    void OnDestroy()
    {
        EquipManager.Instance.OnEquipChange -= SetTotal;
    }

    public void StatUpdate()
    {
        totalStat.currentHp = totalStat.maxHp;
        playerStat.currentMp = playerStat.maxMp;
        OnHealthChanged?.Invoke(totalStat.currentHp, totalStat.maxHp);
        OnManaChanged?.Invoke(playerStat.currentMp, playerStat.maxMp);
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

    void Update()
    {
        thePS.currentState.HandleInput();
    }

    public void Damaged(int _monAttack)
    {
        int dmg = 1;
        if (_monAttack - totalStat.def > 0)
            dmg = _monAttack - totalStat.def;
        totalStat.currentHp -= dmg;
        if (totalStat.currentHp <= 0)
        {
            thePS.ChangeState(PlayerStateType.Dead);
        }
        else
        {
            thePS.ChangeState(PlayerStateType.Damaged);
        }
        OnHealthChanged?.Invoke(totalStat.currentHp, totalStat.maxHp);
    }

    public void Heal(int _heal)
    {
        totalStat.currentHp += _heal;
        if (totalStat.currentHp > totalStat.maxHp)
            totalStat.currentHp = totalStat.maxHp;

        OnHealthChanged?.Invoke(totalStat.currentHp, totalStat.maxHp);
    }
    public void GetExp(int _exp)
    {
        playerStat.currentExp += _exp;
        if (playerStat.currentExp >= playerStat.maxExp)
            LevelUp();
        OnExpChanged?.Invoke(playerStat.currentExp, playerStat.maxExp);
    }

    public bool TryUseMana(int _use)
    {
        if (playerStat.currentMp < _use)
            return false;
        else
        {
            UseMP(_use);
            return true;        
        }
    }
    private void UseMP(int _use)
    {
        playerStat.currentMp -= _use;
        OnManaChanged?.Invoke(playerStat.currentMp, playerStat.maxMp);
    }

    public void LevelUp()
    {
        playerStat.currentExp -= playerStat.maxExp;
        playerStat.maxExp += 10;
        playerStat.maxHp += 20;
        playerStat.maxMp += 10;
        playerStat.level += 1;
        playerStat.atk += 1;
        playerStat.def += 1;
        OnLevelChanged?.Invoke();
    }

    public void SetTotal()
    {
        ItemStat equip = EquipManager.Instance.GetItemStat();
        totalStat.atk = playerStat.atk + equip.atk;
        totalStat.def = playerStat.atk + equip.def;
        totalStat.maxHp = playerStat.maxHp + equip.maxHP;
        totalStat.currentHp = playerStat.currentHp + equip.maxHP;
    }

    public PlayerStat GetTotal()
    {
        return totalStat;
    }
    public PlayerStat GetPlayerStat()
    {
        return playerStat;
    }

    public void ReturnMove()
    {
        thePS.ChangeState(PlayerStateType.Move);
    }
    
    public void SkilAnimation(string _skillName)
    {
        animator.CrossFade(_skillName, 0.01f);
    }
}
