using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replayplayer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("ƒvƒŒƒCƒ„[‚Ìprefab‚ğ’Ç‰Á")] private GameObject playerPrefab;

    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        GameObject _playerob = GameObject.Find(playerPrefab.name);

        //playerob‚ª‘¶İ‚µ‚Ä‚¢‚È‚¢ê‡
        if (_playerob == null )
        {
            GameObject _newPlayerob= Instantiate(playerPrefab);
            _newPlayerob.name = playerPrefab.name;
        }
    }
}
