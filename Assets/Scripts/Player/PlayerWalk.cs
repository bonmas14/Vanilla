using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerWalk : MonoBehaviour
{
    [Header("Game design")]
    [SerializeField] private float _playerSpeed = 5;

    private Rigidbody _body;
    private Vector3 _input = Vector3.zero;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var _forwardMove = Input.GetAxis("Vertical") * _playerSpeed;
        var _sideMove = Input.GetAxis("Horizontal") * _playerSpeed;
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _forwardMove *= 2;
            _sideMove *= 2;
        }

        _input = _forwardMove * transform.forward + _sideMove * transform.right;
    }


    private void FixedUpdate()
    {
        Vector3 direction = _input * Time.fixedDeltaTime;

        _body.MovePosition(_body.position + direction);
    }

    internal void SetRotation(Quaternion quaternion)
    {
        _body.rotation = quaternion;
    }
}
