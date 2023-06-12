using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerControer : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3;
    [SerializeField] GroundCheck ground;
    [SerializeField] float _jumpPower;
    public bool _isJumping = false;
    public float gravity;

    private Rigidbody2D _rb = null;
    private bool _isGround  = false;
    private Vector2 _moveInput;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _isGround = ground.IsGround();

        var current = Keyboard.current;

        var aKey = current.aKey;

        var dKey = current.dKey;

        var spacekey = current.spaceKey;

        if (aKey.isPressed)
        {
            _rb.AddForce(Vector2.left * _moveSpeed, ForceMode2D.Force);
        }
        if (dKey.isPressed)
        {
            _rb.AddForce(Vector2.right * _moveSpeed, ForceMode2D.Force);
        }
        if (spacekey.wasPressedThisFrame && !_isJumping)
        {
            _rb.velocity = Vector2.up * _jumpPower;
            _isJumping = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isJumping = false;
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_moveInput.x * _moveSpeed,_rb.velocity.y);
    }
}
