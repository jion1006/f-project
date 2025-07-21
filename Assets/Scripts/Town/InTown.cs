using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InTown : MonoBehaviour
{
    private static bool isLoading = false;
    public GameObject playerSpawn;
    public BoxCollider2D townBound;
    public CameraManager cameraManager;
    // Start is called before the first frame update
    void Start()
    {
        if (isLoading)
        {
            PlayerController.Instance.transform.position = playerSpawn.transform.position;
        }
        else
        {
            isLoading = true;
        }

        townBound = GetComponent<BoxCollider2D>();
        cameraManager.SetBound(townBound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
