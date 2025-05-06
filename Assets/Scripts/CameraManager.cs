using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public GameObject target;
    public float moveSpeed;
    private Vector3 targetPostion;

    private Camera theCamera;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        theCamera=GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target.gameObject != null)
        {
            targetPostion.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);
            this.transform.position = Vector3.Lerp(this.transform.position, targetPostion, moveSpeed * Time.deltaTime);
        }
    }
}
