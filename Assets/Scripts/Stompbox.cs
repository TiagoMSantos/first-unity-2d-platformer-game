using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stompbox : MonoBehaviour {

  public GameObject deathEffect;
  public GameObject collectible;
  [Range(0, 100)]public float chanceToDrop;

    void Start() {

    }

    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy") {
            other.transform.parent.gameObject.SetActive(false);
            Instantiate(deathEffect, other.transform.position, other.transform.rotation);
            PlayerController.instance.Bounce();

            float dropSelect = Random.Range(0, 100f);

            if (dropSelect <= chanceToDrop) {
                Instantiate(collectible, other.transform.position, other.transform.rotation);
            }

            PlaySoundEffect();
        }
    }

    private void PlaySoundEffect() {
        AudioManager.instance.PlaySFX(AudioEffectsEnum.ENEMY_EXPLODE);
    }
}
