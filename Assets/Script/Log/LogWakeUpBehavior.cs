﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogWakeUpBehavior : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAwake", true);
    }
}