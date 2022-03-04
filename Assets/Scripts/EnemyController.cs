using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

  public float moveSpeed;
  public float moveTime, waitTime;
  public Transform leftPoint, rightPoint;
  public SpriteRenderer enemySpriteRender;

  private float _moveCount, _waitCount;
  private bool _isMovingRight;
  private Rigidbody2D _enemyRigidBody;
  private Animator _animator;

    void Start() {
        InitRigidBody();
        RemovePointFromParent(leftPoint);
        RemovePointFromParent(rightPoint);
        _animator = GetComponent<Animator>();

        _isMovingRight = true;
        _moveCount = moveTime;
    }

    void Update() {
        if (_moveCount > 0) {
            _moveCount -= Time.deltaTime;
            if (_isMovingRight) {
                _enemyRigidBody.velocity = new Vector2(moveSpeed, _enemyRigidBody.velocity.y);
                FlipBody(true);
                if (CheckIfIsToTheRight()) {
                    _isMovingRight = false;
                }
            } else {
                _enemyRigidBody.velocity = new Vector2(-moveSpeed, _enemyRigidBody.velocity.y);
                FlipBody(false);
                if (CheckIfIsToTheLeft()) {
                    _isMovingRight = true;
                }
            }

            if (_moveCount <= 0) {
                _waitCount = Random.Range(waitTime * .75f, waitTime * 1.25f);
            }
            _animator.SetBool("isMoving", true);
        } else if (_waitCount > 0) {
            _waitCount -= Time.deltaTime;
            _enemyRigidBody.velocity = new Vector2(0f, _enemyRigidBody.velocity.y);

            if (_waitCount <= 0) {
                _moveCount = Random.Range(moveTime * .75f, waitTime * 1.25f);
            }
            _animator.SetBool("isMoving", false);
        }

    }

    private void InitRigidBody() {
        _enemyRigidBody = GetComponent<Rigidbody2D>();
    }

    private void RemovePointFromParent(Transform point) {
        point.parent = null;
    }

    private bool CheckIfIsToTheRight() {
        return transform.position.x > rightPoint.position.x;
    }

    private bool CheckIfIsToTheLeft() {
        return transform.position.x < leftPoint.position.x;
    }

    private void FlipBody(bool shouldFlip) {
        enemySpriteRender.flipX = shouldFlip;
    }
}
