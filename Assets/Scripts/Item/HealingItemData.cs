using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItemData : ItemData
{
    public int healing;

    public override void Use()
    {
        PlayerController.Instance.Heal(healing);
    }
}
