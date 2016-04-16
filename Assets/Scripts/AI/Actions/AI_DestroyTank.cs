using UnityEngine;
using System.Collections;

public class AI_DestroyTank: StateMachineBehaviour {
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        Debug.Log("Tank destroyed.");
        Destroy(animator.gameObject);
    }
}
