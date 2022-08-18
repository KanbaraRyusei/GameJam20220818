using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class GameManager
{
    /// <summary>
    /// �Q�[���J�n���ɌĂ΂��f���Q�[�g
    /// </summary>
    public static event Action OnGameStart;

    /// <summary>
    /// �Q�[���I�����ɌĂ΂��f���Q�[�g
    /// </summary>
    public static event Action OnGameOver;

    public static void GameStart()
    {
        OnGameStart?.Invoke();
    }

    public static void GameOver()
    {
        OnGameOver?.Invoke();
    }
}
