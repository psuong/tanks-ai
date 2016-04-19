using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour {

    // Public fields
    public string horizontalInput = "Horizontal";
    public string verticalInput = "Vertical";
    public float playerSpeed = 5f;
    public float turnSpeed = 30f;

    // Private fields
    private float movementInput;
    private float rotationalInput;
    private Rigidbody playerRigidbody;
    
    private void Awake() {
        playerRigidbody = GetComponent<Rigidbody>();
    }

	// Use this for initialization
	private void Start () {
	    if (playerRigidbody == null) {
            playerRigidbody = GetComponent<Rigidbody>();
        }
        
        // Let's make physics apply to our player!
        playerRigidbody.isKinematic = false;

        // Just a safety guard to make sure that the player is still.
        movementInput = 0;
        rotationalInput = 0;
	}
	
	// Update is called once per frame
	private void Update () {
        // We're using Unity's Input Manager here and we're assigning
        // the values of the inputs we're getting to our private fields.
        movementInput = Input.GetAxis(verticalInput);
        rotationalInput = Input.GetAxis(horizontalInput);
	}
    
    // FixedUpdate is similar to Update, but will always run at a specific set interval
    // no matter what kind of hardware you have.
    private void FixedUpdate() {
        // Let's use FixedUpdate to apply movement and
        // rotation to our player.
        Move();
        Rotate();
    }

    private void Move() {
        if (movementInput != 0) {
            Vector3 position = transform.forward * movementInput * playerSpeed * Time.deltaTime;
            playerRigidbody.MovePosition(position + playerRigidbody.position);
        }
    }

    private void Rotate() {
        float turnAmount = turnSpeed * rotationalInput * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(0, turnAmount, 0);
        playerRigidbody.MoveRotation(playerRigidbody.rotation * rotation);
    }
}
