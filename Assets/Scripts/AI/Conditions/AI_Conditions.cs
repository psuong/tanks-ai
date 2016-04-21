using UnityEngine;
using Random = System.Random;
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
    
    // Let's make our retreatThreshold pretty!
    // This field is used to determine at what percent should our AI retreat.
    [Range(0.1f, 1f)]
    public float dodgeChance = 0.5f;

    // Our dodge radius or what is the length our AI should move by when it detects a projectile?
    public float dodgeRadius = 2f;
    
    // The following strings below are meant to be hashed such that Unity
    // can find the IDs within the state machine.
    public string withinSightName = "See Enemy";
    public string distanceName = "Distance";
    public string withinAttackName = "Within Attack Range";
    public string dodgeName = "Dodge";
    public string dieName = "Die";

    // The following private fields are associated with Unity's Mecanim/Animator system.
    private Animator stateMachine;
    private int withinSightID;
    private int withinAttackID;
    private int dodgeID;
    private int dieID;

    // AI Tank Properties
    private float baseHealth;
    private float currentHealth;

    // Random Number Generator needed to check chance.
    private Random rng;

	// Use this for initialization
	private void Start () {
        // Get the animator componenet attached to the AI controlled tank.
        stateMachine = GetComponent<Animator>();

        currentHealth = gameObject.GetComponent<TankHealth>().CurrentHealth;
        baseHealth = gameObject.GetComponent<TankHealth>().tankHealth;

        // Initialize our RNG in case we need to use it.
        rng = new Random();
        

        // Just for a safety check, if we didn't drag the public reference
        // in Unity's inspector, let's grab it so our code doesn't break. :)
        if (player == null) {
            player = GameObject.FindWithTag("Player");
        }

        // For speed, we want to Hash the ID, because internally
        // Unity does that everytime we pass a string to our animator.
        withinSightID = Animator.StringToHash(withinSightName);
        withinAttackID = Animator.StringToHash(withinAttackName);
        dodgeID = Animator.StringToHash(dodgeName);
        dieID = Animator.StringToHash(dieName);
	}
	
	// Update is called once per frame
	private void Update () {

        currentHealth = gameObject.GetComponent<TankHealth>().CurrentHealth;

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

        // If our AI's health is below 0, let's kill our AI.
        if (currentHealth <= 0) {
            stateMachine.SetTrigger(dieID);
        }
	}
    
    // Let's make our AI more interesting. OnTriggerEnter only works when something hits the
    // the collider.
    private void OnTriggerEnter(Collider other) {
        // We should only perform dodge every now and then, so let's use a random number generator
        // to create that percent chance.
        float rngChance = rng.Next(0, 10000) / 10000f;

        if (other.CompareTag("Projectile") && rngChance > dodgeChance)  {
            stateMachine.SetTrigger(dodgeID);
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
