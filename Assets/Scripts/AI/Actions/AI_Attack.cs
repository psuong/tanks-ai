using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.Director;

public class AI_Attack : StateMachineBehaviour {

    public GameObject player;
    public Rigidbody projectile;
    public Transform shotPosition;

    public float shotForce = 1000f;
    public float shotInterval = 0.5f;

    private float nextShotInterval;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        // If there is no instance of the player, let's access the AI_Conditions component and 
        // assign a reference for this state.
        if (player == null) {
            player = animator.gameObject.GetComponent<AI_Conditions>().player;
        }
        
        // Let's set the interval when the state has been accessed.
        nextShotInterval = 0f;

        // Rotate towards the player and let's fire a projectile.
        animator.transform.LookAt(player.transform);

        Shoot();
    }

    // The Shoot() method creates a projectile and launches it forward.
    private void Shoot() {
        if (Time.time > nextShotInterval) {
            nextShotInterval = Time.time + shotInterval;
            Rigidbody shot = Instantiate(projectile, shotPosition.position, Quaternion.identity) as Rigidbody;

            shot.AddForce(shotPosition.forward * shotForce);
        }
    }
    
}
