using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    public Canvas poolCanvas;

    public GameObject monHPbar;
    //public GameObject damageText;

    public int poolSize = 20;

    private Queue<GameObject> hpbarPool = new Queue<GameObject>();
    //private Queue<GameObject> damamgePool = new Queue<GameObject>();
    void Awake()
    {
        Instance = this;

        for (int i = 0; i < poolSize; ++i)
        {
            var monbar = Instantiate(monHPbar, poolCanvas.transform);
            monbar.SetActive(false);
            hpbarPool.Enqueue(monbar);

            //var damage = Instantiate(damageText, poolCanvas.transform);
            //damage.SetActive(false);
            //damamgePool.Enqueue(damage);
        }

    }



    public GameObject GetHpbar()
    {
        GameObject bar;
        if (hpbarPool.Count > 0)
            bar = hpbarPool.Dequeue();
        else
            bar = Instantiate(monHPbar, poolCanvas.transform);

        bar.SetActive(true);
        return bar;
    }

    public void ReturnHpbar(GameObject bar)
    {
        bar.SetActive(false);
        hpbarPool.Enqueue(bar);
    }

    /*public GameObject GetDamageT()
    {
        GameObject dText;
        if (damamgePool.Count > 0)
            dText = damamgePool.Dequeue();
        else
            dText = Instantiate(damageText, poolCanvas.transform);

        dText.SetActive(true);
        return dText;
    }*/

    /*public void ReturnDText(GameObject dText)
    {
        dText.SetActive(false);
        damamgePool.Enqueue(dText);
    }*/
}
