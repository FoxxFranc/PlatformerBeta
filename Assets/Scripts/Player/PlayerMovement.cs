using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private GroundChecker _groundChecker;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private Vector3 _currentScale;

    private const string Walk = "Walk";
    private const string Iddle = "Iddle";
    private const string Jump = "Jump";

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _currentScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }


    private void Update()
    {
        Move(_speed);
        DoJump(_jumpForce);
    }

    private void Move(float speed)
    {
        float deltaMoveX = Input.GetAxis("Horizontal");
        transform.Translate(deltaMoveX * speed * Time.deltaTime, 0, 0);
        if (deltaMoveX != 0)
        {
            _animator.Play(Walk);
        }
        else
        {
            _animator.Play(Iddle);
        }
        ChangeScale(deltaMoveX);
    }

    private void ChangeScale(float moveDirrection)
    {
        if (moveDirrection > 0)
        {
            transform.localScale = _currentScale;
        }
        if (moveDirrection < 0)
        {
            transform.localScale = new Vector3(-_currentScale.x, _currentScale.y, _currentScale.z);
        }
    }

    private void DoJump(float jumpForce)
    {
        if (Input.GetKey(KeyCode.Space) && _groundChecker.IsGrounded)
        {
            _rigidbody2D.AddForce(new Vector2(0, jumpForce));
            _animator.Play(Jump);
        }
    }
}
