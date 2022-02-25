using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour {

    public static PlayerHealthController instance;
    public int currentHealth, maxHealth;
    public float invincibleLength;

    private float invincibleCounter;
    private SpriteRenderer spriteRender;

    private void Awake() {
        instance = this;
    }

    void Start() {
        currentHealth = maxHealth;
        spriteRender = GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (invincibleCounter > 0) {
            invincibleCounter -= Time.deltaTime;
            if (invincibleCounter <= 0) {
                ChangePlayerAlpha(1f);
            }
        }
    }

    public void DealDamage() {
        if (invincibleCounter <= 0) {
            currentHealth--;

             if (currentHealth <= 0) {
                 currentHealth = 0;
                 // gameObject.SetActive(false);
                 RespawnPlayer();

             } else {
                 invincibleCounter = invincibleLength;
                 ChangePlayerAlpha(.5f);
                 CheckKnockBack();
             }

             UIController.instance.UpdateHealthDisplay();
        }
    }

    public void RestorePlayerHealth() {
        currentHealth = maxHealth;
    }

    private void ChangePlayerAlpha(float alpha) {
        spriteRender.color = new Color(spriteRender.color.r, spriteRender.color.g, spriteRender.color.b, alpha);
    }

    private void CheckKnockBack() {
        PlayerController.instance.KnockBack();
    }

    private void RespawnPlayer() {
        LevelManager.instance.RespawnPlayer();
    }
}
