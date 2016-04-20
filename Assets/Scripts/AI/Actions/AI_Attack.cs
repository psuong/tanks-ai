using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.Director;

public class AI_Attack : StateMachineBehaviour {

    public GameObject player;
    public Rigidbody projectile;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (player == null) {
            player = animator.gameObject.GetComponent<AI_Conditions>().player;
        }

        // TODO: Rotate towards the player and let's fire a projectile.
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller) {
        base.OnStateEnter(animator, stateInfo, layerIndex, controller);
    }
    
    // The Shoot() method fires off a projectile.
    private void Shoot() {

    }
    
}
