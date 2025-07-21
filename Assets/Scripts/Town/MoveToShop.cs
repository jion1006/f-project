using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToShop : MonoBehaviour
{
    public GameObject shopSpawn;
    public BoxCollider2D shopCollider;
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
            PlayerController.Instance.transform.position = shopSpawn.transform.position;
            cameraManager.SetBound(shopCollider);
        }
    }
}
