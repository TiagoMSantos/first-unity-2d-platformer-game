using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public bool isGem;
    public bool isHealth;
    public GameObject pickupEffect;

    private bool _isCollected;

    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && !_isCollected) {
            if (isGem) {
                CollectGem();
                IsCollected(true);
                DestroyObject();
            }
            if (isHealth) {
                if (!CheckFullHealth()) {
                    CollectHealth();
                    IsCollected(true);
                    DestroyObject();
                }
            }
        }
    }

    private void CollectGem() {
        LevelManager.instance.CollectGem();
        UpdateGemCount();
    }

    private void CollectHealth() {
        PlayerHealthController.instance.AddHealth();
    }

    private bool CheckFullHealth() {
        return PlayerHealthController.instance.CheckIfLifeIsFull();
    }

    private void DestroyObject() {
        Destroy(gameObject);
        // Add pickup Effect
        Instantiate(pickupEffect, transform.position, transform.rotation);
    }

    private void IsCollected(bool isCollected) {
        _isCollected = isCollected;
    }

    private void UpdateGemCount() {
        UIController.instance.UpdateGemCount();
    }
}
