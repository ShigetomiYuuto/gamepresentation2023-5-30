using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringContoller : MonoBehaviour
{
    // ƒWƒƒƒ“ƒv—Í
    [SerializeField] private float _jumpForce = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
