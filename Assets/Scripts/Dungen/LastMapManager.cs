using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastMapManager : MapManager
{

    public GameObject returnUI;

    public override void CheckAllMonsterDIE()
    {
        monsterCount--;
        if (monsterCount <= 0)
        {
            foreach (var potal in portalOns)
            {
                if (potal.TryGetComponent<Portal>(out var por))
                    por.OnPortal();
            }
            returnUI.SetActive(true);
        }
    }
}
