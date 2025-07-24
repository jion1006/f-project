using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNPC : BaseNPC
{
    public GameObject x;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OpenTargetUI()
    {
        PlayerController.Instance.thePS.ChangeState(PlayerStateType.UI);
        UIManager.Instance.OnShopPanel();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
            x.SetActive(true);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
            x.SetActive(false);
    }
}
