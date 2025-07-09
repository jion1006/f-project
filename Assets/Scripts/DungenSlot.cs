using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungenSlot : MonoBehaviour
{
    public string dungenName;
    public GameObject selectPoint;

    public bool isSelected = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            selectPoint.SetActive(true);
        }
        else
        {
            selectPoint.SetActive(false);
        }
    }
}
