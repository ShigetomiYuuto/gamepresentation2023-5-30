using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replayplayer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�v���C���[��prefab��ǉ�")] private GameObject playerPrefab;

    void Update()
    {
        GameObject _playerob = GameObject.Find(playerPrefab.name);

        //playerob�����݂��Ă��Ȃ��ꍇ
        if (_playerob == null )
        {
            GameObject _newPlayerob = Instantiate(playerPrefab, transform.position, playerPrefab.transform.rotation);
            _newPlayerob.name = playerPrefab.name;
        }
    }
}
