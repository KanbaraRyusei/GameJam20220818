using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager
{
    // �v���p�e�B
    public static int HighlyRated => _highlyRated;
    public static int LowRating => _lowRating;

    // �����o�ϐ�
    [Tooltip("���]����")]
    private static int _highlyRated;
    [Tooltip("��]����")]
    private static int _lowRating;

    /// <summary>
    /// ����������֐�
    /// </summary>
    public static void Init()
    {
        _highlyRated = 0;
        _lowRating = 0;
    }

    /// <summary>
    /// ���]�������Z����֐�
    /// </summary>
    /// <param name="num"></param>
    public static void AddHighlyRated(int num)
    {
        _highlyRated += num;
    }

    /// <summary>
    /// ��]�������Z����֐�
    /// </summary>
    /// <param name="num"></param>
    public static void AddLowRating(int num)
    {
        _lowRating += num;
    }

    /// <summary>
    /// ���]�������炷�֐�
    /// </summary>
    /// <param name="num"></param>
    public static void DecreaseHighlyRated(int num)
    {
        _highlyRated -= num;
    }
}
