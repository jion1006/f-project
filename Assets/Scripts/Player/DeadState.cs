using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : MonoBehaviour, IPlayerState
{
    public PlayerStateType stateType => PlayerStateType.Dead;

    private Animator animator;
    private PlayerController playerC;
    private PlayerStateMachine playerS;

    public void Enter(PlayerController thePC, PlayerStateMachine thePS)
    {
        animator.CrossFade("Dead", 0.05f);
        playerC = thePC;
        playerS = thePS;
        StartCoroutine(ReturnToTown());
    }

    public void Exit()
    {
        StopAllCoroutines();
    }
    public void HandleInput()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    public void SUpdate()
    {
        
    }

    IEnumerator ReturnToTown()
    {
        GameManager.Instance.ChangeScene("TownScene");
        yield return new WaitForSeconds(0.5f);
        playerS.ChangeState(PlayerStateType.Move);
        playerC.StatUpdate();
        animator.CrossFade("StayTree", 0.2f);
    }
}
