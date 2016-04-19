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

	// Use this for initialization
	private void Start () {
	
	}
	
	// Update is called once per frame
	private void Update () {
	
	}

    private void FixedUpdate() {

    }
}
