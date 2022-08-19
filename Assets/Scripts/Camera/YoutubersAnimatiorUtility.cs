using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class YoutubersAnimatiorUtility : MonoBehaviour
{
    #region メンバ
    /// <summary>対象の、Youtube配信の様子を制御するアニメーター</summary>
    Animator _animator = null;

    [SerializeField, Tooltip("Animatorのパラメーター名 : 瞬き")]
    string _paramDoBlink = "DoBlink";

    [SerializeField, Tooltip("Animatorのパラメーター名 : 口を開閉する")]
    string _paramIsMouseOpen = "IsMouseOpen";

    [SerializeField, Tooltip("Animatorのパラメーター名 : アンチコメント通過")]
    string _paramDoReceivedHate = "DoReceivedHate";

    /// <summary>true : アンチコメントを受け取った</summary>
    bool _isReceiveHate = false;

    [SerializeField, Range(0f, 1f), Tooltip("瞬き率")]
    float _eyeBrowRatio = 0.1f;

    [SerializeField, Range(0f, 1f), Tooltip("口の形を変える確率")]
    float _switchMouseRatio = 0.4f;

    [SerializeField, Tooltip("アニメーションさせる時間間隔")]
    float _animationDelay = 0.6f;

    /// <summary>アニメーションさせる時間間隔だけコルーチン内で待たせるパラメーター</summary>
    WaitForSeconds _delay = null;

    #endregion

    #region プロパティ
    /// <summary>アンチコメントを受け取った時に true にしてどうぞ</summary>
    public bool IsReceiveHate { set => _isReceiveHate = value; }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _delay = new WaitForSeconds(_animationDelay);

        StartCoroutine(SendEyeBlinkParameter());
        StartCoroutine(SendMouseOpenParameter());
    }

    void Update()
    {
        if (_isReceiveHate)
        {
            _animator.SetTrigger(_paramDoReceivedHate);
            _isReceiveHate = false;
        }
    }

    void OnEnable()
    {
        StartCoroutine(SendEyeBlinkParameter());
        StartCoroutine(SendMouseOpenParameter());
    }

    /// <summary>アニメーターにアニメーション用のパラメーターを渡すコルーチン</summary>
    IEnumerator SendEyeBlinkParameter()
    {
        yield return null;

        while (enabled)
        {
            if (DoBlink())
            {
                _animator.SetTrigger(_paramDoBlink);
            }
            yield return _delay;
        }
    }

    IEnumerator SendMouseOpenParameter()
    {
        yield return null;

        while (enabled)
        {
            if (DoSwitchMouse())
            {
                _animator.SetBool(_paramIsMouseOpen, !_animator.GetBool(_paramIsMouseOpen));

                if (_animator.GetBool(_paramIsMouseOpen))
                {
                    yield return new WaitForSeconds(Random.Range(0.2f, _animationDelay));
                }
                else
                {
                    yield return _delay;
                }
            }
        }
    }

    /// <summary>瞬きする?</summary>
    /// <returns>true : する</returns>
    bool DoBlink()
    {
        return Random.value < _eyeBrowRatio;
    }

    /// <summary>口の形を変える?</summary>
    /// <returns>true : 変える</returns>
    bool DoSwitchMouse()
    {
        return Random.value < _switchMouseRatio;
    }
}
