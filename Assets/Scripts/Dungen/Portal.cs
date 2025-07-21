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
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            StartCoroutine(ChangeMap(collision));
        }
    }

    IEnumerator ChangeMap(Collider2D collision)
    {
        yield return StartCoroutine(GameManager.Instance.FadeOutScreen());
        dungenM.MoveToMap(nextMap);
        collision.transform.position = nextMove.transform.position;
        cam.transform.position = nextMove.transform.position;
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(GameManager.Instance.FadeInScreen());
    }

}
