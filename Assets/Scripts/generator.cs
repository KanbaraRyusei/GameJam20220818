using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : MonoBehaviour
{
    [SerializeField] Transform[] _generateposition;
    [SerializeField] GameObject[] _text;
    [SerializeField] GameObject[] _antiComents;
    [SerializeField] float _interval;
    [SerializeField] float _highInterval;
    [SerializeField] AudioClip _bgm;
    float _timer;

    private void Awake()
    {
        SoundManager.Instance.PlayBGM(_bgm);
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _interval)
        {
            int number = Random.Range(0, _generateposition.Length);
            if(TimeManager.Instance.IsFireTime)
            {
                int antiNum = Random.Range(0, _antiComents.Length);
                Instantiate(_antiComents[antiNum], _generateposition[number]);
                _timer = 0;
                return;
            }
            int num = Random.Range(0, _text.Length);
            Instantiate(_text[num], _generateposition[number]);
            _timer = 0;
        }
    }
}
