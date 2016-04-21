using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    
    // Amount of damage the projectiles does.
    public float damage = 20f;
    
    public void OnTriggerEnter(Collider other) {
        // WARNING: Don't use the SendMessage function. It's pretty slow
        // compared to a direct call or using C# events and delegates.
        // But...I used it because I'm pretty lazy. :D
        if (other.CompareTag("Player") || other.CompareTag("Enemy")) {
            other.SendMessage("TakeDamage", damage);
        }
    }
}
