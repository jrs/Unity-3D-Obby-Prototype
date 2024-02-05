using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour
{
    private GameSession _gameSession;
    // Start is called before the first frame update
    void Start()
    {
        _gameSession = GameObject.Find("Game Session").GetComponent<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            _gameSession.RestartSesion();
        }
    }
}