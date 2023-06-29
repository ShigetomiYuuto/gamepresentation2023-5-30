using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replayplayer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("ƒvƒŒƒCƒ„[‚Ìprefab‚ğ’Ç‰Á")] private GameObject playerPrefab;

    void Update()
    {
        GameObject _playerob = GameObject.Find(playerPrefab.name);

        //playerob‚ª‘¶İ‚µ‚Ä‚¢‚È‚¢ê‡
        if (_playerob == null )
        {
            GameObject _newPlayerob = Instantiate(playerPrefab, transform.position, playerPrefab.transform.rotation);
            _newPlayerob.name = playerPrefab.name;
        }
    }
}
