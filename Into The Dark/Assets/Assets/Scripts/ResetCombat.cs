using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCombat : StateMachineBehaviour {

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        animator.SetBool("attacking", false);
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        animator.SetBool("attacking", true);
    }
}