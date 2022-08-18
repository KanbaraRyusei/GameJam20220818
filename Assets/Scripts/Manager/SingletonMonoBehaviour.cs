using System;
using UnityEngine;

/// <summary>
/// �V���O���g���p�^�[�����g�������Ƃ��Ɏg���ĉ�����
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                Type t = typeof(T);
                _instance = FindObjectOfType(t) as T;
                if(_instance == null)
                {
                    Debug.LogError(_instance + "��Null�ł�");
                }
            }
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
        }
        if(_instance == this)
        {
            return;
        }
        if (_instance != null)
        {
            Destroy(gameObject);
        }
    }
}
