using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    public void RestartSesion()
    {
        SceneManager.LoadScene(0);
    }
}