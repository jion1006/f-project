using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndUI : MonoBehaviour
{

    public void ReChallenge()
    {
        GameManager.Instance.ChangeScene(SceneManager.GetActiveScene().name);
    }
    public void AnotherDun()
    {
        GameManager.Instance.ChangeScene("DungenSelect");
    }
    public void ReturnToTown()
    {
        GameManager.Instance.ChangeScene("TownScene");
    }

    
}
