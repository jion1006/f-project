using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorBoard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCloseButton()
    {
        this.gameObject.SetActive(false);
    }
}
