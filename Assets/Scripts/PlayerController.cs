using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public PlayerStateMachine thePS;

    private IPlayerState currentState;
    bool invenUse = false;

    // Start is called before the first frame update
    void Start()
    {
        thePS = FindObjectOfType<PlayerStateMachine>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!invenUse)
            {
                thePS.changeState(PlayerStateType.Inven);
                invenUse = !invenUse;
            }
            else
                thePS.changeState(PlayerStateType.Move);
        }
    }

    

}
