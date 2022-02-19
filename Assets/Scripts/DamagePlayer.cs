using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            // Easy way
            // FindObjectOfType<PlayerHealthController>().DealDamage();

            // Better way
            PlayerHealthController.instance.DealDamage();
            Debug.Log("Hit");
        }
    }
}
