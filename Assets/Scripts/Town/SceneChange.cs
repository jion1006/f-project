using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            GameManager.Instance.ChangeScene("DungenSelect");        
        }
    }
}
