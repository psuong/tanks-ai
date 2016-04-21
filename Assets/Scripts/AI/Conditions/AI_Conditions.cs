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
    public string withinAttackName = "Within Attack Range";

    // The following private fields are associated with Unity's Mecanim/Animator system.
    private Animator stateMachine;
    private int withinSightID;
    private int withinAttackID;

    // AI Tank Properties
    private float tankHealth;

	// Use this for initialization
	private void Start () {
        // Get the animator componenet attached to the AI controlled tank.
        stateMachine = GetComponent<Animator>();

        // Just for a safety check, if we didn't drag the public reference
        // in Unity's inspector, let's grab it so our code doesn't break. :)
        if (player == null) {
            player = GameObject.FindWithTag("Player");
        }

        // For speed, we want to Hash the ID, because internally
        // Unity does that everytime we pass a string to our animator.
        withinSightID = Animator.StringToHash(withinSightName);
        withinAttackID = Animator.StringToHash(withinAttackName);
	}
	
	// Update is called once per frame
	private void Update () {

        // If the AI is within distance and within an angle of the player, then switch states.
        if (IsWithinSightDistance() && IsWithinPeripherals()) {
            stateMachine.SetBool(withinSightName, true);
        }
        else {
            stateMachine.SetBool(withinSightID, false);
        }

        // Let's think about this, when do we want to attack?
        // We only want to attack if our AI can both see our player
        // and is within attacking range.
        // Kind of like a human right?
        if (IsWithinSightDistance() && IsWithinPeripherals() && GetDistance() < attackRange) {
            stateMachine.SetBool(withinAttackID, true);
        }
        else {
            stateMachine.SetBool(withinAttackID, false);
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

    // Let's grab the distance between the AI and our player.
    private float GetDistance() {
        return Vector3.Distance(gameObject.transform.position, player.transform.position);
    }
}
