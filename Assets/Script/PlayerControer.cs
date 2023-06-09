using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEngine.EventSystems.StandaloneInputModule;
using UnityEngine.InputSystem;

public class PlayerControer : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3;
    private Rigidbody2D _rb = null;
    private Vector2 _moveInput;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        var current = Keyboard.current;

        var aKey = current.aKey;

        var dKey = current.dKey;

        if (aKey.isPressed)
        {
            _rb.AddForce(Vector2.left * _moveSpeed, ForceMode2D.Force);
        }
        if (dKey.isPressed)
        {
            _rb.AddForce(Vector2.right * _moveSpeed, ForceMode2D.Force);
        }
    }

    private void FixedUpdate()
    {

        _rb.velocity = new Vector2(_moveInput.x * _moveSpeed,_rb.velocity.y);
    }
}
