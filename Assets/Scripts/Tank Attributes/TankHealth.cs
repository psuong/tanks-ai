using UnityEngine;
using System.Collections;

public class TankHealth : MonoBehaviour {

    public float tankHealth = 100f;
    
    // This is an accessor in C#; you can't assign a value to it,
    // but it will give us information when we try to retrieve it
    // from another class. :)
    public float CurrentHealth { get { return currentHealth; } }
    
    // This is the internal field that will hold all the internal information
    // of the Tank's health.
    private float currentHealth;

	// Use this for initialization
	private void Start () {
        // Let's assign the custom value we decided to give in Unity's inspector.
        currentHealth = tankHealth;
	}
	
    // Perform a calculation to the internal health. Our projectile should
    // do damage anyhow.
    private void TakeDamage(float damage) {
        currentHealth -= damage;

        if (currentHealth <= 0 && tag == "Player") {
            gameObject.SetActive(false);
        }
    }
}
