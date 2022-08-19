using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class GameManager
{
    /// <summary>
    /// ゲーム開始時に呼ばれるデリゲート
    /// </summary>
    public static event Action OnGameStart;

    /// <summary>
    /// ゲーム終了時に呼ばれるデリゲート
    /// </summary>
    public static event Action OnGameOver;

    public static void GameStart()
    {
        OnGameStart?.Invoke();
        OnGameStart = null;
    }

    public static void GameOver()
    {
        OnGameOver?.Invoke();
        OnGameOver = null;
    }
}
