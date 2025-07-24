using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public GameObject target;
    public float moveSpeed = 5f;


    public BoxCollider2D boundCollider;

    private Camera theCamera;
    private float minX, maxX, minY, maxY;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        theCamera = GetComponent<Camera>();
        if (PlayerController.Instance != null)
            target = PlayerController.Instance.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 targetPos = target.transform.position;
            targetPos.z = -10f;

            if (boundCollider != null)
            {
                targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
                targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);
            }
            
            this.transform.position = Vector3.Lerp(this.transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
    }

    public void SetBound(BoxCollider2D boxBound)
    {
        Bounds bounds = boxBound.bounds;
        boundCollider = boxBound;
        float verCar = Camera.main.orthographicSize;
        float horCar = verCar * Camera.main.aspect;

        minX = bounds.min.x + horCar;
        maxX = bounds.max.x - horCar;
        minY = bounds.min.y + verCar;
        maxY = bounds.max.y - verCar;

        if (target != null)
        {
            Vector3 targetPos = target.transform.position;
            targetPos.z = -10f;

            targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
            targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);

            this.transform.position=targetPos;
        }
    }
}
