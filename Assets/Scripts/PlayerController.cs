using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance;

    public float moveSpeed;
    public float jumpForce;
    public float knockBackLength;
    public float knockBackForce;
    public float bounceForce;
    private bool _isGrounded;
    private bool _canDoubleJump;
    private float _knockBackCounter;

    public Rigidbody2D playerRigidBody;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake() {
        instance = this;
    }

    void Start() {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {

        if (!PauseMenu.instance.isPaused) {
            if (_knockBackCounter <= 0) {
                // GetAxis
                playerRigidBody.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), playerRigidBody.velocity.y);

                _isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

                if (_isGrounded) {
                    _canDoubleJump = true;
                }

                if (Input.GetButtonDown("Jump")) {
                    if (_isGrounded) {
                        Jump();
                    } else {
                        if (_canDoubleJump) {
                            Jump();
                            _canDoubleJump = false;
                        }
                    }
                }

                CheckFlip();
            } else {
                _knockBackCounter -= Time.deltaTime;
                PushBack();
            }
        }

        _animator.SetFloat("moveSpeed", Mathf.Abs(playerRigidBody.velocity.x));
        _animator.SetBool("isGrounded", _isGrounded);
    }

    public void Bounce() {
        playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, bounceForce);
        PlaySoundEffect();
    }

    private void Jump() {
        playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
        PlaySoundEffect();
    }

    private void CheckFlip() {
        if (playerRigidBody.velocity.x < 0) {
            _spriteRenderer.flipX = true;
        } else if (playerRigidBody.velocity.x > 0) {
            _spriteRenderer.flipX = false;
        }
    }

    public void KnockBack() {
        _knockBackCounter = knockBackLength;
        playerRigidBody.velocity = new Vector2(0f, knockBackForce);

        _animator.SetTrigger("hurt");
    }

    private void PushBack() {
        if (!_spriteRenderer.flipX) {
            playerRigidBody.velocity = new Vector2(-knockBackForce, playerRigidBody.velocity.y);
        } else {
            playerRigidBody.velocity = new Vector2(knockBackForce, playerRigidBody.velocity.y);
        }
    }

    private void PlaySoundEffect() {
        AudioManager.instance.PlaySFX(AudioEffectsEnum.PLAYER_JUMP);
    }
}
