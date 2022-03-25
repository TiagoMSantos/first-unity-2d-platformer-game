using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour {

    public static UIController instance;
    public Image heart1, heart2, heart3;
    public Sprite heartFull, heartHalf, heartEmpty;
    public Text gemLabel;
    public Image fadeScreen;
    private float _fadeSpeed = 0.5f;
    private bool _shouldFadeToBlack;
    private bool _shouldFadeFromBlack;

    private void Awake() {
        instance = this;
    }

    void Start() {
        UpdateGemCount();
        FadeFromBlack();
    }

    void Update() {
        if (_shouldFadeToBlack) {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, _fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 1f) {
                _shouldFadeToBlack = false;
            }
        }

        if (_shouldFadeFromBlack) {
          fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, _fadeSpeed * Time.deltaTime));
          if (fadeScreen.color.a == 0f) {
              _shouldFadeFromBlack = false;
          }
        }
    }

    public float GetFadeSpeed() {
        return _fadeSpeed;
    }

    public void UpdateHealthDisplay() {
        switch (PlayerHealthController.instance.currentHealth) {
            case 6:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;

                break;
            case 5:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartHalf;

                break;
            case 4:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;

                break;
            case 3:
                heart1.sprite = heartFull;
                heart2.sprite = heartHalf;
                heart3.sprite = heartEmpty;

                break;
            case 2:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;
            case 1:
                heart1.sprite = heartHalf;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;
            case 0:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;
            default:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;
        }
    }

    public void UpdateGemCount() {
          gemLabel.text = LevelManager.instance.getCollectedGems();
    }

    public void FadeToBlack() {
        _shouldFadeToBlack = true;
        _shouldFadeFromBlack = false;
    }

    public void FadeFromBlack() {
        _shouldFadeFromBlack = true;
        _shouldFadeToBlack = false;
    }
}
