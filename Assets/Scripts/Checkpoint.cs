using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public SpriteRenderer spriteRenderer;
    public Sprite checkpointOn, checkpointOff;

    void Start() {

    }

    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            DeactivateCheckpoints();
            ActivateCheckpoint();
            SetSpawnPoint();
        }
    }

    public void ResetCheckpoint() {
        spriteRenderer.sprite = checkpointOff;
    }

    private void ActivateCheckpoint() {
      spriteRenderer.sprite = checkpointOn;
    }

    private void DeactivateCheckpoints() {
      CheckpointController.instance.DeactivateCheckpoints();
    }

    private void SetSpawnPoint() {
      CheckpointController.instance.SetSpawnPoint(transform.position);
    }
}
