using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Slider hpBar;
    public Slider mpBar;
    public Slider expBar;

    void Awake()
    {
        hpBar.minValue = 0f;
        hpBar.maxValue = 1f;
        mpBar.minValue = 0f;
        mpBar.maxValue = 1f;
        expBar.minValue = 0f;
        expBar.maxValue = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerController.Instance.OnHealthChanged += HPbarUpdate;
        hpBar.value = 1f;
        mpBar.value = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HPbarUpdate(int currentHp, int maxHp)
    {
        hpBar.value = (float)currentHp / maxHp;
    }

    public void MPbarUpdate(int currentMp, int maxMp)
    {
        mpBar.value = (float)currentMp / maxMp;

    }

    public void ExpbarUPdate(int currentExp, int maxExp)
    {
        expBar.value = (float)currentExp / maxExp;
    }
}
