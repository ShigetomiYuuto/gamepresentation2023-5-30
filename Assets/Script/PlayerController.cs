using System.Collections;
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
    //体力
    [SerializeField] private int _hp;
    //入力された値を入れる変数
    [SerializeField] private Vector2 _moveInput;
    //ダッシュの加速度
    [SerializeField] private float _dashingVelocity = 14f;
    //ダッシュする時間
    [SerializeField] private float _dashindTime = 0.5f;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] GameObject _playerSpawn;
    //ダッシュの方向を保存している？
    private Vector2 _dashingDir;
    //キャラがダッシュ中か確認するためのbool値?
    private bool _isDashing;
    //キャラがダッシュできるか確認するためのもの?
    private bool _canDash = true;
    //変な線が出るやつ
    private TrailRenderer _trailRenderer;
    private bool _inputDash;
    public bool _isJumping = false;
    private Rigidbody2D _rb = default;
    private bool _isGrounded  = false;
    [SerializeField] GameObject _groundChecker = null;
    [SerializeField] GameObject _gameManager = null;
    public AudioClip _sound1;
    public AudioClip _sound2;
    public AudioClip _sound3;
    AudioSource _audioSource;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _ground = _groundChecker.GetComponent<GroundCheck>();
        //TrailRendererを取得している
        _trailRenderer = GetComponent<TrailRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Traps")
        {
            transform.position = _playerSpawn.transform.position;
        }

        if (collision.gameObject.CompareTag("Spring"))
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _canDash = true;
        }
    }

    private void FixedUpdate()
    {
        _isGrounded = _ground._isGround;//接地判定のコンディションの代入
        Move();
        Jump();
        Dash();
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
        //if (_isGrounded && _isJumping)
        //{
        //    _rb.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
        //    _audioSource.PlayOneShot(_sound2);
        //}
    }

    void Dash()
    {
        var input = Keyboard.current;
        if (input == null) return;

        if (_inputDash && _canDash)
        {
            _isDashing = true;
            _canDash = false;
            _trailRenderer.emitting = true;
            _dashingDir = new Vector2(_moveInput.x,_moveInput.y);
            _audioSource.PlayOneShot(_sound3);

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

    #region  入力系統

    //入力系統
    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            //_isJumping = context.ReadValueAsButton();
            if (_isGrounded)
            {
                _rb.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
                _audioSource.PlayOneShot(_sound2);
            }
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        _inputDash = context.ReadValueAsButton();
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        _audioSource.PlayOneShot(_sound1);
        if (_gameManager.GetComponent<GameManager>()._isPaused)
        {
            _gameManager.GetComponent<GameManager>()._isPaused = false;
            Time.timeScale = 1;
            
        }
        else
        {
            _gameManager.GetComponent<GameManager>()._isPaused = true;
            Time.timeScale = 0;   
        }
    }

    #endregion

    public void Daage (int damage)
    {
        _hp = Mathf.Max(_hp - damage,0);
    }
}
