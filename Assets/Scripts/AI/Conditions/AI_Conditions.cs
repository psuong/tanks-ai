using UnityEngine;
using System.Collections;

public class AI_Conditions : MonoBehaviour {

    // A reference to the player gameObject so that the AI knows what
    // to attack.
    public GameObject player;

    // How far can our AI "see?"
    public float sightDistance = 30f;

    // How wide can our AI "see?"
    public float sightAngle = 120;
    
    // What is the minimal distance needed for our AI to attack?
    public float attackRange = 20f;
    
    // The following strings below are meant to be hashed such that Unity
    // can find the IDs within the state machine.
    public string withinSightName = "See Enemy";
    public string distanceName = "Distance";

    // Some private fields.
    private Animator stateMachine;
    private int withinSightID;
    private int distanceID;

	// Use this for initialization
	private void Start () {
        // Get the animator componenet attached to the AI controlled tank.
        stateMachine = GetComponent<Animator>();
        if (player == null) {
            player = GameObject.FindWithTag("Player");
        }

        // For speed, we want to Hash the ID, because internally
        // Unity does that everytime we pass a string to our animator.
        withinSightID = Animator.StringToHash(withinSightName);
        distanceID = Animator.StringToHash(distanceName);
	}
	
	// Update is called once per frame
	private void Update () {
        // If the AI is within distance and within an angle of the player, then switch states.
        if (IsWithinSightDistance() && IsWithinPeripherals()) {
            // TODO: Set a trigger that forces the state machine to change states.
            stateMachine.SetBool(withinSightName, true);
        }

        // Ideally, we always want to update our distance between the player.
        stateMachine.SetFloat(distanceID, GetDistance());

        // Let's think about this, when do we want to attack?
        // We only want to attack if our AI can both see our player
        // and is within attacking range.
        // Kind of like a human right?
        if (IsWithinSightDistance() && IsWithinPeripherals() && GetDistance() < attackRange) {
            // TODO: Set the trigger to attack.
        }

	}
    
    // Is the player within distance of the AI to notice?
    private bool IsWithinSightDistance() {
        if (Vector3.Distance(transform.position, player.transform.position) < sightDistance) {
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
    
    // This will grab the distance between the AI and the player.
    private float GetDistance() {
        return Vector3.Distance(gameObject.transform.position, player.transform.position);
    }
}
