using UnityEngine;
using System.Collections;

public class TankHealth : MonoBehaviour {

    public float tankHealth = 100f;

    private Animator animatorAI;
    private float currentHealth;

	// Use this for initialization
	private void Start () {
        currentHealth = tankHealth;
        if (gameObject.CompareTag("Enemy")) {
            animatorAI = GetComponent<Animator>();
        }
	}
	
	// Update is called once per frame
	private void Update () {
        if (CompareTag("Enemy") && currentHealth <= 0) {
            animatorAI.SetTrigger("Die");
        }
    }
}
