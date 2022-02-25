using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {

    public static CheckpointController instance;
    public Vector3 spawnPoint;
    private Checkpoint[] _checkpoints;


  private void Awake() {
      instance = this;
  }

  void Start() {
      _checkpoints = FindObjectsOfType<Checkpoint>();
      spawnPoint = PlayerController.instance.transform.position;
  }

  void Update() {

  }


  public void DeactivateCheckpoints() {
      for(int i = 0; i < _checkpoints.Length; i++) {
          _checkpoints[i].ResetCheckpoint();
      }
  }

  public void SetSpawnPoint(Vector3 newSpawnPoint) {
    spawnPoint = newSpawnPoint;
  }
}
