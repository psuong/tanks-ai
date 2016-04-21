using UnityEngine;
using System.Collections;

public class KillAI : StateMachineBehaviour {
    
    // This is a pretty easy state, all we need to do is destroy our AI when it dies.
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Destroy(animator.gameObject);
    }
}
