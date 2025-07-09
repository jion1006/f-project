using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToTown : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
            GameManager.Instance.ChangeScene("TownScene");
    }
}
