using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //移動の速度
    [SerializeField] private float _moveSpeed;

    //接地判定
    [SerializeField] GroundCheck _ground;

    //ジャンプ
    [SerializeField] private float _jumpSpeed;

    //入力された値を入れる変数
    [SerializeField] private Vector2 _moveInput;

    public bool _isJumping = false;

    private Rigidbody2D _rb = default;

    private bool _isGrounded  = false;

    [SerializeField] GameObject _groundChecker = null;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _ground = _groundChecker.GetComponent<GroundCheck>();
    }

    private void FixedUpdate()
    {
        _isGrounded = _ground._isGround;//接地判定のコンディションの代入
        Debug.Log($"Player Condition Grounded IS {_isGrounded}");
        Move();
        Jump();
    }

    void Move()
    {
        _rb.velocity = new Vector2(_moveInput.x * _moveSpeed, _rb.velocity.y);
    }
    void Jump()
    {
        if (_isGrounded && _isJumping)
        {
            _rb.AddForce(Vector2.up * _jumpSpeed,ForceMode2D.Impulse);
        }
    }

    //入力系統
    public void OnMove(InputAction.CallbackContext context)
    {
            _moveInput = context.ReadValue<Vector2>();
    }
    
    public void OnJump(InputAction.CallbackContext context)
    {
            _isJumping = context.ReadValueAsButton();
    }
}
