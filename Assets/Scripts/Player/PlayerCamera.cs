using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 0.1f;
    [SerializeField] private bool _inverseY = false;

    [SerializeField] private PlayerWalk _player;
    [SerializeField] private Transform _cameraPoint;
    [SerializeField] private CameraState _cameraState;

    private float _pitch = 0;
    private float _yaw = 0;

    public void SwitchStateTo(CameraState state)
    {
        if (state == CameraState.Player)
            SyncPlayerCamera();

        _cameraState = state;
    }

    private void Update()
    {
        switch (_cameraState)
        {
            case CameraState.Player:
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                SyncPlayerCamera();
                PlayerAction();
                break;
            case CameraState.Await:
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                SyncPlayerCamera();
                break;
            case CameraState.Scene:
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                break;
        }
    }

    private void SyncPlayerCamera()
    {
        transform.position = _cameraPoint.position;
    }

    private void PlayerAction()
    {
        _yaw += Input.GetAxis("Mouse X") * _sensitivity;

        if (_inverseY)
            _pitch += Input.GetAxis("Mouse Y") * _sensitivity;
        else
            _pitch -= Input.GetAxis("Mouse Y") * _sensitivity;

        _pitch = Mathf.Clamp(_pitch, -80, 80);

        transform.rotation = Quaternion.Euler(_pitch, _yaw, 0);
        _player.SetRotation(Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0)));
    }
}

public enum CameraState
{
    Player,
    Await,
    Scene
}
