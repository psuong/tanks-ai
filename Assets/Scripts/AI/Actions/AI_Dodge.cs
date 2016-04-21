using UnityEngine;
using System.Collections;

public class AI_Dodge : StateMachineBehaviour {

    public Transform playerTransform;

    private float dodgeRadius;
    private NavMeshAgent agent;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        if (playerTransform == null) {
            playerTransform = animator.gameObject.GetComponent<AI_Conditions>().player.transform;
        }
        if (agent == null) {
            agent = animator.gameObject.GetComponent<NavMeshAgent>();
        }

        dodgeRadius = animator.GetComponent<AI_Conditions>().dodgeRadius;

        // Force our AI to look at the player.
        animator.transform.LookAt(playerTransform);

        // Let's make our AI actually dodge. A library "CircleMath" has been provided to
        // allow you guys to pick a random point.
        agent.SetDestination(CircleMath.GetEdgeY3D(180, dodgeRadius));
    }

}
