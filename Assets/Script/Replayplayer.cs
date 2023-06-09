using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replayplayer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("プレイヤーのprefabを追加")] private GameObject playerPrefab;

    void Update()
    {
        GameObject _playerob = GameObject.Find(playerPrefab.name);

        //playerobが存在していない場合
        if (_playerob == null )
        {
            GameObject _newPlayerob = Instantiate(playerPrefab, transform.position, playerPrefab.transform.rotation);
            _newPlayerob.name = playerPrefab.name;
        }
    }
}
