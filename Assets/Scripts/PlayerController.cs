using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;
    private bool _isGrounded;
    private bool _canDoubleJump;

    public Rigidbody2D playerRigidBody;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    void Start() {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
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

        _animator.SetFloat("moveSpeed", Mathf.Abs(playerRigidBody.velocity.x));
        _animator.SetBool("isGrounded", _isGrounded);
    }

    private void Jump() {
        playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
    }

    private void CheckFlip() {
        if (playerRigidBody.velocity.x < 0) {
            _spriteRenderer.flipX = true;
        } else if (playerRigidBody.velocity.x > 0) {
            _spriteRenderer.flipX = false;
        }
    }
}
