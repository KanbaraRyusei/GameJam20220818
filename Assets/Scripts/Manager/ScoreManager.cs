using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager
{
    // ƒvƒƒpƒeƒB
    public static int HighlyRated => _highlyRated;
    public static int LowRating => _lowRating;

    // ƒƒ“ƒo•Ï”
    [Tooltip("‚•]‰¿”")]
    private static int _highlyRated;
    [Tooltip("’á•]‰¿”")]
    private static int _lowRating;

    /// <summary>
    /// ‰Šú‰»‚·‚éŠÖ”
    /// </summary>
    public static void Init()
    {
        _highlyRated = 0;
        _lowRating = 0;
    }

    /// <summary>
    /// ‚•]‰¿‚ğ‰ÁZ‚·‚éŠÖ”
    /// </summary>
    /// <param name="num"></param>
    public static void AddHighlyRated(int num)
    {
        _highlyRated += num;
    }

    /// <summary>
    /// ’á•]‰¿‚ğ‰ÁZ‚·‚éŠÖ”
    /// </summary>
    /// <param name="num"></param>
    public static void AddLowRating(int num)
    {
        _lowRating += num;
    }

    /// <summary>
    /// ‚•]‰¿‚ğŒ¸‚ç‚·ŠÖ”
    /// </summary>
    /// <param name="num"></param>
    public static void DecreaseHighlyRated(int num)
    {
        _highlyRated -= num;
    }
}
