using UnityEngine;
using System.Collections;

// The PositionManager class references and stores the player's position.
public class PositionManager : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	private void Start () {
        // If the reference to the Player GameObject is not found, then get the reference.
	    if (player == null) {
            player = GameObject.FindGameObjectWithTag("Player");
        }
	}
	
	// Update is called once per frame
	private void Update () {
	    
	}
}
