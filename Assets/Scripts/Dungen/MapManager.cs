using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public List<GameObject> monsterL;
    public List<BoxCollider2D> portalOns;
    public BoxCollider2D bound;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        monsterL.RemoveAll(m => m == null);
        if(portalOns.Count!=0)
            CheckAllMonsterDIE();
    }

    void CheckAllMonsterDIE()
    {
        if (monsterL.Count == 0)
        {
            foreach (var potal in portalOns)
            {
                potal.enabled = true;
            }
        }
        else
            foreach (var potal in portalOns)
            {
                potal.enabled = false;
            }

    }
}
