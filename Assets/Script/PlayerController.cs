using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //�ړ��̑��x
    [SerializeField] private float _moveSpeed;

    //�ڒn����
    [SerializeField] GroundCheck _ground;

    //�W�����v
    [SerializeField] private float _jumpSpeed;

    //���͂��ꂽ�l������ϐ�
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
        _isGrounded = _ground._isGround;//�ڒn����̃R���f�B�V�����̑��
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

    //���͌n��
    public void OnMove(InputAction.CallbackContext context)
    {
            _moveInput = context.ReadValue<Vector2>();
    }
    
    public void OnJump(InputAction.CallbackContext context)
    {
            _isJumping = context.ReadValueAsButton();
    }
}
