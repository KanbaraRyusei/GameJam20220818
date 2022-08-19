using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class YoutubersAnimatiorUtility : MonoBehaviour
{
    #region �����o
    /// <summary>�Ώۂ́AYoutube�z�M�̗l�q�𐧌䂷��A�j���[�^�[</summary>
    Animator _animator = null;

    [SerializeField, Tooltip("Animator�̃p�����[�^�[�� : �u��")]
    string _paramDoBlink = "DoBlink";

    [SerializeField, Tooltip("Animator�̃p�����[�^�[�� : �����J����")]
    string _paramIsMouseOpen = "IsMouseOpen";

    [SerializeField, Tooltip("Animator�̃p�����[�^�[�� : �A���`�R�����g�ʉ�")]
    string _paramDoReceivedHate = "DoReceivedHate";

    /// <summary>true : �A���`�R�����g���󂯎����</summary>
    bool _isReceiveHate = false;

    [SerializeField, Range(0f, 1f), Tooltip("�u����")]
    float _eyeBrowRatio = 0.1f;

    [SerializeField, Range(0f, 1f), Tooltip("���̌`��ς���m��")]
    float _switchMouseRatio = 0.4f;

    [SerializeField, Tooltip("�A�j���[�V���������鎞�ԊԊu")]
    float _animationDelay = 0.6f;

    /// <summary>�A�j���[�V���������鎞�ԊԊu�����R���[�`�����ő҂�����p�����[�^�[</summary>
    WaitForSeconds _delay = null;

    #endregion

    #region �v���p�e�B
    /// <summary>�A���`�R�����g���󂯎�������� true �ɂ��Ăǂ���</summary>
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

    /// <summary>�A�j���[�^�[�ɃA�j���[�V�����p�̃p�����[�^�[��n���R���[�`��</summary>
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

    /// <summary>�u������?</summary>
    /// <returns>true : ����</returns>
    bool DoBlink()
    {
        return Random.value < _eyeBrowRatio;
    }

    /// <summary>���̌`��ς���?</summary>
    /// <returns>true : �ς���</returns>
    bool DoSwitchMouse()
    {
        return Random.value < _switchMouseRatio;
    }
}
