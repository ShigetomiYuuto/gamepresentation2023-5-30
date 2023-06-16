using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private string _groundTag = "Ground";
    public bool _isGround = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == _groundTag)
        {
            _isGround = true;
            Debug.Log("”»’è‚É“ü‚Á‚½");
            Debug.Log($"{_isGround}");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == _groundTag)
        {
            //_isGround = true;
            //Debug.Log("”»’è‚É“ü‚Á‚Ä‚¢‚é");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == _groundTag)
        {
            _isGround = false;
            Debug.Log("”»’è‚©‚ç”²‚¯‚½");
        }
    }
}