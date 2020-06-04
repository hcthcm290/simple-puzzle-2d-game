using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATKAnimationBehavior : StateMachineBehaviour
{
    public PlayerMovement playerMovement;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(playerMovement == null)
        {
            playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        }
        playerMovement.BlockMoving();
        playerMovement.BlockATK();
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerMovement.UnblockMoving();
        playerMovement.UnblockATK();
    }
}
