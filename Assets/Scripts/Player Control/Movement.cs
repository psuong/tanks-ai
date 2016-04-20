using UnityEngine;
using System.Collections;

// Pretty self explanatory here, we need a rigidbody for this player
// to work.
[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour {

    // Public fields
    public string horizontalInput = "Horizontal";           // The name of the input we want to use. Please see Unity's Input Manager.
    public string verticalInput = "Vertical";               // The name of the input we want to use. Please see Unity's Input Manager.
    public float playerSpeed = 5f;                          // The speed we would like our player to go.
    public float turnSpeed = 30f;                           // How fast our rotational speed is when we're turning.

    // Private fields
    private float movementInput;
    private float rotationalInput;
    private Rigidbody playerRigidbody;

    private void Awake() {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    private void Start() {
        if (playerRigidbody == null) {
            playerRigidbody = GetComponent<Rigidbody>();
        }

        // Let's make physics apply to our player!
        playerRigidbody.isKinematic = false;

        // Just a safety guard to make sure that the player is still
        // when the game starts!
        movementInput = 0;
        rotationalInput = 0;
    }

    // Update is called once per frame
    private void Update() {
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

    // Take the values from our vertical Inputs and applying those values to our rigidbody's
    // movements over time.
    private void Move() {
        if (movementInput != 0) {
            Vector3 position = transform.forward * movementInput * playerSpeed * Time.deltaTime;
            playerRigidbody.MovePosition(position + playerRigidbody.position);
        }
    }

    // Similar to the Move() method, we're taking in the values from our horizontal Input and applying
    // those values to our rotation over time.
    private void Rotate() {
        float turnAmount = turnSpeed * rotationalInput * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(0, turnAmount, 0);
        playerRigidbody.MoveRotation(playerRigidbody.rotation * rotation);
    }
}
