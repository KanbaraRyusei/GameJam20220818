using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScript : MonoBehaviour
{
    [SerializeField] GameObject _load;
    [SerializeField] GameObject _main;
    [SerializeField] GameObject _dolphin;
    [SerializeField] GameObject _dolphinComment;
    [SerializeField] GameObject _helpUI;
    [SerializeField] GameObject _help;
    [SerializeField] GameObject _help1;
    [SerializeField] GameObject _window;
    [SerializeField] GameObject _close;

    [SerializeField] int _loadTimeMin;
    [SerializeField] int _loadTimeMax;
    float _timer;
  
    [SerializeField] AudioClip _audioClip;


    void Awake()
    {
        SoundManager.Instance.PlayBGM(_audioClip);
    }


    void OnEnable()
    {
        _load.SetActive(true);
        _main.SetActive(true);
        _dolphin.SetActive(true);
        _dolphinComment.SetActive(false);
        _helpUI.SetActive(false);
        _help.SetActive(true);
        _help1.SetActive(false);
        _window.SetActive(false);
        _close.SetActive(true);
    }


    void Update()
    {
        _timer += Time.deltaTime;
        int loadTime = Random.Range(_loadTimeMin, _loadTimeMax);

        if (_timer > loadTime) 
        {
            _load.SetActive(false);
        }
    }
}
