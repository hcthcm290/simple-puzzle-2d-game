using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogIdleBehavior : StateMachineBehaviour
{
    public float WaitingTime;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat("WaitingTime", WaitingTime);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        WaitingTime -= Time.deltaTime;
        if(WaitingTime < 0)
        {
            WaitingTime = 0;
        }
        animator.SetFloat("WaitingTime", WaitingTime);
    }
}
