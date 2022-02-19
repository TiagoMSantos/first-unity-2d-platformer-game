using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public Transform farBackground, middleBackground;
    public float minHeight, maxHeight;
    private Vector2 _lastPos;

    // Start is called before the first frame update
    void Start() {
        _lastPos = transform.position;
    }

    // Update is called once per frame
    void Update() {
        SetupCamera();
        SetupParallax();
    }

    private void SetupCamera() {
        // transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        // float clampedY = Mathf.Clamp(transform.position.y, minHeight, maxHeight);
        // transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);

        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);
    }

    private void SetupParallax() {
        Vector2 amountToMove = new Vector2(transform.position.x - _lastPos.x, transform.position.y - _lastPos.y);
        farBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f);
        middleBackground.position += new Vector3(amountToMove.x * .5f, amountToMove.y, 0f) * .5f;

        _lastPos = transform.position;
    }
}
