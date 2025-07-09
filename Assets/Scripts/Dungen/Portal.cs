using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject nextMove;
    [SerializeField]
    private DungenManager dungenM;
    [SerializeField]
    private int nextMap;
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
            dungenM.MoveToMap(nextMap);
            collision.transform.position = nextMove.transform.position;
        }
    }

}
