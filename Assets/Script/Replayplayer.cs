using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replayplayer : MonoBehaviour
{
    [SerializeField]  GameObject playerPrefab;

    void Update()
    {
       // GameObject _playerob = GameObject.Find(playerPrefab.name);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Traps")
        {
            transform.position = playerPrefab.transform.position;
        }
    }
}
