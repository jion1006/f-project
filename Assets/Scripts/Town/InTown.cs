using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InTown : MonoBehaviour
{
    
    public GameObject startPostion;
    public GameObject playerSpawn;
    public BoxCollider2D townBound;
    public CameraManager cameraManager;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.IsGame)
        {
            PlayerController.Instance.transform.position = playerSpawn.transform.position;
        }
        else
        {
            PlayerController.Instance.transform.position = startPostion.transform.position;

            GameManager.Instance.IsGame = true;
        }

        townBound = GetComponent<BoxCollider2D>();
        cameraManager.SetBound(townBound);
        if (SaveLoadManager.Instance.isLoad)
        {
            IsLoding();
        }
    }

    

    public void IsLoding()
    {
        PlayerController.Instance.transform.position = startPostion.transform.position;
    }
}
