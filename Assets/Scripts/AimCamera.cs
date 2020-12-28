using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCamera : MonoBehaviour
{
    public Transform target;

    private Vector3 camOffset;

    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;

    public bool lookAtPlayer = false;

    public bool RotateAroundPlayer = true;

    public float RotationSpeed = 5.0f;

    private void Start()
    {
        camOffset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        if (RotateAroundPlayer)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);
            camOffset = camTurnAngle * camOffset;
        }

        Vector3 newPos = target.position + camOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

        if (lookAtPlayer || RotateAroundPlayer)
        {
            transform.LookAt(target);
        }
    }





}
