using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour {

    public static PlayerHealthController instance;
    public int currentHealth, maxHealth;
    public float invincibleLength;

    private float invincibleCounter;

    private void Awake() {
        instance = this;
    }

    void Start() {
        currentHealth = maxHealth;
    }

    void Update() {
        
    }

    public void DealDamage() {
        currentHealth--;

        if (currentHealth <= 0) {
            currentHealth = 0;
            gameObject.SetActive(false);
        }

        UIController.instance.UpdateHealthDisplay();
    }
}
