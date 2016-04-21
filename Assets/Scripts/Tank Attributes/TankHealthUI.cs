using UnityEngine;
using UnityEngine.UI;

public class TankHealthUI : MonoBehaviour {

    public Transform tank;

    TankHealth tankHealth;
    Image progress;


    void Start() {
        progress = GetComponent<Image>();
        tankHealth = tank.GetComponent<TankHealth>();
    }

    void Update() {
        transform.position = tank.position;
        progress.fillAmount = tankHealth.CurrentHealth / tankHealth.tankHealth;
    }

}
