using System.Collections;
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

    //�̗�
    [SerializeField] private int _hp;

    //���͂��ꂽ�l������ϐ�
    [SerializeField] private Vector2 _moveInput;

    //�_�b�V���̉����x
    [SerializeField] private float _dashingVelocity = 14f;

    //�_�b�V�����鎞��
    [SerializeField] private float _dashindTime = 0.5f;

    //private float _Inputdash;

    //�_�b�V���̕�����ۑ����Ă���H
    private Vector2 _dashingDir;

    //�L�������_�b�V�������m�F���邽�߂�bool�l?
    private bool _isDashing;

    //�L�������_�b�V���ł��邩�m�F���邽�߂̂���?
    private bool _canDash = true;

    //�ςȐ����o����
    private TrailRenderer _trailRenderer;

    private bool _Inputdash;

    public bool _isJumping = false;

    private Rigidbody2D _rb = default;

    private bool _isGrounded  = false;

    [SerializeField] GameObject _groundChecker = null;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _ground = _groundChecker.GetComponent<GroundCheck>();

        //TrailRenderer���擾���Ă���
        _trailRenderer = GetComponent<TrailRenderer>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Traps")
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        _isGrounded = _ground._isGround;//�ڒn����̃R���f�B�V�����̑��
        //Debug.Log($"Player Condition Grounded IS {_isGrounded}");
        Move();
        Jump();
        Dash();
        //Debug.Log(_hp);
    }
    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(_dashindTime);
        _trailRenderer.emitting = false;
        _isDashing = false;
    }

    void Move()
    {
        _rb.velocity = new Vector2(_moveInput.x * _moveSpeed, _rb.velocity.y);
    }
    void Jump()
    {
        if (_isGrounded && _isJumping)
        {
            _rb.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
        }
    }

    void Dash()
    {
        var input = Keyboard.current;
        if (input == null) return;

        //var Enter = input.enterKey;
        //var dashInput = Input.GetButtonDown("Dash");
        // inputx:bool = Input.GetAxisRaw("Horizontal");

        if (_Inputdash && _canDash)
        {
            _isDashing = true;
            _canDash = false;
            _trailRenderer.emitting = true;
            _dashingDir = new Vector2(_moveInput.x,_moveInput.y);
            if (_dashingDir == Vector2.zero)
            {
                _dashingDir = new Vector2(transform.localScale.x, y: 0);
            }
            StartCoroutine(routine: StopDashing());
        }

        if (_isDashing)
        {
            _rb.velocity = _dashingDir.normalized * _dashingVelocity;
            return;
        }

        if (_isGrounded)
        {
            _canDash = true;
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

    public void OnDash(InputAction.CallbackContext context)
    {
        _Inputdash = context.ReadValueAsButton();
    }

    public void Daage (int damage)
    {
        _hp = Mathf.Max(_hp - damage,0);
    }
}
