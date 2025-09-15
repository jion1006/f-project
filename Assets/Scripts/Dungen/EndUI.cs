using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndUI : MonoBehaviour
{

    public void ReChallenge()
    {
        GameManager.Instance.ChangeScene(SceneManager.GetActiveScene().name);
        PlayerController.Instance.StatUpdate();
    }
    public void AnotherDun()
    {
        GameManager.Instance.ChangeScene("DungenSelect");
        PlayerController.Instance.StatUpdate();
    }
    public void ReturnToTown()
    {
        GameManager.Instance.ChangeScene("TownScene");
        PlayerController.Instance.StatUpdate();
    }


}
