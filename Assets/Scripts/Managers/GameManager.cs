using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Instance
    public static GameManager instance;
    void InitSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion

    private void Awake()
    {
        InitSingleton();
    }
    public bool gameStarted;

    public void StartGame()
    {
        gameStarted = true;
        UiManager.instance.StartGame();
    }
}
