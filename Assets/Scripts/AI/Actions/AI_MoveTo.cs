using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.Director;

public class AI_MoveTo : StateMachineBehaviour {

    private NavMeshAgent agent;
    private Vector3 playerPosition;
    private AI_Conditions conditions;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        
        // Set up the state by assigning the following variables.
        if (agent == null) {
            agent = animator.gameObject.GetComponent<NavMeshAgent>();
        }
        if (conditions == null) {
            conditions = animator.gameObject.GetComponent<AI_Conditions>();
            playerPosition = conditions.player.transform.position;
        }

        // Perform the action once the state has been entered.
        // The following code below will allow the AI to move closer
        // to the player.
        agent.SetDestination(playerPosition);
    }
    
    // So what happens when we remain in this state? We want to keep
    // chasing down the player. So let's continuously update our NavMeshAgent
    // to set the player's position as our destination.
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller) {
        base.OnStateUpdate(animator, stateInfo, layerIndex, controller);
        playerPosition = conditions.player.transform.position;

        agent.SetDestination(playerPosition);
    }
}
