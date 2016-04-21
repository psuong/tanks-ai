using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    
    // Amount of damage the projectiles does.
    public float damage = 20f;
    public string compareTag;

    private bool canDoDamage;

    private void Start() {
        canDoDamage = true;
        if (compareTag == null && tag == "Player") {
            compareTag = "Enemy";
        }
        else if (compareTag == null && tag == "Enemy") {
            compareTag = "Player";
        }
    }
    
    public void OnTriggerEnter(Collider other) {
        // WARNING: Don't use the SendMessage function. It's pretty slow
        // compared to a direct call or using C# events and delegates.
        // But...I used it because I'm pretty lazy. :D
        if (other.CompareTag(compareTag) && canDoDamage) {
            other.SendMessage("TakeDamage", damage);
            canDoDamage = false;
        }
        // canDoDamage = false;
        Destroy(gameObject, 4f);
    }
}
