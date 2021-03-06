using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static LevelManager instance;
    public float waitToRespawn;
    public int gemsCollected;

    private void Awake() {
        instance = this;
    }

    void Start() {

    }

    void Update() {

    }

    public void RespawnPlayer() {
        StartCoroutine(RespawnCoroutine());
    }

    public void CollectGem() {
        gemsCollected++;
    }

    public string getCollectedGems() {
        return gemsCollected.ToString();
    }

    private IEnumerator RespawnCoroutine() {
        DeactivatePlayer();
        PlaySoundEffect();
        yield return new WaitForSeconds(waitToRespawn - (1f / UIController.instance.GetFadeSpeed()));
        UIController.instance.FadeToBlack();
        yield return new WaitForSeconds((1f / UIController.instance.GetFadeSpeed()) + .2f);
        UIController.instance.FadeFromBlack();
        ActivatePlayer();
        SetPlayerPosition();
        RestorePlayerHealth();
    }

    private void ActivatePlayer() {
        PlayerController.instance.gameObject.SetActive(true);
    }

    private void DeactivatePlayer() {
        PlayerController.instance.gameObject.SetActive(false);
    }

    private void SetPlayerPosition() {
        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;
    }

    private void RestorePlayerHealth() {
        PlayerHealthController.instance.RestorePlayerHealth();
        UIController.instance.UpdateHealthDisplay();
    }

    private void PlaySoundEffect() {
        AudioManager.instance.PlaySFX(AudioEffectsEnum.PLAYER_DEATH);
    }
}
