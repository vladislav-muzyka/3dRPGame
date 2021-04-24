using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _angleOffset;
    [SerializeField] private float _clampRate;

    private float cumRotSpeed = 100f;
    private float currCumRotSpeed = 0f;
    private void Update()
    {
        currCumRotSpeed += Input.GetAxis("Horizontal") * cumRotSpeed * Time.deltaTime;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position + _offset, _clampRate);
        transform.LookAt(_target.position + Vector3.up + _angleOffset);

        transform.RotateAround(_target.position, Vector3.up, currCumRotSpeed);
    }
}
