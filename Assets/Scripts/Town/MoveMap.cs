using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMap : MonoBehaviour
{
    public GameObject playSpawn;
    public BoxCollider2D bound;
    public CameraManager cameraManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            PlayerController.Instance.transform.position = playSpawn.transform.position;
            cameraManager.SetBound(bound);
        }
    }
}
