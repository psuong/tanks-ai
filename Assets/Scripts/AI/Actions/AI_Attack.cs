using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.Director;

public class AI_Attack : StateMachineBehaviour {

    private GameObject player;
    private Rigidbody projectile;
    private Transform shotPosition;

    private float shotForce;
    private float shotInterval;

    private float nextShotInterval;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        // The following if statements are set up statements if there are no references.
        if (player == null) {
            player = animator.gameObject.GetComponent<AI_Conditions>().player;
        }

        if (projectile == null) {
            projectile = animator.gameObject.GetComponent<Shot_Supplements>().projectile;
        }

        if (shotPosition == null) {
            shotPosition = animator.gameObject.GetComponent<Shot_Supplements>().shotPosition;
        }

        shotForce = animator.gameObject.GetComponent<Shot_Supplements>().shotForce;
        shotInterval = animator.gameObject.GetComponent<Shot_Supplements>().fireInterval;
        
        // Let's set the interval when the state has been accessed.
        nextShotInterval = 0f;

        // Rotate towards the player and let's fire a projectile.
        animator.transform.LookAt(player.transform);

        Shoot();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
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
