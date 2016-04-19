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

    private void FixedUpdate() {

    }

    private void Move() {
        if (movementInput != 0) {
            Vector3 position = transform.forward * movementInput * playerSpeed * Time.deltaTime;
            playerRigidbody.MovePosition(position);
        }
    }
}
