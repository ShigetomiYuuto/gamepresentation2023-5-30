using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private string _groundTag = "Ground";
    public bool _isGround = false;
    private bool isGroundEnter, isGroundStay, isGroundExit;

    public bool IsGround()
    {
        if (isGroundEnter || isGroundStay)
        {
            _isGround = true;
        }
        else if (isGroundExit)
        {
            _isGround = false;
        }

        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;
        return _isGround;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == _groundTag)
        {
            isGroundEnter = true;
            Debug.Log("”»’è‚É“ü‚Á‚½");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == _groundTag)
        {
            isGroundStay = true;
            Debug.Log("”»’è‚É“ü‚Á‚Ä‚¢‚é");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == _groundTag)
        {
            isGroundExit = true;
            Debug.Log("”»’è‚©‚ç”²‚¯‚½");
        }
    }
}