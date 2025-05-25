using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public PlayerStateMachine thePS;

    

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        thePS = FindObjectOfType<PlayerStateMachine>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        thePS.currentState.HandleInput(); 
    }

    

}
