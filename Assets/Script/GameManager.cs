using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool _isPaused = false;
    [SerializeField] GameObject _pausedUI;

    // Start is called before the first frame update
    void Start()
    {
        _pausedUI.SetActive(_isPaused);
    }

    // Update is called once per frame
    void Update()
    {
        _pausedUI.SetActive(_isPaused);
    }
}
