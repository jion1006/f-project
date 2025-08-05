using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public List<GameObject> monsterL;
    public List<GameObject> portalOns;
    public BoxCollider2D bound;
    public int monsterCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        monsterCount = monsterL.Count;
        foreach (var monObj in monsterL)
        {
            if (monObj.TryGetComponent<MonsterDead>(out var mon))
                mon.OnDeadEvent += CheckAllMonsterDIE;
        }
    }



    public virtual void CheckAllMonsterDIE()
    {

        monsterCount--;
        if (monsterCount <= 0)
        {
            foreach (var potal in portalOns)
            {
                if (potal.TryGetComponent<Portal>(out var por))
                    por.OnPortal();
            }
        }
    }
        
}
