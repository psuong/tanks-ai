using UnityEngine;
using System.Collections;

public class Shot_Supplements : MonoBehaviour {

    public Rigidbody projectile;        // Reference to the projectile to clone and shoot.
    public Transform shotPosition;      // Reference to the position of where the shot.
    public float shotForce = 1000f;     // Amount of force applied to the projectile when shot.
    public float fireInterval = 0.5f;   // Rate at which the projectile should be shot.

}
