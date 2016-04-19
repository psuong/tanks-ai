using UnityEngine;
using System.Collections;

public class AI_Conditions : MonoBehaviour {

    public GameObject player;
    public float minimalDistance = 10f;
    public float sightAngle = 120;
    
    // The following strings below are meant to be hashed such that Unity
    // can find the IDs within the state machine.
    public string withinSightName = "See Enemy";

    // Some private fields.
    private Animator stateMachine;
    private int withinSightID;

	// Use this for initialization
	private void Start () {
        // Get the animator componenet attached to the AI controlled tank.
        stateMachine = GetComponent<Animator>();
        if (player == null) {
            player = GameObject.FindWithTag("Player");
        }

        withinSightID = Animator.StringToHash(withinSightName);
	}
	
	// Update is called once per frame
	private void Update () {
        // If the AI is within distance and within an angle of the player, then switch states.
        if (IsWithinSightDistance() && IsWithinPeripherals()) {
            // TODO: Set a trigger that forces the state machine to change states.
            stateMachine.SetBool(withinSightName, true);
        }
	}
    
    // Is the player within distance of the AI to notice?
    private bool IsWithinSightDistance() {
        if (Vector3.Distance(transform.position, player.transform.position) < minimalDistance) {
            return true;
        } 
        return false;
    }
    
    // Is the player within the viewing angle of the AI to notice?
    private bool IsWithinPeripherals() {
        Vector3 rawPosition = player.transform.position - transform.position;
        if (Vector3.Angle(transform.forward, rawPosition) < sightAngle) {
            return true;
        }
        return false;
    }
}
