using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
    
    public Rigidbody projectile;
    public Transform shotPosition;

    public string fireName = "Fire1";

    public float shotForce = 1000f;
    public float fireRate = 0.5f;

    private float nextFireInterval;
    
	// Use this for initialization
	private void Start () {
        nextFireInterval = 0f;   
	}
	
	// Update is called once per frame
	private void Update () {
	    if (Input.GetKeyUp(fireName) && Time.time > nextFireInterval) {
            nextFireInterval = Time.time + fireRate;
            
            // Create an instance of the shot and move it forward.
            Rigidbody shot = Instantiate(projectile, shotPosition.position, Quaternion.identity) as Rigidbody;
            shot.AddForce(shotPosition.forward * shotForce);
        }
	}
}
