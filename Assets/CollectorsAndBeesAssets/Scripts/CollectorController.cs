using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorController : MonoBehaviour {
    public float moveSpeed = 5f;

    void Start() {
    }

    void Update() {
        Vector3 inputDirection = Vector3.zero;
        inputDirection.x = Input.GetAxis("LeftJoystickHorizontal");
        inputDirection.y = Input.GetAxis("RightJoystickVertical");
        inputDirection.z = Input.GetAxis("LeftJoystickVertical");
        transform.position += moveSpeed * Time.deltaTime * inputDirection;
    }
}
