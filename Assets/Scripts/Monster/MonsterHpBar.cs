using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHpBar : MonoBehaviour
{
    public Slider hpSlider;
    public MonsterController monster;

    public int maxHp;
    public Vector3 offset = new Vector3(0, 1.2f, 0);
    // Start is called before the first frame update
    void Start()
    {
        hpSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetTarget(MonsterController _monster)
    {
        monster = _monster;
        maxHp = monster.monsterStat.maxHp;
        monster.hpChanged += UpdateHpBar;
    }

    void LateUpdate()
    {
        if (monster != null)
        {
            transform.position = monster.transform.position + offset;
        }
    }

    public void UpdateHpBar(int _currentHp)
    {
        hpSlider.value= (float)_currentHp / maxHp;
    }
}
