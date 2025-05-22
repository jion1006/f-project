using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public PlayerStateMachine thePS;

    private IPlayerState currentState;
    
    
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
            if (thePS.currentType==PlayerStateType.Move)
            {
                thePS.changeState(PlayerStateType.Inven);
            }
            else if(thePS.currentType==PlayerStateType.Inven)
                thePS.changeState(PlayerStateType.Move);
        }
    }

    

}
